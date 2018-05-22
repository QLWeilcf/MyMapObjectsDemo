using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    /// <summary>
    /// 多边形
    /// </summary>
    
    public class Polygon
    {
        #region  字段

        private List<PointD> _Points = new List<PointD>();   //顶点集合

        #endregion
        #region 构造函数

        public Polygon()
        { }

        public Polygon(PointD[]points)
        {
            _Points.AddRange(points);

        }

        #endregion
        #region 属性

        /// <summary>
        /// 获取或者设置顶点集合
        /// </summary>
        public PointD[] Points
        {
            get { return _Points.ToArray(); }
            set
            {
                _Points.Clear();
                _Points.AddRange(value);
            }
        }

        /// <summary>
        /// 获取顶点数目
        /// </summary>
        
        public int PointCount
        {
            get { return _Points.Count; }
        }
        #endregion
        #region 方法

        /// <summary>
        /// 获取指定索引号的顶点
        /// </summary>
        /// <param name="index" 索引号，从0开始</param>
        /// <returns></returns>
       
        public PointD GetPoint(int index)
        {
            return _Points[index];
        }

        /// <summary>
        /// 增加一个顶点
        /// </summary>
        
        public void AddPoint(PointD point)
        {
            _Points.Add(point);
        }

        /// <summary>
        /// 清除所有顶点
        /// </summary>
        
        public void Clear()
        {
            _Points.Clear();
        }

        /// <summary>
        /// 复制
        /// </summary>
       
        public Polygon Clone()
        {
            Polygon sPolygon = new Polygon();   //新建多边形对象
            int sPolygonCount = _Points.Count;   //顶点数目
            for( int i=0; i < sPolygonCount; i++) //复制所有顶点
            {
                PointD sPoint = new PointD(_Points[i].X, _Points[i].Y);
                sPolygon.AddPoint(sPoint);
            }
            return sPolygon;      //返回新建的多边形
        }

        #endregion
    }
}
