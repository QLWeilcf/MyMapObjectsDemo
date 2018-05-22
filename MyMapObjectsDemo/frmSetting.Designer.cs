namespace MyMapObjectsDemo {
    partial class frmSetting {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnBotColor = new System.Windows.Forms.Button();
            this.lblBotColor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrackingCor = new System.Windows.Forms.Button();
            this.lblTrackingCor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnColOK = new System.Windows.Forms.Button();
            this.btnColCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColCancel);
            this.groupBox1.Controls.Add(this.btnColOK);
            this.groupBox1.Controls.Add(this.btnTrackingCor);
            this.groupBox1.Controls.Add(this.btnBotColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTrackingCor);
            this.groupBox1.Controls.Add(this.lblBotColor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnFillColor);
            this.groupBox1.Controls.Add(this.lblFillColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "填充颜色：";
            // 
            // lblFillColor
            // 
            this.lblFillColor.BackColor = System.Drawing.Color.White;
            this.lblFillColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFillColor.Location = new System.Drawing.Point(126, 23);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(100, 19);
            this.lblFillColor.TabIndex = 1;
            // 
            // btnFillColor
            // 
            this.btnFillColor.Location = new System.Drawing.Point(253, 23);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnFillColor.TabIndex = 2;
            this.btnFillColor.Text = "选择颜色";
            this.btnFillColor.UseVisualStyleBackColor = true;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // btnBotColor
            // 
            this.btnBotColor.Location = new System.Drawing.Point(253, 54);
            this.btnBotColor.Name = "btnBotColor";
            this.btnBotColor.Size = new System.Drawing.Size(75, 23);
            this.btnBotColor.TabIndex = 5;
            this.btnBotColor.Text = "选择颜色";
            this.btnBotColor.UseVisualStyleBackColor = true;
            this.btnBotColor.Click += new System.EventHandler(this.btnBotColor_Click);
            // 
            // lblBotColor
            // 
            this.lblBotColor.BackColor = System.Drawing.Color.White;
            this.lblBotColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBotColor.Location = new System.Drawing.Point(126, 54);
            this.lblBotColor.Name = "lblBotColor";
            this.lblBotColor.Size = new System.Drawing.Size(100, 19);
            this.lblBotColor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "边界颜色：";
            // 
            // btnTrackingCor
            // 
            this.btnTrackingCor.Location = new System.Drawing.Point(253, 87);
            this.btnTrackingCor.Name = "btnTrackingCor";
            this.btnTrackingCor.Size = new System.Drawing.Size(75, 23);
            this.btnTrackingCor.TabIndex = 5;
            this.btnTrackingCor.Text = "选择颜色";
            this.btnTrackingCor.UseVisualStyleBackColor = true;
            this.btnTrackingCor.Click += new System.EventHandler(this.btnTrackingCor_Click);
            // 
            // lblTrackingCor
            // 
            this.lblTrackingCor.BackColor = System.Drawing.Color.White;
            this.lblTrackingCor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTrackingCor.Location = new System.Drawing.Point(126, 87);
            this.lblTrackingCor.Name = "lblTrackingCor";
            this.lblTrackingCor.Size = new System.Drawing.Size(100, 19);
            this.lblTrackingCor.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "跟踪颜色：";
            // 
            // btnColOK
            // 
            this.btnColOK.Location = new System.Drawing.Point(138, 167);
            this.btnColOK.Name = "btnColOK";
            this.btnColOK.Size = new System.Drawing.Size(75, 23);
            this.btnColOK.TabIndex = 6;
            this.btnColOK.Text = "确定";
            this.btnColOK.UseVisualStyleBackColor = true;
            this.btnColOK.Click += new System.EventHandler(this.btnColOK_Click);
            // 
            // btnColCancel
            // 
            this.btnColCancel.Location = new System.Drawing.Point(231, 167);
            this.btnColCancel.Name = "btnColCancel";
            this.btnColCancel.Size = new System.Drawing.Size(75, 23);
            this.btnColCancel.TabIndex = 7;
            this.btnColCancel.Text = "取消";
            this.btnColCancel.UseVisualStyleBackColor = true;
            this.btnColCancel.Click += new System.EventHandler(this.btnColCancel_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 220);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "colorSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnColCancel;
        private System.Windows.Forms.Button btnColOK;
        private System.Windows.Forms.Button btnTrackingCor;
        private System.Windows.Forms.Button btnBotColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTrackingCor;
        private System.Windows.Forms.Label lblBotColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Label label1;
    }
}