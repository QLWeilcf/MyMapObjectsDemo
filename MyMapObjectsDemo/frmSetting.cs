using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMapObjectsDemo {
    public partial class frmSetting : Form {
        private Color _fillColor;
        private Color _boundayColor;
        private Color _trackingColor;
        public frmSetting () {
            InitializeComponent();
        }
        //用于窗体传值
        /// <summary>
        /// 获取或设置填充色
        /// </summary>
        public Color FillColor {
            get {
                return _fillColor;
            }set {

                _fillColor = value;
            }
        }
       /// <summary>
       /// 获取或设置边界色
       /// </summary>
        public Color BoundaryColor {
            get {
                return _boundayColor;
            }
            set {

                _boundayColor = value;
            }
        }
        /// <summary>
        /// 获取或设置跟踪色
        /// </summary>
        public Color    TrackingColor {
            get {
                return _trackingColor;
            }
            set {
                _trackingColor = value;
            }
        }

        private void frmSetting_Load (object sender, EventArgs e) {
            showFillColor();
            showBoundaryColor();
            showTrackingColor();
        }
#region 按钮事件
        private void btnFillColor_Click (object sender, EventArgs e) {
            ColorDialog sfillColD = new ColorDialog();
            sfillColD.Color = _fillColor; //选中颜色为当前填充色
           if(sfillColD.ShowDialog(this) == DialogResult.OK) {
                //当用户 按了确定去选择颜色时
                _fillColor = sfillColD.Color;
                showFillColor();
            }
            sfillColD.Dispose();
        }
        //选择的边界颜色
        private void btnBotColor_Click (object sender, EventArgs e) {
            ColorDialog sfillColD = new ColorDialog();
            sfillColD.Color = _boundayColor; //选中颜色为当前填充色
           if(sfillColD.ShowDialog(this) == DialogResult.OK) {
                //当用户 按了确定去选择颜色时
                _boundayColor = sfillColD.Color;
                showBoundaryColor();
                
            }
            sfillColD.Dispose();
        }
        

        private void btnTrackingCor_Click (object sender, EventArgs e) {
            ColorDialog sfillColD = new ColorDialog();
            sfillColD.Color = _trackingColor; //选中颜色为当前填充色
            if (sfillColD.ShowDialog(this) == DialogResult.OK) {
                //当用户 按了确定去选择颜色时
                _trackingColor = sfillColD.Color;
                showTrackingColor();
            }
            sfillColD.Dispose();
        
    }
        //确定按钮
        private void btnColOK_Click (object sender, EventArgs e) {
            //把值传回去
            this.DialogResult = DialogResult.OK;
        }
        //取消按钮
        private void btnColCancel_Click (object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
        #region 私有函数
        //显示填充色
        private void showFillColor () {
            lblFillColor.BackColor = _fillColor;
        }
        //显示边界色
        private void showBoundaryColor () {
            lblBotColor.BackColor = _boundayColor;
        }
        //显示跟踪色
        private void showTrackingColor () {
            lblTrackingCor.BackColor = _trackingColor;
        }



        #endregion

    }
}
