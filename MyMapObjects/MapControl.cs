using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMapObjects
{
    public partial class MapControl : UserControl
    {
        #region 字段
        //设计时属性变量
        private Color _FillColor = Color.Tomato; // 多边形填充色
        private Color _BoundaryColor = Color.Black; // 多边形边界色
        private Color _TrackingColor = Color.DarkGreen; // 多边形描绘颜色
        private bool _SelfMouseWheel = true; // 接收鼠标滑轮事件时是否自动缩放

        //运行时属性变量
        private List<Polygon> _Polygons = new List<Polygon>();
        private double _DisplayScale = 1D;
        private List<Polygon> _SelectedPolygons = new List<Polygon>();

        //内部变量
        private double mOffsetX = 0;
        private double mOffsetY = 0; // 窗口左上角偏移量
        private int mMapOpstyle = 0;  //当前地图操作类型 0：无 1：放大 2：缩小 3：漫游 4：输入  5：选择
        private Polygon mTrackingPolygon = new Polygon(); //正在输入的多边形
        private PointF mMouseLocation = new PointF(); //鼠标当前位置，用于漫游 
        private PointF mStartPoint = new PointF();// 记录鼠标按下的位置，用于拉框

        //鼠标光标对象的定义
        private Cursor mCur_Cross = new Cursor(System.Reflection.Assembly.
            GetExecutingAssembly().GetManifestResourceStream("MyMapObjects.Resources.Cross.ico"));
        private Cursor mCur_ZoomIn = new Cursor(System.Reflection.Assembly.
           GetExecutingAssembly().GetManifestResourceStream("MyMapObjects.Resources.ZoomIn.ico"));
        private Cursor mCur_ZoomOut = new Cursor(System.Reflection.Assembly.
           GetExecutingAssembly().GetManifestResourceStream("MyMapObjects.Resources.ZoomOut.ico"));
        private Cursor mCur_PanUp = new Cursor(System.Reflection.Assembly.
           GetExecutingAssembly().GetManifestResourceStream("MyMapObjects.Resources.PanUp.ico"));

        //常量
        private const float mcBoundaryWidth = 1F; // 多边形边界宽度，单位像素
        private const float mcTrackingWidth = 1F;// 正在输入的多边形边界宽度，单位像素
        private const float mcVertexHandleSize = 5F;// 跟踪多边形顶点手柄大小，单位像素
        private const float mcZoomRatio = 1.2F;// 缩放系数
        private Color mcSelectingBoxColor = Color.DarkGreen;// 选择盒的颜色
        private const float mcSelectingBoxWidth = 2F;//选择盒的线宽度
        private Color mcSelectionColor = Color.Cyan;//选中要素的颜色

        #endregion

        #region 构造函数
        
        public MapControl()
        {
            
            InitializeComponent();
            this.MouseWheel += MapControl_MouseWheel;
        }


        #endregion
        #region 属性

        /// <summary>
        /// 获取或设置多边形填充色
        /// </summary>
        [Browsable(true),Description("获取或设置多边形颜色")]
        public Color FillColor
        {
            get { return _FillColor; }
            set { _FillColor = value; }
        }

        /// <summary>
        /// 获取或设置多边形边界色
        /// </summary>
        [Browsable(true), Description("获取或设置多边形边界色")]
        public Color BoundaryColor
        {
            get { return _BoundaryColor; }
            set { _BoundaryColor = value; }
        }

        /// <summary>
        /// 获取或设置跟踪图形颜色
        /// </summary>
        [Browsable(true), Description("获取或设置跟踪图形颜色")]
        public Color TrackingColor
        {
            get { return _TrackingColor; }
            set { _TrackingColor = value; }
        }

        /// <summary>
        /// 获取或设置鼠标滑轮事件时是否缩放
        /// </summary>
        [Browsable(true), Description("获取或设置鼠标滑轮事件时是否缩放")]
        public bool SelfMouseWheel
        { 
            get { return _SelfMouseWheel; }
            set { _SelfMouseWheel = value; }

        }

        /// <summary>
        /// 获取或设置多边形数组
        /// </summary>
        [Browsable(false)]
        public Polygon[] Polygons
        {
            get { return _Polygons.ToArray(); }
            set
            {
                _Polygons.Clear();
                _Polygons.AddRange(value);
            }
        }

        /// <summary>
        /// 获取或设置选中多边形数组
        /// </summary>
        [Browsable(false)]
        public Polygon[] SelectedPolygons
        {
            get { return _SelectedPolygons.ToArray(); }
            set
            {
                _SelectedPolygons.Clear();
                _SelectedPolygons.AddRange(value);
            }
        }

        /// <summary>
        /// 获取或设置显示比例尺系数
        /// </summary>
        [Browsable(false)]
        public double DisplayScale
        {
            get { return _DisplayScale; }
            set { _DisplayScale = value; }
        }
        #endregion
        #region 方法

        /// <summary>
        /// 将地图坐标转化为屏幕坐标
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public PointD FromMapPoint(PointD p)
        {
            PointD sPoint = new PointD();
            sPoint.X = (p.X - mOffsetX) / _DisplayScale;
            sPoint.Y = (p.Y - mOffsetY) / _DisplayScale;
            return sPoint;
        }

        /// <summary>
        /// 将屏幕坐标转化为地图坐标
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public PointD ToMapPoint(PointD p)
        {
            PointD sPoint = new PointD();
            sPoint.X = p.X * _DisplayScale + mOffsetX;
            sPoint.Y = p.Y * _DisplayScale + mOffsetY;
            return sPoint;
        }

        /// <summary>
        /// 以指定点进行缩放
        /// </summary>
        /// <param name="center"></param>
        /// <param name="ratio"></param>
        public void ZoomByCenter(PointD center, double ratio)
        {
            double sDisPlayScale;
            sDisPlayScale = _DisplayScale / ratio;
            double sOffsetX; double sOffsetY;
            sOffsetX = mOffsetX + (1 - 1 / ratio) * (center.X - mOffsetX);
            sOffsetY = mOffsetY + (1 - 1 / ratio) * (center.Y - mOffsetY);
            mOffsetX = sOffsetX;
            mOffsetY = sOffsetY;
            _DisplayScale = sDisPlayScale;

            //  触发事件
            DisplayScaleChanged?.Invoke(this);
        }

        /// <summary>
        /// 将地图操作设置为放大状态
        /// </summary>
        public void ZoomIn()
        {
            mMapOpstyle = 1;
            this.Cursor = mCur_ZoomIn;
        }

        /// <summary>
        /// 将地图操作设置为缩小状态
        /// </summary>
        public void ZoomOut()
        {
            mMapOpstyle = 2;
            this.Cursor = mCur_ZoomOut;
        }

        /// <summary>
        /// 将地图操作设置为漫游状态
        /// </summary>
        public void Pan()
        {
            mMapOpstyle = 3;
            this.Cursor = mCur_PanUp;
        }

        /// <summary>
        /// 将地图操作设置为输入多边形状态
        /// </summary>
        public void TrackingPolygon()
        {
            mMapOpstyle = 4;
            this.Cursor = mCur_Cross;
        }
        /// <summary>
        /// 将地图操作设置为选择要素状态
        /// </summary>
        public void SelectFeatures()
        {
            mMapOpstyle = 5;
            this.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// 增加一个多边形
        /// </summary>
        /// <param name="ply"></param>
        public void AddPolygon(Polygon ply)
        {
            _Polygons.Add(ply);
        }
        /// <summary>
        /// 返回选中的多边形集合
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public Polygon[] SelectByBox (RectangeD box) {
            List<Polygon> sSels = new List<Polygon>();
            int polyCount = _Polygons.Count;
            for (int i = 0; i < polyCount; i++) {
                if (MapTools.IsPolygonWithinBox(_Polygons[i], box) == true) {
                    sSels.Add(_Polygons[i]);
                }
            }
            return sSels.ToArray();//返回选中的多边形集合
        }



        #endregion
        #region 事件

        public delegate void TrackingFinishedHandle(object sender, Polygon polygon);
        /// <summary>
        /// 用户输入多边形完毕
        /// </summary>
        public event TrackingFinishedHandle TrackingFinished;

        public delegate void DisplayScaleChangedHandle(object sender);

        /// <summary>
        /// 显示比例尺发生了变化
        /// </summary>
        public event DisplayScaleChangedHandle DisplayScaleChanged;

        public delegate void SelectingFinishedHandle(object sender, RectangeD box);
        
        public event SelectingFinishedHandle SelectingFinished;

        #endregion

        #region 私有函数

        /// <summary>
        /// 绘制所有多边形
        /// </summary>
        /// <param name="g"></param>
        private void drawPolygons (Graphics g) {
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int sPolyConut = _Polygons.Count;
            SolidBrush sPolyBrush = new SolidBrush(_FillColor);
            Pen sPolyPen = new Pen(_BoundaryColor, mcBoundaryWidth);
            for (int i = 0; i < sPolyConut; i++) {
                int sPointCount = _Polygons[i].PointCount;
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (int j = 0; j < sPointCount; j++) {
                    PointD sScreenPoint = FromMapPoint(_Polygons[i].GetPoint(j));
                    sScreenPoints[j].X = (float)sScreenPoint.X;
                    sScreenPoints[j].Y= (float)sScreenPoint.Y;

                }
                g.FillPolygon(sPolyBrush, sScreenPoints);
                g.DrawPolygon(sPolyPen, sScreenPoints);

            }
            sPolyBrush.Dispose();//释放资源
            sPolyPen.Dispose();
        }
        //绘制跟踪多边形
        private void drawTrackingPolygon (Graphics g) {
            int sPointCount = mTrackingPolygon.PointCount;
            if (sPointCount == 0) {
                return;
            }
            //1,绘制多边形的所有边
            Pen sTrackingPen = new Pen(_TrackingColor, mcTrackingWidth);
            PointF[] sScreenPoints = new PointF[sPointCount];
            for (int i = 0; i < sPointCount; i++) {
                PointD sScreenPoint = FromMapPoint(mTrackingPolygon.GetPoint(i));
                sScreenPoints[i].X = (float)sScreenPoint.X;
                sScreenPoints[i].Y = (float)sScreenPoint.Y;

            }
            if (sPointCount > 1) {
                g.DrawLines(sTrackingPen, sScreenPoints);
            }
            //2，绘制顶点手柄
            SolidBrush sVertexBrush = new SolidBrush(_TrackingColor);
            for (int i = 0; i < sPointCount; i++) {
                RectangleF sRect = new RectangleF(sScreenPoints[i].X - mcVertexHandleSize / 2, sScreenPoints[i].Y - mcVertexHandleSize / 2, mcVertexHandleSize, mcVertexHandleSize);
                g.FillRectangle(sVertexBrush, sRect);
            }
            //3,绘制橡皮筋
            if (mMapOpstyle == 4) {//绘制多边形状态下
                if (sPointCount == 1) {//只有一个顶点，绘制一条橡皮筋
                    g.DrawLine(sTrackingPen, sScreenPoints[0], mMouseLocation);
                }
                else {
                    g.DrawLine(sTrackingPen, sScreenPoints[0], mMouseLocation);
                    g.DrawLine(sTrackingPen, sScreenPoints[sPointCount-1], mMouseLocation);
                }
            }
            sTrackingPen.Dispose();
            sVertexBrush.Dispose();

        }

        /// <summary>
        /// 绘制选中的多边形集合
        /// </summary>
        /// <param name="g"></param>
        private void drawSelectedPolys (Graphics g) {
            int sPolysCount = _SelectedPolygons.Count;
            Pen sPolyPen = new Pen(mcSelectionColor, 2);
            for(int i = 0;i < sPolysCount; i++){
                int sPoiCount = _SelectedPolygons[i].PointCount;
                PointF[] sSelPoints = new PointF[sPoiCount];
                for (int j = 0; j < sPoiCount; j++) {
                    PointD spwd = FromMapPoint(_SelectedPolygons[i].Points[j]);
                    sSelPoints[j].X = (float)spwd.X;
                    sSelPoints[j].Y = (float)spwd.Y;
                }
                g.DrawPolygon(sPolyPen,sSelPoints);

            }
            sPolyPen.Dispose();
        }


        #endregion

        #region 控件母版事件处理
        private void MapControl_Paint (object sender, PaintEventArgs e) {
            drawPolygons(e.Graphics);//绘制所有多边形
            drawSelectedPolys(e.Graphics);//
            drawTrackingPolygon(e.Graphics);//绘制追踪多边形
        }

        

        private void MapControl_MouseDown (object sender, MouseEventArgs e) {
            switch (mMapOpstyle) {
                case 0:
                    break;
                case 1:  //放大
                    if (e.Button == MouseButtons.Left) {
                        PointD sMouseLocPoi = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocPoi);
                        ZoomByCenter(sPoint, mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 2:   //缩小
                    if (e.Button == MouseButtons.Left) {
                        PointD sMouseLocPoi = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocPoi);
                        ZoomByCenter(sPoint, 1/mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 3:   //漫游
                    if (e.Button == MouseButtons.Left) {
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    Refresh();
                    break;
                case 4:    //输入多边形
                    if (e.Button==MouseButtons.Left && e.Clicks == 1) {
                        PointD sScreenPoint = new PointD(e.Location.X, e.Location.Y);
                        PointD sMapPoint = ToMapPoint(sScreenPoint);
                        mTrackingPolygon.AddPoint(sMapPoint);
                        Refresh();//刷新
                    }


                    break;
                case 5:   //选择
                    if (e.Button == MouseButtons.Left && e.Clicks == 1) {
                        mStartPoint = e.Location;
                    }



                    break;
            }
        }
        
        //鼠标滑轮 事件
        private void MapControl_MouseWheel (object sender, MouseEventArgs e) {
            if (_SelfMouseWheel == true) {
                if (e.Delta>0) {//e.Delta 鼠标滑动步长
                    //  >0 向前滚动  放大
                    PointD sCenterPoi = new PointD(this.ClientSize.Height/2,this.ClientSize.Width/2);
                    PointD sCenterDisplay = ToMapPoint(sCenterPoi);
                    ZoomByCenter(sCenterDisplay, mcZoomRatio);
                    Refresh(); //少了这句就不动了，所有要写好
                }
                else { //缩小
                    PointD sCenterPoi = new PointD(this.ClientSize.Height/2, this.ClientSize.Width/2);
                    PointD sCenterDisplay = ToMapPoint(sCenterPoi);
                    ZoomByCenter(sCenterDisplay, 1/mcZoomRatio);
                    Refresh();
                }
            }
        }
        
        private void MapControl_MouseMove (object sender, MouseEventArgs e) {
            switch (mMapOpstyle) {
                case 0:
                    break;
                case 1:  //放大
                    break;
                case 2:   //缩小
                    break;
                case 3:   //漫游
                    if (e.Button == MouseButtons.Left) {
                        PointD sPreMouseLoc = new PointD(mMouseLocation.X, mMouseLocation.Y);
                        PointD sCurMouseLoc = new PointD(e.Location.X, e.Location.Y);
                        PointD sCurMapPoi = ToMapPoint(sCurMouseLoc);
                        PointD sPreMousePoi = ToMapPoint(sPreMouseLoc);
                        //修改offset
                        mOffsetX = mOffsetX + sPreMousePoi.X - sCurMapPoi.X;
                        mOffsetY = mOffsetY + sPreMousePoi.Y - sCurMapPoi.Y;

                        Refresh();
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    break;
                case 4:    //输入多边形
                    mMouseLocation.X = e.Location.X;
                    mMouseLocation.Y = e.Location.Y;

                    Refresh();

                    break;
                case 5:   //选择
                    if (e.Button == MouseButtons.Left) {
                        Refresh(); //在框选移动时，刷新
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        Pen sBoxPen = new Pen(mcSelectingBoxColor, mcSelectingBoxWidth);
                        float s_min_x = Math.Min(mStartPoint.X, e.Location.X);
                        float s_max_x = Math.Max(mStartPoint.X, e.Location.X);
                        float s_min_y = Math.Min(mStartPoint.Y, e.Location.Y);
                        float s_max_y = Math.Max(mStartPoint.Y, e.Location.Y);

                        g.DrawRectangle(sBoxPen, s_min_x, s_min_y,s_max_x- s_min_x,  s_max_y-s_min_y);
                        g.Dispose();
                    }
                    
                   break;
            }
        }

        private void MapControl_MouseDoubleClick (object sender, MouseEventArgs e) {
            switch (mMapOpstyle) {
                case 0:
                    break;
                case 1:  //放大
                    break;
                case 2:   //缩小
                    break;
                case 3:   //漫游
                    break;
                case 4:    //输入多边形
                    if (e.Button == MouseButtons.Left) {
                        if (mTrackingPolygon.PointCount >= 3) {
                            Polygon sTrackingPoly = mTrackingPolygon.Clone();
                            mTrackingPolygon.Clear();
                            
                            //if (TrackingFinished != null) 
                                //TrackingFinished(this, sTrackingPoly);
                            
                            TrackingFinished?.Invoke(this, sTrackingPoly);//触发事件
                        }
                    } 


                    break;
                case 5:   //选择
                    break;
            }
        }

        

        private void MapControl_MouseUp (object sender, MouseEventArgs e) {
            switch (mMapOpstyle) {
                case 0:
                    break;
                case 1:  //放大
                    break;
                case 2:   //缩小
                    break;
                case 3:   //漫游
                    break;
                case 4:    //输入多边形
                    break;
                case 5:   //选择
                    if (e.Button == MouseButtons.Left) {
                        double sMinX = Math.Min(mStartPoint.X, e.Location.X);
                        double sMaxX = Math.Max(mStartPoint.X, e.Location.X);
                        double sMinY = Math.Min(mStartPoint.Y, e.Location.Y);
                        double sMaxY = Math.Max(mStartPoint.Y, e.Location.Y);
                        PointD sTopLeft = new PointD(sMinX, sMinY);
                        PointD sButtonRight = new PointD(sMaxX, sMaxY);
                        //变成地图坐标
                        PointD sTopLeftm = ToMapPoint(sTopLeft);
                        PointD sButtonRightm = ToMapPoint(sButtonRight);

                        RectangeD sSelBox = new RectangeD(sTopLeftm.X, sButtonRightm.X,sTopLeftm.Y,sButtonRightm.Y);

                        Refresh();

                        SelectingFinished?.Invoke(this, sSelBox);

                    }
                    break;
            }



        }

        #endregion
    }
}
