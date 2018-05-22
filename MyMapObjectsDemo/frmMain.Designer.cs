namespace MyMapObjectsDemo
{
    partial class frmMain
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
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.tss1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnNewPolygon = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnPan = new System.Windows.Forms.Button();
            this.btnSketch = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnColorSetting = new System.Windows.Forms.Button();
            this.chkAutoZoom = new System.Windows.Forms.CheckBox();
            this.btnColorSection = new System.Windows.Forms.Button();
            this.mapControl1 = new MyMapObjects.MapControl();
            this.tssLabel = new System.Windows.Forms.Label();
            this.statusStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip3
            // 
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss1,
            this.tss2});
            this.statusStrip3.Location = new System.Drawing.Point(0, 562);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip3.Size = new System.Drawing.Size(653, 24);
            this.statusStrip3.TabIndex = 3;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // tss1
            // 
            this.tss1.AutoSize = false;
            this.tss1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(200, 19);
            // 
            // tss2
            // 
            this.tss2.AutoSize = false;
            this.tss2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(442, 19);
            this.tss2.Spring = true;
            // 
            // btnNewPolygon
            // 
            this.btnNewPolygon.Location = new System.Drawing.Point(520, 22);
            this.btnNewPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewPolygon.Name = "btnNewPolygon";
            this.btnNewPolygon.Size = new System.Drawing.Size(96, 26);
            this.btnNewPolygon.TabIndex = 4;
            this.btnNewPolygon.Text = "新建六边形";
            this.btnNewPolygon.UseVisualStyleBackColor = true;
            this.btnNewPolygon.Click += new System.EventHandler(this.btnNewPolygon_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(520, 68);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(96, 26);
            this.btnZoomIn.TabIndex = 5;
            this.btnZoomIn.Text = "放大";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(520, 123);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(96, 26);
            this.btnZoomOut.TabIndex = 6;
            this.btnZoomOut.Text = "缩小";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnPan
            // 
            this.btnPan.Location = new System.Drawing.Point(520, 174);
            this.btnPan.Margin = new System.Windows.Forms.Padding(2);
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(96, 26);
            this.btnPan.TabIndex = 7;
            this.btnPan.Text = "漫游";
            this.btnPan.UseVisualStyleBackColor = true;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnSketch
            // 
            this.btnSketch.Location = new System.Drawing.Point(520, 230);
            this.btnSketch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSketch.Name = "btnSketch";
            this.btnSketch.Size = new System.Drawing.Size(96, 26);
            this.btnSketch.TabIndex = 8;
            this.btnSketch.Text = "输入多边形";
            this.btnSketch.UseVisualStyleBackColor = true;
            this.btnSketch.Click += new System.EventHandler(this.btnSketch_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(520, 278);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(96, 26);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnColorSetting
            // 
            this.btnColorSetting.Location = new System.Drawing.Point(520, 322);
            this.btnColorSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnColorSetting.Name = "btnColorSetting";
            this.btnColorSetting.Size = new System.Drawing.Size(96, 26);
            this.btnColorSetting.TabIndex = 10;
            this.btnColorSetting.Text = "设置颜色";
            this.btnColorSetting.UseVisualStyleBackColor = true;
            this.btnColorSetting.Click += new System.EventHandler(this.btnColorSetting_Click);
            // 
            // chkAutoZoom
            // 
            this.chkAutoZoom.AutoSize = true;
            this.chkAutoZoom.Checked = true;
            this.chkAutoZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoZoom.Location = new System.Drawing.Point(532, 376);
            this.chkAutoZoom.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoZoom.Name = "chkAutoZoom";
            this.chkAutoZoom.Size = new System.Drawing.Size(72, 16);
            this.chkAutoZoom.TabIndex = 11;
            this.chkAutoZoom.Text = "自动缩放";
            this.chkAutoZoom.UseVisualStyleBackColor = true;
            this.chkAutoZoom.CheckedChanged += new System.EventHandler(this.chkAutoZoom_CheckedChanged);
            // 
            // btnColorSection
            // 
            this.btnColorSection.Location = new System.Drawing.Point(520, 514);
            this.btnColorSection.Margin = new System.Windows.Forms.Padding(2);
            this.btnColorSection.Name = "btnColorSection";
            this.btnColorSection.Size = new System.Drawing.Size(96, 26);
            this.btnColorSection.TabIndex = 12;
            this.btnColorSection.Text = "退出";
            this.btnColorSection.UseVisualStyleBackColor = true;
            this.btnColorSection.Click += new System.EventHandler(this.btnColorSection_Click);
            // 
            // mapControl1
            // 
            this.mapControl1.BackColor = System.Drawing.Color.White;
            this.mapControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapControl1.BoundaryColor = System.Drawing.Color.Black;
            this.mapControl1.DisplayScale = 1D;
            this.mapControl1.FillColor = System.Drawing.Color.Tomato;
            this.mapControl1.Location = new System.Drawing.Point(0, 1);
            this.mapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Polygons = new MyMapObjects.Polygon[0];
            this.mapControl1.SelectedPolygons = new MyMapObjects.Polygon[0];
            this.mapControl1.SelfMouseWheel = true;
            this.mapControl1.Size = new System.Drawing.Size(509, 539);
            this.mapControl1.TabIndex = 13;
            this.mapControl1.TrackingColor = System.Drawing.Color.DarkGreen;
            this.mapControl1.DisplayScaleChanged += new MyMapObjects.MapControl.DisplayScaleChangedHandle(this.mapControl1_DisplayScaleChanged);
            this.mapControl1.SelectingFinished += new MyMapObjects.MapControl.SelectingFinishedHandle(this.mapControl1_SelectingFinished);
            this.mapControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl1_MouseMove);
            // 
            // tssLabel
            // 
            this.tssLabel.AutoSize = true;
            this.tssLabel.Location = new System.Drawing.Point(307, 574);
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(0, 12);
            this.tssLabel.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 586);
            this.Controls.Add(this.tssLabel);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.btnColorSection);
            this.Controls.Add(this.chkAutoZoom);
            this.Controls.Add(this.btnColorSetting);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnSketch);
            this.Controls.Add(this.btnPan);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnNewPolygon);
            this.Controls.Add(this.statusStrip3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图组件演示程序";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel tss1;
        private System.Windows.Forms.ToolStripStatusLabel tss2;
        private System.Windows.Forms.Button btnNewPolygon;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnPan;
        private System.Windows.Forms.Button btnSketch;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnColorSetting;
        private System.Windows.Forms.CheckBox chkAutoZoom;
        private System.Windows.Forms.Button btnColorSection;
        private MyMapObjects.MapControl mapControl1;
        private System.Windows.Forms.Label tssLabel;
    }
}

