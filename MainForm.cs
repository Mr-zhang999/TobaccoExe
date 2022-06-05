using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TobaccoExe.FatherForm;

namespace TobaccoApp
{
    public partial class MainForm : Form
    {
        int id_1 = 0;
        int id_2 = 0;
        int id_3 = 0;
        int id_4 = 0;

        List<int> id_1_List = new List<int>();
        List<int> id_2_List = new List<int>();
        List<int> id_3_List = new List<int>();
        List<int> id_4_List = new List<int>();
        List<float> roll_1_List = new List<float>();
        List<float> roll_2_List = new List<float>();
        List<float> roll_3_List = new List<float>();
        List<float> roll_4_List = new List<float>();
        float[] msgChart = new float[4];
        public void EventResponse(float[] msg)
        {
            this.label_weight_in.Text = msg[0].ToString();
            this.label_wet_in.Text = msg[1].ToString();
            this.label_temp_in.Text = msg[2].ToString();
            this.label_wet_out.Text = msg[3].ToString();
            this.label_temp_out.Text = msg[4].ToString();
            this.label_air_speed.Text = msg[5].ToString();
            msgChart[0] = msg[6];
            msgChart[1] = msg[7];
            msgChart[2] = msg[8];
            msgChart[3] = msg[9];
            this.label_temp_01.Text = msg[6].ToString();
            this.label_temp_02.Text = msg[7].ToString();
            this.label_temp_03.Text = msg[8].ToString();
            this.label_temp_04.Text = msg[9].ToString();

            this.label_air_temp_out.Text = msg[10].ToString();
            this.label_air_temp_out_in.Text = msg[11].ToString();
            this.label_environ_temp.Text = msg[12].ToString();
            this.label_environ_wet.Text = msg[13].ToString();
        }
        public MainForm()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 200;
            chart1.ChartAreas[0].AxisY.Interval = 20;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisX.Title = "Time/s";
            chart1.ChartAreas[0].AxisY.Title = "Temperature/℃";
        }

        private void getData()
        {
            id_1_List.Add(id_1);
            id_2_List.Add(id_2);
            id_3_List.Add(id_3);
            id_4_List.Add(id_4);
            id_1++;
            id_2++;
            id_3++;
            id_4++;
            if (id_1 > 199) id_1 = 199;
            if (id_2 > 199) id_2 = 199;
            if (id_3 > 199) id_3 = 199;
            if (id_4 > 199) id_4 = 199;
            roll_1_List.Add(msgChart[0]);
            roll_2_List.Add(msgChart[1]);
            roll_3_List.Add(msgChart[2]);
            roll_4_List.Add(msgChart[3]);
            //画图函数
            drawLines_Roll_1(id_1_List, roll_1_List);
            drawLines_Roll_2(id_2_List, roll_2_List);
            drawLines_Roll_3(id_3_List, roll_3_List);
            drawLines_Roll_4(id_4_List, roll_4_List);
            if (roll_1_List.Count >= 200)
            {
                roll_1_List.RemoveAt(0);
                id_1_List.RemoveAt(0);
                for (int i = 0; i < id_1_List.Count; i++)
                {
                    id_1_List[i] -= 1;
                }
            }
            if (roll_2_List.Count >= 200)
            {
                roll_2_List.RemoveAt(0);
                id_2_List.RemoveAt(0);
                for (int i = 0; i < id_1_List.Count; i++)
                {
                    id_2_List[i]--;
                }
            }
            if (roll_3_List.Count >= 200)
            {
                roll_3_List.RemoveAt(0);
                id_3_List.RemoveAt(0);
                for (int i = 0; i < id_1_List.Count; i++)
                {
                    id_3_List[i]--;
                }
            }
            if (roll_4_List.Count >= 200)
            {
                roll_4_List.RemoveAt(0);
                id_4_List.RemoveAt(0);
                for (int i = 0; i < id_1_List.Count; i++)
                {
                    id_4_List[i]--;
                }
            }

        }
        public void drawLines_Roll_1(List<int> list1, List<float> list2)
        {
            List<int> xData = list1;
            List<float> yData = list2;
            //线条颜色
            chart1.Series[0].Color = Color.DeepSkyBlue;
            //线条粗细
            chart1.Series[0].BorderWidth = 1;
            //标记点中心颜色
            //chart1.Series[0].MarkerColor = Color.DeepSkyBlue;
            //标记点大小
            //chart1.Series[0].MarkerSize = 5;
            //标记点类型     
            //chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            //绑定数据   
            chart1.Series[0].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_2(List<int> list1, List<float> list2)
        {
            List<int> xData = list1;
            List<float> yData = list2;

            chart1.Series[1].Color = Color.DeepPink;
            chart1.Series[1].BorderWidth = 1;
            chart1.Series[1].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_3(List<int> list1, List<float> list2)
        {
            List<int> xData = list1;
            List<float> yData = list2;
            chart1.Series[2].Color = Color.Black;
            chart1.Series[2].BorderWidth = 1;
            chart1.Series[2].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_4(List<int> list1, List<float> list2)
        {
            List<int> xData = list1;
            List<float> yData = list2;
            chart1.Series[3].Color = Color.YellowGreen;
            chart1.Series[3].BorderWidth = 1;
            chart1.Series[3].Points.DataBindXY(xData, yData);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
