using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Line : Shape
    {
        public Line() : base()
        {
            sumOfPoints = 0;
        }

        public Line(Color color) : base(color) { }

        public Line(Color color, params Point[] points) : base(color, points) { }

        public Line(params Point[] points) : base(points) { }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Line;
            }
        }

        public Point this[int num]
        {
            get
            {
                return pointList[num];
            }

            set
            {
                pointList[num] = value;
            }
        }

        public override int Area
        {
            get
            {
                return -1;
            }
        }

        public int SumOfPoints
        {
            get
            {
                return sumOfPoints;
            }
        }

        public void AddPoint(params Point[] points)
        {
            pointList.AddRange(points);
            UpdatePointsCount();
        }

        public void InsertPoint(int index, Point point)
        {
            pointList.Insert(index, point);
            UpdatePointsCount();
        }

        public void RemovePoint(params Point[] points)
        {
            foreach (Point point in pointList)
            {
                pointList.Remove(point);
            }
            UpdatePointsCount();
        }

        protected override void DrawFill(Graphics g)
        {
            Draw(g);
        }

        protected override void Draw(Graphics g)
        {
            DrawLine(g);
        }

        public void DrawLine(Graphics g)
        {
            g.DrawLines(Pen, pointList.ToArray());
        }

        public static Region ToRegion(Point p1, Point p2, float width)
        {
            List<PointF> pointList = new List<PointF>();
            PointF p = new PointF();
            SizeF size = new SizeF(width, width);
            float m = FindShipuu(p1, p2);
            if (p1.Y>p2.Y)
            {
                p = p1;
                p1 = p2;
                p2 = Point.Round(p);
            }
            Region reg = new Region(new RectangleF(p1, size));
            for (p.Y = p1.Y+0.1f; p.Y<=p2.Y;p.Y+=0.1f)
            {
                p.X = FindXOnLine(p1, m, p.Y);
                pointList.Add(p);
                reg.Union(new RectangleF(p, size));
            }
            return reg;
        }

        public static float FindShipuu(Point p1, Point p2)
        {
            ///
            /// m = (y1 - y2) / (x1 - x2)
            ///
            float m = 0;
            try
            {
                float y = p1.Y - p2.Y;
                float x = p1.X - p2.X;
                m = y / x;
            }
            catch
            {
                m = 0;
            }         
            return m;
        }

        public static float FindXOnLine(Point p1, Point p2, float y)
        {
            ///
            ///x=(y-y2)/m + x2
            ///
            return FindXOnLine(p1, FindShipuu(p1, p1), y);
        }

        public static float FindYOnLine(Point p1, Point p2, float x)
        {
            ///
            /// y = m*x-m*x2 + y2
            ///
            return FindYOnLine(p1, FindShipuu(p1, p1), x);
        }

        public static float FindXOnLine(Point p, float m, float y)
        {
            ///
            ///x=(y-y2)/m + x2
            ///
            return (y - p.Y) / (m) + p.X;
        }

        public static float FindYOnLine(Point p, float m, float x)
        {
            ///
            /// y = m*x-m*x2 + y2
            ///
            return m * x - m * p.X + p.Y;
        }

        protected override Shape Clone()
        {
            return new Line();
        }

        public Point[] GetPoints()
        {
            return pointList.ToArray();
        }
    }
}
