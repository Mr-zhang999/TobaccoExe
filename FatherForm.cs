using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TobaccoApp.dto;
using TobaccoApp;

namespace TobaccoExe
{
    public delegate void delegateSendMsgToMainForm(float[] msg);
   
    public partial class FatherForm : Form
    {
        Socket serverSocket;//定义socket对象
        Thread listenThread;//定义监听线程
        Thread threadReceive;//定义接收客户端数据线程
        Socket socket;
        MainForm mainForm;
        ParaSetForm paraSetForm;
        //极限参数和设定参数
        public static int[] limitPara = new int[5];
        //设定参数
        public static int[] setPara = new int[6];
        //反吹风电磁阀启动时长和停止时长
        public static short[] blowbackTIME = new short[2];


        public static float[] roll_temp;
        int modeFlag = 2;
        DateTime Nowtime = DateTime.Now;
        string defaultOperator = "123456";//默认操作员
        private event delegateSendMsgToMainForm SendMsgEventToMain;

        public FatherForm()
        {

            InitializeComponent();

/*           AlgorithmDll algorithmDll = new AlgorithmDll();
           double  a = algorithmDll.fuzzyDllCac(5, 2);*/
            mainForm = new MainForm();
            paraSetForm = new ParaSetForm();  
            roll_temp = new float[4] { 0, 0, 0, 0 };
            SendMsgEventToMain += new delegateSendMsgToMainForm(mainForm.EventResponse);           
        }

        private void FatherForm_Load(object sender, EventArgs e)
        {

            Showform(mainForm);
            //默认操作模式记录
            modeDataOperSave();
            //192.168.2.5
            IPAddress ip = GetLocalIPv4Address();

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//定义一个socket
            try
            {
                serverSocket.Bind(new IPEndPoint(ip, ServiceHelp.SOCKET_PORT));
                serverSocket.Listen(10);//收听模式
                listenThread = new Thread(ListenClientConnect);
                listenThread.Start();//start方法对线程进行运行

                this.Invoke(new Action(() =>
                {
                    connect_status.Text = "正在监听";
                }));
            }
            catch
            { MessageBox.Show("监听异常", "监听异常"); }
        }
        private void ListenClientConnect()
        {
            while (true)
            {
                socket = serverSocket.Accept();//监听到客户端的连接，获取双方的通信socket
                threadReceive = new Thread(ReceiveMsg);//创建线程循环接收客户端发送的数据
                threadReceive.Start();
                this.Invoke(new Action(() =>
                {
                    connect_status.Text = "已连接";
                }));
            }
        }


        public void ReceiveMsg()
        {
            int nOutStep = 0, nOK_Flag = 0, nStep = 0;
            byte[] byteReceBuf = new byte[1024];//定义一个缓冲区
            byte[] byteVariableSizeBuf = new byte[] { };//定义一个大小可变的缓冲区
            Socket myClientSocket = (Socket)socket;
            while (socket.Connected)                                                                              //持续监听
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];                                            //定义一个1M的内存缓冲区，用于临时性存储接收到的消息 
                    int receiveLen = myClientSocket.Receive(byteReceBuf);
                    byteVariableSizeBuf = CPublicFunc.CombineBytes(byteVariableSizeBuf, 0, byteVariableSizeBuf.Length, byteReceBuf, 0, receiveLen);
                    //将客户端套接字接收到的数据存入内存缓冲区，并获取长度  

