using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TobaccoApp
{
    class SendProtocol
    {
        public const byte HEAD = 0xAA;
        //机号
        private byte MachineNum = 0x00;
        //长度
        private byte[] dataLen;
        //命令字
        private byte cmd;
        //系统总模式(参数)
        private byte paraGeneralMode;
        //加热子模式
        private byte[] paraSublMode;
        //极限参数
        private byte[] paraLimit;

        //设定参数
        private byte[] paraSetting;
        //执行机构驱动 
        private byte[] paraActuatorDrive;

        private byte proCheck;

        public SendProtocol()
        {
        }



        public SendProtocol( byte[] dataLen, byte cmd, byte paraGeneralMode, byte[] paraSublMode, byte[] paraLimit, byte[] paraSetting, byte[] paraActuatorDrive, byte proCheck)
        {
           //MachineNum = machineNum;
            this.dataLen = dataLen;
            this.cmd = cmd;
            this.paraGeneralMode = paraGeneralMode;
            this.paraSublMode = paraSublMode;
            this.paraLimit = paraLimit;
            this.paraSetting = paraSetting;
            this.paraActuatorDrive = paraActuatorDrive;
            this.proCheck = proCheck;
        }

        public byte[] DataLen { get => dataLen; set => dataLen = value; }
        public byte Cmd { get => cmd; set => cmd = value; }
        public byte ParaGeneralMode { get => paraGeneralMode; set => paraGeneralMode = value; }
        public byte[] ParaSublMode { get => paraSublMode; set => paraSublMode = value; }
        public byte[] ParaLimit { get => paraLimit; set => paraLimit = value; }
        public byte[] ParaSetting { get => paraSetting; set => paraSetting = value; }
        public byte[] ParaActuatorDrive { get => paraActuatorDrive; set => paraActuatorDrive = value; }
        public byte ProCheck { get => proCheck; set => proCheck = value; }

        public byte[] ToBytes()
        {
            byte[] _bytes;
            using (MemoryStream memoryStream = new MemoryStream())//创建内存流
            {
                //往内存流中写入数据
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                //写入帧头
                binaryWriter.Write(HEAD);
                binaryWriter.Write(MachineNum);


                binaryWriter.Write(dataLen);

              //  binaryWriter.Write(21);
                binaryWriter.Write(cmd);

                binaryWriter.Write(Convert.ToByte(1));
                binaryWriter.Write(paraGeneralMode);

                binaryWriter.Write(Convert.ToByte(paraSublMode.Length));
                binaryWriter.Write(paraSublMode);

                binaryWriter.Write(Convert.ToByte(paraLimit.Length));
                binaryWriter.Write(paraLimit);

                binaryWriter.Write(Convert.ToByte(paraSetting.Length));
                binaryWriter.Write(paraSetting);

                binaryWriter.Write(Convert.ToByte(paraActuatorDrive.Length));
                binaryWriter.Write(paraActuatorDrive);

                _bytes = memoryStream.ToArray();

                binaryWriter.Write(cacCheck(_bytes));
                _bytes = memoryStream.ToArray();
                binaryWriter.Close();
            }
            return _bytes;
        }
        private byte cacCheck(byte[] byteBuffer)
        {
            byte byteTemp = 0;
            int i;

            for (i = 1; i < byteBuffer.Length; i++)
            {
                byteTemp += byteBuffer[i];
            }
            return byteTemp;
        }
    }
}
