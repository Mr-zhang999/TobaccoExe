
namespace TobaccoApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_temp_01 = new System.Windows.Forms.Label();
            this.label_temp_02 = new System.Windows.Forms.Label();
            this.label_temp_03 = new System.Windows.Forms.Label();
            this.label_temp_04 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_weight_in = new System.Windows.Forms.Label();
            this.label_air_temp_out_in = new System.Windows.Forms.Label();
            this.label_air_temp_out = new System.Windows.Forms.Label();
            this.label_air_speed = new System.Windows.Forms.Label();
            this.label_temp_out = new System.Windows.Forms.Label();
            this.label_wet_out = new System.Windows.Forms.Label();
            this.label_temp_in = new System.Windows.Forms.Label();
            this.label_wet_in = new System.Windows.Forms.Label();
            this.label_environ_temp = new System.Windows.Forms.Label();
            this.label_environ_wet = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_temp_01
            // 
            this.label_temp_01.AutoSize = true;
            this.label_temp_01.Location = new System.Drawing.Point(44, 458);
            this.label_temp_01.Name = "label_temp_01";
            this.label_temp_01.Size = new System.Drawing.Size(23, 15);
            this.label_temp_01.TabIndex = 0;
            this.label_temp_01.Text = "-1";
            // 
            // label_temp_02
            // 
            this.label_temp_02.AutoSize = true;
            this.label_temp_02.Location = new System.Drawing.Point(145, 458);
            this.label_temp_02.Name = "label_temp_02";
            this.label_temp_02.Size = new System.Drawing.Size(23, 15);
            this.label_temp_02.TabIndex = 1;
            this.label_temp_02.Text = "-1";
            // 
            // label_temp_03
            // 
            this.label_temp_03.AutoSize = true;
            this.label_temp_03.Location = new System.Drawing.Point(246, 458);
            this.label_temp_03.Name = "label_temp_03";
            this.label_temp_03.Size = new System.Drawing.Size(23, 15);
            this.label_temp_03.TabIndex = 2;
            this.label_temp_03.Text = "-1";
            // 
            // label_temp_04
            // 
            this.label_temp_04.AutoSize = true;
            this.label_temp_04.Location = new System.Drawing.Point(370, 458);
            this.label_temp_04.Name = "label_temp_04";
            this.label_temp_04.Size = new System.Drawing.Size(23, 15);
            this.label_temp_04.TabIndex = 3;
            this.label_temp_04.Text = "-1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "滚筒温度1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "滚筒温度2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "滚筒温度3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "滚筒温度4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "进口物料重量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "进口物料含水率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "进口物料温度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "热风回风口温度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "热风出口温度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "热风流量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "出口物料温度实际值";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "出口物料水分实际值";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 528);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 16;
            this.label13.Text = "环境温度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(153, 528);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "环境湿度";
            // 
            // label_weight_in
            // 
            this.label_weight_in.AutoSize = true;
            this.label_weight_in.Location = new System.Drawing.Point(50, 126);
            this.label_weight_in.Name = "label_weight_in";
            this.label_weight_in.Size = new System.Drawing.Size(23, 15);
            this.label_weight_in.TabIndex = 18;
            this.label_weight_in.Text = "-1";
            // 
            // label_air_temp_out_in
            // 
            this.label_air_temp_out_in.AutoSize = true;
            this.label_air_temp_out_in.Location = new System.Drawing.Point(338, 335);
            this.label_air_temp_out_in.Name = "label_air_temp_out_in";
            this.label_air_temp_out_in.Size = new System.Drawing.Size(23, 15);
            this.label_air_temp_out_in.TabIndex = 19;
            this.label_air_temp_out_in.Text = "-1";
            // 
            // label_air_temp_out
            // 
            this.label_air_temp_out.AutoSize = true;
            this.label_air_temp_out.Location = new System.Drawing.Point(180, 335);
            this.label_air_temp_out.Name = "label_air_temp_out";
            this.label_air_temp_out.Size = new System.Drawing.Size(23, 15);
            this.label_air_temp_out.TabIndex = 20;
            this.label_air_temp_out.Text = "-1";
            // 
            // label_air_speed
            // 
            this.label_air_speed.AutoSize = true;
            this.label_air_speed.Location = new System.Drawing.Point(44, 335);
            this.label_air_speed.Name = "label_air_speed";
            this.label_air_speed.Size = new System.Drawing.Size(23, 15);
            this.label_air_speed.TabIndex = 21;
            this.label_air_speed.Text = "-1";
            // 
            // label_temp_out
            // 
            this.label_temp_out.AutoSize = true;
            this.label_temp_out.Location = new System.Drawing.Point(233, 233);
            this.label_temp_out.Name = "label_temp_out";
            this.label_temp_out.Size = new System.Drawing.Size(23, 15);
            this.label_temp_out.TabIndex = 22;
            this.label_temp_out.Text = "-1";
            // 
            // label_wet_out
            // 
            this.label_wet_out.AutoSize = true;
            this.label_wet_out.Location = new System.Drawing.Point(50, 233);
            this.label_wet_out.Name = "label_wet_out";
            this.label_wet_out.Size = new System.Drawing.Size(23, 15);
            this.label_wet_out.TabIndex = 23;
            this.label_wet_out.Text = "-1";
            // 
            // label_temp_in
            // 
            this.label_temp_in.AutoSize = true;
            this.label_temp_in.Location = new System.Drawing.Point(340, 126);
            this.label_temp_in.Name = "label_temp_in";
            this.label_temp_in.Size = new System.Drawing.Size(23, 15);
            this.label_temp_in.TabIndex = 24;
            this.label_temp_in.Text = "-1";
            // 
            // label_wet_in
            // 
            this.label_wet_in.AutoSize = true;
            this.label_wet_in.Location = new System.Drawing.Point(180, 126);
            this.label_wet_in.Name = "label_wet_in";
            this.label_wet_in.Size = new System.Drawing.Size(23, 15);
            this.label_wet_in.TabIndex = 25;
            this.label_wet_in.Text = "-1";
            // 
            // label_environ_temp
            // 
            this.label_environ_temp.AutoSize = true;
            this.label_environ_temp.Location = new System.Drawing.Point(44, 570);
            this.label_environ_temp.Name = "label_environ_temp";
            this.label_environ_temp.Size = new System.Drawing.Size(23, 15);
            this.label_environ_temp.TabIndex = 26;
            this.label_environ_temp.Text = "-1";
            // 
            // label_environ_wet
            // 
            this.label_environ_wet.AutoSize = true;
            this.label_environ_wet.Location = new System.Drawing.Point(153, 570);
            this.label_environ_wet.Name = "label_environ_wet";
            this.label_environ_wet.Size = new System.Drawing.Size(23, 15);
            this.label_environ_wet.TabIndex = 27;
            this.label_environ_wet.Text = "-1";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(505, 38);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "Roll_1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Roll_2";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Roll_3";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Roll_4";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(709, 579);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 693);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label_environ_wet);
            this.Controls.Add(this.label_environ_temp);
            this.Controls.Add(this.label_wet_in);
            this.Controls.Add(this.label_temp_in);
            this.Controls.Add(this.label_wet_out);
            this.Controls.Add(this.label_temp_out);
            this.Controls.Add(this.label_air_speed);
            this.Controls.Add(this.label_air_temp_out);
            this.Controls.Add(this.label_air_temp_out_in);
            this.Controls.Add(this.label_weight_in);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_temp_04);
            this.Controls.Add(this.label_temp_03);
            this.Controls.Add(this.label_temp_02);
            this.Controls.Add(this.label_temp_01);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_temp_01;
        private System.Windows.Forms.Label label_temp_02;
        private System.Windows.Forms.Label label_temp_03;
        private System.Windows.Forms.Label label_temp_04;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_weight_in;
        private System.Windows.Forms.Label label_air_temp_out_in;
        private System.Windows.Forms.Label label_air_temp_out;
        private System.Windows.Forms.Label label_air_speed;
        private System.Windows.Forms.Label label_temp_out;
        private System.Windows.Forms.Label label_wet_out;
        private System.Windows.Forms.Label label_temp_in;
        private System.Windows.Forms.Label label_wet_in;
        private System.Windows.Forms.Label label_environ_temp;
        private System.Windows.Forms.Label label_environ_wet;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}