using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public enum ShapeStyle
    {
        fill,
        notFill
    }

    abstract public class Shape
    {
        private event Draw draw;
        protected int sumOfPoints;
        protected List<Point> pointList;
        private Pen pen;
        private bool visible;
        private ShapeStyle shapeStyle;

        public Shape()
        {
            Visible = true;
            pointList = new List<Point>();
            shapeStyle = ShapeStyle.fill;
            pen = new Pen(Color.Black);
        }

        public Shape(Color color) : this()
        {
            pen = new Pen(color);
            Color = color;
        }

        public Shape(Color color, params Point[] points) : this(points)
        {
            pen = new Pen(color);
            Color = color;
        }

        public Shape(params Point[] points) : this()
        {
            pointList.AddRange(points);
            UpdatePointsCount();
        }

        public abstract ShapesNames ShapeName
        {
            get;
        }

        public virtual bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
            }
        }

        public Color Color
        {
            get
            {
                return Pen.Color;
            }

            set
            {
                pen.Color = value;
            }
        }

        public float Width
        {
            get
            {
                return pen.Width;
            }

            set
            {
                pen.Width = value;
            }
        }

        public Pen Pen
        {
            get
            {
                return pen;
            }

            set
            {
                pen = value;
            }
        }

        public ShapeStyle ShapeStyle
        {
            get
            {
                return shapeStyle;
            }

            set
            {
                shapeStyle = value;
            }
        }

        /// <summary>
        /// Occurs when drawing
        /// </summary>
        public event Draw OnDraw
        {
            add
            {
                draw += value;
            }

            remove
            {
                draw -= value;
            }
        }

        protected void UpdatePointsCount()
        {
            sumOfPoints = pointList.Count;
        }

        public abstract int Area
        {
            get;
        }

        public override bool Equals(object obj)
        {
            if (obj is Shape)
            {
                Shape shape = (Shape)obj;
                return Color == shape.Color && pointList.Equals(pointList);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected abstract void DrawFill(Graphics g);

        protected abstract void Draw(Graphics g);

        public virtual void DrawShape(Graphics g)
        {
            DrawShape(g, ShapeStyle);
        }

        public virtual void DrawShape(Graphics g, ShapeStyle shapeStyle)
        {
            if (Visible)
            {
                switch(shapeStyle)
                {
                    case ShapeStyle.fill:
                        DrawFill(g);
                        break;
                    case ShapeStyle.notFill:
                        Draw(g);
                        break;
                }
                draw?.Invoke(this);
            }
        }

        public virtual Shape CreateNewShape()
        {
            Shape shape = Clone();
            shape.shapeStyle = ShapeStyle;
            shape.pointList = new List<Point>();
            shape.pointList.AddRange(pointList.ToArray());
            shape.sumOfPoints = sumOfPoints;
            shape.pen = (Pen)pen.Clone();
            return shape;
        }

        protected abstract Shape Clone();

        public virtual string MoreDetails()
        {
            string str = "";
            for(int i=0; i< pointList.Count;i++)
            {
                Point point = pointList[i];
                str = string.Format("P{0}{{1}:{2}}", i, point.X, point.Y);
                if (i + 1 < pointList.Count) str += " ";
            }
            return str;
        }

        public override string ToString()
        {
            return string.Format("type: {0}, {1}"
                , GetType(), MoreDetails());
        }

        public static Size SequreSize(Point Point1, Point point2, int extraSize=0)
        {
            Size size = new Size();
            size.Width = Math.Abs(Point1.X - point2.X) + extraSize;
            size.Height = Math.Abs(Point1.Y - point2.Y) + extraSize;
            return size;
        }

        public static Point HefreshPoints(Point point1, Point point2)
        {
            point1.X -= point2.X;
            point1.Y -= point2.Y;
            return point1;
        }

        public static Point FindTheTopLeftPoint(Point point1, Point point2)
        {
            if (point1.X > point2.X) point1.X = point2.X;
            if (point1.Y > point2.Y) point1.Y = point2.Y;
            return point1;
        }
    }
}
