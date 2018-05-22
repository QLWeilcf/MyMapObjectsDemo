using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects {
    public class RectangeD {
        //注意自己写的是 RectangeD 不是 RectangleD
        #region 字段
        private double _minX, _maxX, _minY, _maxY;


        #endregion
        #region 构造函数
        public RectangeD (double min_x,double max_x,double min_y,double max_y) {
            if (min_x > max_y || min_y > max_y)
                throw new Exception("Inv Rectange");
                _minX = min_x;
                _maxX = max_x;
                _minY = min_y;
                _maxY = max_y;
            
        }
        #endregion

        #region 属性
        public double MinX {//获取最小x坐标
            get {
                return _minX;
            }//只读，不允许写/改
        }
        public double MaxX {
            get {
                return _maxX;
            }//只读，不允许写
        }
        public double MinY {
            get {
                return _minY;
            }//只读，不允许写
        }
        public double MaxY {
            get {
                return _maxY;
            }//只读，不允许写
        }
        /// <summary>
        /// 获取矩形的宽度
        /// </summary>
        public double Width {//获取宽度
            get {
                return _maxX - _minX;
            }
        }
        public double Height {//获取矩形高度
            get {
                return _maxY - _minY;
            }
        }
        #endregion



    }
}
