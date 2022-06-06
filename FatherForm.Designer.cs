
namespace TobaccoExe
{
    partial class FatherForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_form = new System.Windows.Forms.Panel();
            this.btn_mainForm = new System.Windows.Forms.Button();
            this.btn_paraSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.connect_status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mode_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mode_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mode_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label_mode = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_form
            // 
            this.panel_form.Location = new System.Drawing.Point(40, 92);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(1291, 654);
            this.panel_form.TabIndex = 0;
            // 
            // btn_mainForm
            // 
            this.btn_mainForm.Location = new System.Drawing.Point(98, 35);
            this.btn_mainForm.Name = "btn_mainForm";
            this.btn_mainForm.Size = new System.Drawing.Size(102, 37);
            this.btn_mainForm.TabIndex = 1;
            this.btn_mainForm.Text = "主页面";
            this.btn_mainForm.UseVisualStyleBackColor = true;
            this.btn_mainForm.Click += new System.EventHandler(this.btn_mainForm_Click_1);
            // 
            // btn_paraSet
            // 
            this.btn_paraSet.Location = new System.Drawing.Point(250, 35);
            this.btn_paraSet.Name = "btn_paraSet";
            this.btn_paraSet.Size = new System.Drawing.Size(98, 37);
            this.btn_paraSet.TabIndex = 2;
            this.btn_paraSet.Text = "参数设置";
            this.btn_paraSet.UseVisualStyleBackColor = true;
            this.btn_paraSet.Click += new System.EventHandler(this.btn_paraSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1082, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "通讯状态";
            // 
            // connect_status
            // 
            this.connect_status.AutoSize = true;
            this.connect_status.Location = new System.Drawing.Point(1200, 46);
            this.connect_status.Name = "connect_status";
            this.connect_status.Size = new System.Drawing.Size(52, 15);
            this.connect_status.TabIndex = 5;
            this.connect_status.Text = "未连接";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模式ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 模式ToolStripMenuItem
            // 
            this.模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mode_0,
            this.mode_1,
            this.mode_2,
            this.mode_3});
            this.模式ToolStripMenuItem.Name = "模式ToolStripMenuItem";
            this.模式ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.模式ToolStripMenuItem.Text = "模式";
            // 
            // mode_0
            // 
            this.mode_0.Name = "mode_0";
            this.mode_0.Size = new System.Drawing.Size(227, 26);
            this.mode_0.Text = "单点调试模式";
            this.mode_0.Click += new System.EventHandler(this.mode_0_Click);
            // 
            // mode_1
            // 
            this.mode_1.Name = "mode_1";
            this.mode_1.Size = new System.Drawing.Size(227, 26);
            this.mode_1.Text = "预热模式";
            this.mode_1.Click += new System.EventHandler(this.mode_1_Click);
            // 
            // mode_2
            // 
            this.mode_2.Name = "mode_2";
            this.mode_2.Size = new System.Drawing.Size(227, 26);
            this.mode_2.Text = "按参数设定工作模式";
            this.mode_2.Click += new System.EventHandler(this.mode_2_Click);
            // 
            // mode_3
            // 
            this.mode_3.Name = "mode_3";
            this.mode_3.Size = new System.Drawing.Size(227, 26);
            this.mode_3.Text = "自动工作模式";
            this.mode_3.Click += new System.EventHandler(this.mode_3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "工作模式";
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Location = new System.Drawing.Point(739, 46);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(127, 15);
            this.label_mode.TabIndex = 8;
            this.label_mode.Text = "参数设定工作模式";
            // 
            // FatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 776);
            this.Controls.Add(this.label_mode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connect_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_paraSet);
            this.Controls.Add(this.btn_mainForm);
            this.Controls.Add(this.panel_form);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FatherForm";
            this.Text = "烘丝机控制";
            this.Load += new System.EventHandler(this.FatherForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.Button btn_mainForm;
        private System.Windows.Forms.Button btn_paraSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label connect_status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode_0;
        private System.Windows.Forms.ToolStripMenuItem mode_1;
        private System.Windows.Forms.ToolStripMenuItem mode_2;
        private System.Windows.Forms.ToolStripMenuItem mode_3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_mode;
    }
}

