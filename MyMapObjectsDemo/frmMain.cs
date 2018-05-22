using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMapObjectsDemo
{
    public partial class frmMain : Form {
        #region 构造函数
        public frmMain () {
            InitializeComponent();
        }
        #endregion

        #region 窗体和控件的事件处理
        private void frmMain_Load (object sender, EventArgs e) {
            showScale();

        }


        /// <summary>
        /// 新建六边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPolygon_Click (object sender, EventArgs e) {
            MyMapObjects.PointD[] sPoints = new MyMapObjects.PointD[6];
            double sX = mapControl1.Width / 2;
            double sY = mapControl1.Height / 2;
            double sRadius = 100D;
            for (int i = 0; i < 6; i++) {
                sPoints[i] = new MyMapObjects.PointD();
                sPoints[i].X = sX + sRadius * Math.Cos(Math.PI * 60 / 180 * i);
                sPoints[i].Y = sY + sRadius * Math.Sin(Math.PI * 60 / 180 * i);
            }
            MyMapObjects.Polygon sHex = new MyMapObjects.Polygon(sPoints);
            mapControl1.AddPolygon(sHex);
            mapControl1.Refresh();

        }
        #endregion
        #region 窗体
        private void btnZoomIn_Click (object sender, EventArgs e) {
            mapControl1.ZoomIn();
        }

        private void btnZoomOut_Click (object sender, EventArgs e) {
            mapControl1.ZoomOut();
        }

        private void btnPan_Click (object sender, EventArgs e) {
            mapControl1.Pan();
        }

        private void btnSketch_Click (object sender, EventArgs e) {
            mapControl1.TrackingPolygon();
        }

        private void btnSelect_Click (object sender, EventArgs e) {
            mapControl1.SelectFeatures();
        }
        //设置颜色按钮
        private void btnColorSetting_Click (object sender, EventArgs e) {
            //涉及窗体传值；
            frmSetting sfrmSetting = new frmSetting();
            sfrmSetting.FillColor = mapControl1.FillColor;
            sfrmSetting.BoundaryColor = mapControl1.BoundaryColor;
            sfrmSetting.TrackingColor = mapControl1.TrackingColor;

            //this指代frmMain  通过父窗体显示对话框
            if (sfrmSetting.ShowDialog(this) == DialogResult.OK) {
                mapControl1.FillColor = sfrmSetting.FillColor;
                mapControl1.BoundaryColor= sfrmSetting.BoundaryColor ;
                mapControl1.TrackingColor= sfrmSetting.TrackingColor ;
                mapControl1.Refresh();
            }
            sfrmSetting.Dispose();
        }

        //用户改变了自动缩放
        private void chkAutoZoom_CheckedChanged (object sender, EventArgs e) {
            mapControl1.SelfMouseWheel = chkAutoZoom.Checked;//选择->自动缩放
        }
        //比例尺变化时
        private void mapControl1_DisplayScaleChanged (object sender) {
            showScale();

        }

        //退出按钮
        private void btnColorSection_Click (object sender, EventArgs e) {
            Application.Exit();
        }

        #endregion

        //用户输入多边形结束
        private void mapControl1_TrackingFinished (object sender, MyMapObjects.Polygon polygon) {
            mapControl1.AddPolygon(polygon);
            mapControl1.Refresh();
        }
        //鼠标移动事件
        private void mapControl1_MouseMove (object sender, MouseEventArgs e) {
            showCoodinates(e.Location);
        }

        private void mapControl1_SelectingFinished (object sender, MyMapObjects.RectangeD box) {
            MyMapObjects.Polygon[] sPolygens = mapControl1.SelectByBox(box);
            mapControl1.SelectedPolygons = sPolygens;
            mapControl1.Refresh();
        }

        #region 私有函数
        //显示鼠标所在位置的地图坐标
        private void showCoodinates (PointF mouseLoc) {
            MyMapObjects.PointD sMouseLoc = new MyMapObjects.PointD(mouseLoc.X, mouseLoc.Y);
            MyMapObjects.PointD sPointOnMap = mapControl1.ToMapPoint(sMouseLoc);
            //地图坐标
            tss1.Text = "X:" + sPointOnMap.X.ToString("0.00") + ",Y:" + sPointOnMap.Y.ToString("0.00");

        }
        //显示比例尺
        private void showScale () {
            tss2.Text = "1:" + mapControl1.DisplayScale.ToString("0.00");
            tssLabel.Text = "1:" + mapControl1.DisplayScale.ToString("0.00");
        }


        #endregion
    }

    
}
