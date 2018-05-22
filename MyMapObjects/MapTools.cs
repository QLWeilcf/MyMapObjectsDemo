using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects {
    internal static class MapTools {//静态类,不能够实例化,类型下的所有函数都要声明static
        //internal 本程序集可以访问，介于public和private之间
        /// <summary>
        /// 判断指定点是否在指定矩形内
        /// </summary>
        /// <param name="poi"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static bool IsPointWiBox (PointD poi,RectangeD box) {
            if (poi.X<box.MinX|| poi.X > box.MaxX) {
                return false;
            }else if (poi.Y < box.MinY || poi.Y > box.MaxY) {
                return false;
            }
            else {//在边界上也是位于矩形内
                return true;
            }
        }

        /// <summary>
        /// 指示一个多边形是否完全位于多边形类
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        internal static bool IsPolygonWithinBox (Polygon poly, RectangeD box) {
            int poiCount = poly.PointCount;
            for (int i = 0; i < poiCount; i++) {
                //if (! IsPointWiBox(poly.GetPoint(i), box) ) {
                if (IsPointWiBox(poly.GetPoint(i), box) == false) {
                    return false;
                }
            }
            return true;
        }


    }
}
