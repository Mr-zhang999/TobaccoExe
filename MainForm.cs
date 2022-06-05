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
        public void EventResponse(float[] msg)
        {
            this.label_weight_in.Text = msg[0].ToString();
            this.label_wet_in.Text = msg[1].ToString();
            this.label_temp_in.Text = msg[2].ToString();
            this.label_wet_out.Text = msg[3].ToString();
            this.label_temp_out.Text = msg[4].ToString();
            this.label_air_speed.Text = msg[5].ToString();

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

        }
    }
}