                    while (byteVariableSizeBuf.Length > 0)
                    {
                        byteVariableSizeBuf = MsgProcess(byteVariableSizeBuf, nStep, out nOutStep, out nOK_Flag);
                        if (nOK_Flag == 1)
                        {
                            nOK_Flag = 0;
                            //数据处理
                            //检查通讯是否异常
                            communicationCheck(byteVariableSizeBuf);
                            //维修状态判断
                            if (byteVariableSizeBuf[16] == 0x01)
                            {
                                MessageBox.Show("正在检修");
                            }
                            //检查设备信号
                            Signalcheck(byteVariableSizeBuf);
                            //数据处理
                            dataProcessing(byteVariableSizeBuf);

                            //去除已处理一帧数据，返回新的字节数组，继续循环处理

                            byteVariableSizeBuf = CPublicFunc.LeftShiftBuffer(CPublicFunc.Convert_ByteToInt32(byteVariableSizeBuf[3], byteVariableSizeBuf[2]) + 2, byteVariableSizeBuf);
                            nStep = 0;
                        }
                        //接收数据不是完整一帧时，继续接收
                        else
                        {
                            nStep = nOutStep;
                            break;
                        }
                    }
                }
               catch (Exception ex)
                {
                    //测试
                    string str1 = ex.Message + '\n';
                    break;
                }
            }
        }
        private byte[] MsgProcess(byte[] byteVariableSizeBuf, int nStep, out int nOutStep, out int nOK_Flag)
        {
            nOutStep = nStep;
            nOK_Flag = 0;
            int nLength;
            //BBH＋机号＋长度＋命令字＋参数＋校验码
            while (true)
            {
                if (byteVariableSizeBuf.Length < 1)
                {
                    nOutStep = 0;
                    nOK_Flag = 0;
                    return byteVariableSizeBuf;
                }
                //  BBH
                if (nOutStep == 0)
                {
                    if (byteVariableSizeBuf[0] == 0xBB)
                    {
                        nOutStep = 1;
                    }
                    else
                    {
                        byteVariableSizeBuf = CPublicFunc.LeftShiftBuffer(1, byteVariableSizeBuf);
                    }
                    continue;
                }
                // 机号 00
                else if (nOutStep == 1)
                {
                    if (byteVariableSizeBuf.Length >= 2)
                    {
                        if (byteVariableSizeBuf[1] == 0x00)
                        {
                            nOutStep = 2;
                        }
                        else
                        {
                            byteVariableSizeBuf = CPublicFunc.LeftShiftBuffer(1, byteVariableSizeBuf);
                            nOutStep = 0;
                        }
                        continue;
                    }
                    else
                    {
                        return byteVariableSizeBuf;
                    }
                }
                else if (nOutStep == 2)
                {
                    nLength = CPublicFunc.Convert_ByteToInt32(byteVariableSizeBuf[3], byteVariableSizeBuf[2]);
                    if (byteVariableSizeBuf.Length >= nLength + 2)
                    {
                        if (Socket_Rece_Total(byteVariableSizeBuf) == true)
                        {
                            nOutStep = 0;
                            nOK_Flag = 1;
                            return byteVariableSizeBuf;
                        }
                        else
                        {
                            nOutStep = 0;
                            byteVariableSizeBuf = CPublicFunc.LeftShiftBuffer(6, byteVariableSizeBuf);
                            continue;
                        }
                    }
                    else
                    {
                        return byteVariableSizeBuf;
                    }
                }
                else if (nOutStep == 3)
                {
                    if (byteVariableSizeBuf.Length >= 5)//检查命令字
                    {
                        if (byteVariableSizeBuf[5] == 0x21)
                        {
                            nOutStep = 4;
                        }
                        else
                        {
                            nOutStep = 0;
                            byteVariableSizeBuf = CPublicFunc.LeftShiftBuffer(6, byteVariableSizeBuf);
                        }
                    }
                    else
                    {
                        return byteVariableSizeBuf;
                    }
                }
                else
                {
                    nOutStep = 0;
                    nOK_Flag = 0;
                    continue;
                }
            }
        }
        public void communicationCheck(byte[] byteVariableSizeBuf)
        {
            if (byteVariableSizeBuf[6] != 0x01)
            {
                MessageBox.Show("PLC通讯异常");
            }
            if (byteVariableSizeBuf[7] != 0x01)
            {
                MessageBox.Show("ZigBee滚筒1通讯异常");
            }
            if (byteVariableSizeBuf[8] != 0x01)
            {
                MessageBox.Show("ZigBee滚筒2通讯异常");
            }
            if (byteVariableSizeBuf[9] != 0x01)
            {
                MessageBox.Show("ZigBee环境通讯异常");
            }
            if (byteVariableSizeBuf[10] != 0x01)
            {
                //MessageBox.Show("滚筒1加热通讯异常");
            }
            if (byteVariableSizeBuf[11] != 0x01)
            {
                //  MessageBox.Show("滚筒2加热通讯异常");
            }
            if (byteVariableSizeBuf[12] != 0x01)
            {
                // MessageBox.Show("滚筒3加热通讯异常");
            }
            if (byteVariableSizeBuf[13] != 0x01)
            {
                //MessageBox.Show("滚筒4加热通讯异常");
            }
            if (byteVariableSizeBuf[14] != 0x01)
            {
                // MessageBox.Show("热风加热通讯异常");
            }
        }
        public void Signalcheck(byte[] byteVariableSizeBuf)
        {
            if (byteVariableSizeBuf[18] == 0x00)
            {
                MessageBox.Show("排潮/除尘运行已停止");
            }
            if (byteVariableSizeBuf[19] == 0x00)
            {
                MessageBox.Show("主线自动启动已停止");
            }
            if (byteVariableSizeBuf[20] == 0x00)
            {
                MessageBox.Show("烘丝机入口设备运行已停止");
            }
            if (byteVariableSizeBuf[21] == 0x00)
            {
                MessageBox.Show("入口秤有料信号 无料");
            }
            if (byteVariableSizeBuf[22] == 0x01)
            {
                MessageBox.Show("入口设备故障信号 故障");
            }
            if (byteVariableSizeBuf[23] == 0x01)
            {
                MessageBox.Show("入口电子秤故障信号 故障");
            }
            if (byteVariableSizeBuf[36] == 0x01)
            {
                // MessageBox.Show("出口设备运行 停止");
            }
            if (byteVariableSizeBuf[37] == 0x00)
            {
                MessageBox.Show("出口设备有料信号 故障");
            }
        }
        public void dataProcessing(byte[] byteVariableSizeBuf)
        {
            SensorRecord sensorRecord = new SensorRecord();
            roll_temp = new float[14];
            //进口物料重量
            float weight_in = byteToFloat(byteVariableSizeBuf, 24);
            roll_temp[0] = weight_in;
            //进口物料含水率
            float wet_in = byteToFloat(byteVariableSizeBuf, 28);
            roll_temp[1] = wet_in;
            //进口物料温度
            float temp_in = byteToFloat(byteVariableSizeBuf, 32);
            roll_temp[2] = temp_in;
            //出口物料水分实际值
            float wet_out = byteToFloat(byteVariableSizeBuf, 38);
            roll_temp[3] = wet_out;
            //出口物料温度实际值
            float temp_out = byteToFloat(byteVariableSizeBuf, 42);
            roll_temp[4] = temp_out;
            //热风流量
            float air_speed = byteToFloat(byteVariableSizeBuf, 46);
            roll_temp[5] = air_speed;
            //滚筒温度
            float section_temp1 = byteToFloat(byteVariableSizeBuf, 50);
            float section_temp2 = byteToFloat(byteVariableSizeBuf, 54);
            float section_temp3 = byteToFloat(byteVariableSizeBuf, 58);
            float section_temp4 = byteToFloat(byteVariableSizeBuf, 62);
            roll_temp[6] = section_temp1;
            roll_temp[7] = section_temp2;
            roll_temp[8] = section_temp3;
            roll_temp[9] = section_temp4;
            //热风出口温度
            float air_temp_out = byteToFloat(byteVariableSizeBuf, 66);
            roll_temp[10] = air_temp_out;
            //热风回风口温度
            float air_temp_out_in = byteToFloat(byteVariableSizeBuf, 70);
            roll_temp[11] = air_temp_out_in;
            //环境温度
            float environ_temp = byteToFloat(byteVariableSizeBuf, 74);
            roll_temp[12] = environ_temp;
            //环境湿度
            float environ_wet = byteToFloat(byteVariableSizeBuf, 78);
            roll_temp[13] = environ_wet;

            //传递数据到主页面
            SendMsgEventToMain(roll_temp);
            sendCommand();
            string strSQL, strTemp;
            strSQL = "insert into TBL_SENSOR_RECORD(SR_Time,SR_STUFF_WEIGHT,SR_STUFF_WET_IN,SR_STUFF_TEMP_IN,SR_STUFF_WET_OUT,SR_STUFF_TEMP_OUT,SR_AIR_SPEED,SR_SECTION_TEMP1,SR_SECTION_TEMP2,SR_SECTION_TEMP3,SR_SECTION_TEMP4,SR_AIR_TEMP_IN,SR_AIR_TEMP_OUT,SR_ENVIRON_TEMP,SR_ENVIRON_WET,SR_SECTION_TEMP1_BAK,SR_SECTION_TEMP2_BAK,SR_SECTION_TEMP3_BAK,SR_SECTION_TEMP4_BAK)";
            strTemp = string.Format("{0} values('{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})",
                    strSQL,
                    string.Format("{0:yyyy-MM-dd HH:mm:ss}", Nowtime),
                   (int) (roll_temp[0]*100),
                   (int)(roll_temp[1] * 100),
                   (int)(roll_temp[2] * 100),
                   (int)(roll_temp[3] * 100),
                   (int)(roll_temp[4] * 100),
                   (int)(roll_temp[5] * 100),
                   (int)(roll_temp[6] * 100),
                   (int)(roll_temp[7] * 100),
                   (int)(roll_temp[8] * 100),
                   (int)(roll_temp[9] * 100),
                   (int)(roll_temp[10] * 100),
                   (int)(roll_temp[11] * 100),
                   (int)(roll_temp[12] * 100),
                   (int)(roll_temp[13] * 100),
                   -1,
                   -1,
                   -1,
                   -1
                );
            strSQL = strTemp;
            DataOperator.ExecSQL(strSQL);
        }

        private void sendCommand()
        {
            //调用算法计算下发命令
            //极限参数
            byte[] paraSub = new byte[5];
            //int[] limit = new int[5] { 10000, 12000, 13000, 14000, 15000 };
            //滚筒温度设定值和热风出口温度、出口含水率
            //int[] set = new int[6] { 10000, 12000, 13000, 14000, 15000, 16000 };
            //反吹风电磁阀启动时长和停止时长
            //short[] set1 = new short[2] { 5, 5 };
            byte[] s = new byte[setPara.Length * 4 + blowbackTIME.Length * 2];
            //设定参数
            for (int i = 0; i < CPublicFunc.intArrToBytesArr(setPara).Length; i++)
            {
                s[i] = CPublicFunc.intArrToBytesArr(setPara)[i];
            }
            for (int i = 0; i < CPublicFunc.shortArrToBytesArr(blowbackTIME).Length; i++)
            {
                s[setPara.Length + i] = CPublicFunc.shortArrToBytesArr(blowbackTIME)[i];
            }
                /*烘丝机运行信号
                烘丝机允许进料信号
                排潮 / 除尘请求信号
                进料传送带电机
                出料传送带电机
                转网驱动减速机
                反吹风电磁阀
                热风风门定位器
                滚筒转动变频器
                热风风机
                排潮风机
                滚筒1加热功率等级
                滚筒2加热功率等级
                滚筒3加热功率等级
                滚筒4加热功率等级
                热风加热功率等级*/
            byte[] actuatorDrive = new byte[16] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 };
            SendProtocol sendProtocol = new SendProtocol();
            sendProtocol.Cmd = 0x21;
            sendProtocol.ParaGeneralMode = 0x00;
            sendProtocol.ParaSublMode = paraSub;
            sendProtocol.ParaLimit = CPublicFunc.intArrToBytesArr(limitPara);
            sendProtocol.ParaSetting = s;
            sendProtocol.ParaActuatorDrive = actuatorDrive;
            int limitLength = CPublicFunc.intArrToBytesArr(limitPara).Length;
            sendProtocol.DataLen = CPublicFunc.shortToBytes((short)(5 + 1 + 5 + paraSub.Length + CPublicFunc.intArrToBytesArr(limitPara).Length + s.Length + actuatorDrive.Length));
            SendMsg(sendProtocol.ToBytes());
        }
        public void SendMsg(byte[] buffer)
        {
            if (null != socket)
            {
                socket.Send(buffer);
            }
            else
            {
                MessageBox.Show("请检查Socket是否连接");
            }
        }

        //高字节在前，低字节在后转换int32
        public int bytesToInt(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset + 3] & 0xFF)
                    | ((src[offset + 2] & 0xFF) << 8)
                    | ((src[offset + 1] & 0xFF) << 16)
                    | ((src[offset + 0] & 0xFF) << 24));
            return value;
        }
        //byte转浮点数
        public static float byteToFloat(byte[] bytes, int index)
        {
            //调整顺序
            byte a = bytes[index];
            bytes[index] = bytes[index + 3];
            bytes[index + 3] = a;
            a = bytes[index + 1];
            bytes[index + 1] = bytes[index + 2];
            bytes[index + 2] = a;
            float res = BitConverter.ToSingle(bytes, index);
            return res;
        }
        private bool Socket_Rece_Total(byte[] byteBuffer)
        {
            byte byteTemp = 0;
            int i, nLength;
            nLength = CPublicFunc.Convert_ByteToInt32(byteBuffer[2], byteBuffer[3]);
            for (i = 1; i < byteBuffer.Length - 1; i++)
            {
                byteTemp += byteBuffer[i];
            }
            if (byteTemp == byteBuffer[i - 1])
            {
                return true;
            }
            //测试，实际使用 最后是 返回false；
            return true;
        }
        /// <summary>
        /// 获取本地IPv4地址
        public IPAddress GetLocalIPv4Address()
        {
            IPAddress localIPv4 = null;
            //获取本机所有的IP地址列表
            IPAddress[] ipAddressList = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ipAddressList)
            {
                //判断是否是IPv4地址
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIPv4 = ipAddress;
                }
                else
                {
                    continue;
                }
            }
            return localIPv4;
        }
        public void Showform(Form form)
        {
            //清除panel里面的其他窗体
            this.panel_form.Controls.Clear();
            //将该子窗体设置成非顶级控件
            form.TopLevel = false;
            //将该子窗体的边框去掉
            form.FormBorderStyle = FormBorderStyle.None;
            //设置子窗体随容器大小自动调整
            form.Dock = DockStyle.Fill;
            //设置mdi父容器为当前窗口
            form.Parent = this.panel_form;
            //子窗体显示
            form.Show();
        }
        private void btn_mainForm_Click_1(object sender, EventArgs e)
        {
            Showform(mainForm);
        }

        private void btn_paraSet_Click(object sender, EventArgs e)
        {
            Showform(paraSetForm);
        }

  

        private void mode_0_Click(object sender, EventArgs e)
        {
            modeFlag = 0;
            modeDataOperSave();
            this.label_mode.Text = "单点调试模式";
        }

        private void mode_1_Click(object sender, EventArgs e)
        {
            modeFlag = 1;
            modeDataOperSave();
            this.label_mode.Text = "预热模式";
        }

        private void mode_2_Click(object sender, EventArgs e)
        {
            modeFlag = 2;
            modeDataOperSave();
            this.label_mode.Text = "按参数设定工作模式";
        }

        private void mode_3_Click(object sender, EventArgs e)
        {
            modeFlag = 3;
            modeDataOperSave();
            this.label_mode.Text = "自动工作模式";
        }
        private void modeDataOperSave()
        {           
            string strSQL, strTemp;
            strSQL = "insert into TBL_SET_MODE(SM_MODIFY_TIME,SM_MODE,SM_OPER_NUMBER)";
            strTemp = string.Format("{0} values('{1}',{2},{3})",
                    strSQL,
                    string.Format("{0:yyyy-MM-dd HH:mm:ss}", Nowtime),
                  modeFlag,
                  defaultOperator
                ); 
            strSQL = strTemp;
            DataOperator.ExecSQL(strSQL);
        }

    }
}
