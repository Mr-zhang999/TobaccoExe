
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
            this.btn_modeSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.connect_status = new System.Windows.Forms.Label();
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
            this.btn_mainForm.Location = new System.Drawing.Point(75, 35);
            this.btn_mainForm.Name = "btn_mainForm";
            this.btn_mainForm.Size = new System.Drawing.Size(102, 37);
            this.btn_mainForm.TabIndex = 1;
            this.btn_mainForm.Text = "主页面";
            this.btn_mainForm.UseVisualStyleBackColor = true;
            this.btn_mainForm.Click += new System.EventHandler(this.btn_mainForm_Click_1);
            // 
            // btn_paraSet
            // 
            this.btn_paraSet.Location = new System.Drawing.Point(223, 35);
            this.btn_paraSet.Name = "btn_paraSet";
            this.btn_paraSet.Size = new System.Drawing.Size(98, 37);
            this.btn_paraSet.TabIndex = 2;
            this.btn_paraSet.Text = "参数设置";
            this.btn_paraSet.UseVisualStyleBackColor = true;
            // 
            // btn_modeSet
            // 
            this.btn_modeSet.Location = new System.Drawing.Point(383, 35);
            this.btn_modeSet.Name = "btn_modeSet";
            this.btn_modeSet.Size = new System.Drawing.Size(116, 37);
            this.btn_modeSet.TabIndex = 3;
            this.btn_modeSet.Text = "参数设置";
            this.btn_modeSet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1077, 46);
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
            // FatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 776);
            this.Controls.Add(this.connect_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_modeSet);
            this.Controls.Add(this.btn_paraSet);
            this.Controls.Add(this.btn_mainForm);
            this.Controls.Add(this.panel_form);
            this.Name = "FatherForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FatherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.Button btn_mainForm;
        private System.Windows.Forms.Button btn_paraSet;
        private System.Windows.Forms.Button btn_modeSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label connect_status;
    }
}

