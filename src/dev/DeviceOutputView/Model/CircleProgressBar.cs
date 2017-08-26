using System;
using System.Windows;
using System.Windows.Media;

namespace ProgressBar
{
    public class CircleProgressBar
    {
        /// <summary>周角( 360°)</summary>
        private const Double ROUND_ANGLE = 360d;
        /// <summary>平角( 180°)</summary>
        private const Double STRAIGHT_ANGLE = 180d;
        /// <summary>直角( 90°)</summary>
        private const Double RIGHT_ANGLE = 90d;
        /// <summary>端の値</summary>
        private const Double END_OFFSET = 0.01;

        /// <summary>
        /// コントロールの描画設定
        /// </summary>
        /// <param name="element">設定するコントロール</param>
        /// <param name="value">0～100の数値</param>
        /// <param name="isFront">前景(true)/背景(false)</param>
        public static void SetValue(ref System.Windows.Shapes.Path element,
                                    Double value, Boolean isFront)
        {
            Double thick = element.StrokeThickness / 2d;
            Double angle = CalcAngle(value);
            var fig = new System.Windows.Media.PathFigure()
            {   // 開始点の設定
                StartPoint = new Point(
                    element.Width / 2,
                    element.Height - thick)//下側から円を描く
            };
            
            Double radius = (element.Width / 2) - thick;    // 半径
            var endPoint = CalcEndPoint(angle, radius);     // 終了点
            Boolean isLargeArcFlg = angle >= STRAIGHT_ANGLE;

            // 描画コントロールの作成
            var seg = new ArcSegment()
            {
                Point = new Point(endPoint.X + thick, endPoint.Y + thick),
                Size = new Size(radius, radius),
                IsLargeArc = isFront ? isLargeArcFlg : !isLargeArcFlg,
                SweepDirection = isFront ? SweepDirection.Clockwise
                                         : SweepDirection.Counterclockwise,
                RotationAngle = 0,
            };

            // コントロールの設定
            fig.Segments.Clear();
            fig.Segments.Add(seg);
            element.Data = new PathGeometry(new PathFigure[] { fig });
        }

        /// <summary>
        /// 0 ～ 100 の値を角度へ変換
        /// </summary>
        /// <param name="value"></param>
        private static Double CalcAngle(Double value)
        {
            Double result = 0d;
            Double angle = Math.Floor(value) * 3.60;
            if(angle <= 0)
            {
                result = END_OFFSET;
            }
            else if(angle >= 360)
            {
                result = (ROUND_ANGLE - END_OFFSET);
            }
            else
            {
                result = angle;
            }
            return result;
        }

        /// <summary>
        /// 終了点の座標計算
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="radius"></param>
        private static Point CalcEndPoint(Double angle, Double radius)
        {
            Double radian = Math.PI * (angle + RIGHT_ANGLE) / 180;
            Double x = radius + radius * Math.Cos(radian);
            Double y = radius + radius * Math.Sin(radian);
            return new Point(x, y);
        }
    }
}
