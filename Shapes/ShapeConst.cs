using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Shapes
{
    public delegate void Draw(object obj);

    abstract public class ShapeConst : Shape, IComparable
    {
        private Size size;

        public ShapeConst() : base()
        {
            pointList.Add(new Point());
        }

        public ShapeConst(Color color) : base(color)
        {
            pointList.Add(new Point());
        }

        public ShapeConst(Color color, Point location) : base(color, location) { }

        public ShapeConst(Color color, Point location, Size size): this(color, location)
        {
            Size = size;
        }

        public ShapeConst(Color color, int x, int y) :
            this(color, new Point(x, y))
        { }

        public ShapeConst(Color color, int x, int y, Size size) :
    this(color, new Point(x, y), size)
        { }

        public ShapeConst(Color color, Point location, int width, int height) :
    this(color, location, new Size(width, height))
        { }

        public ShapeConst(Color color, int x, int y, int width, int height) :
            this(color, new Point(x, y), new Size(width, height))
        { }

        public virtual Point Location
        {
            get
            {
                return pointList[0];
            }

            set
            {
                pointList[0] = value;
            }
        }

        public virtual int Top
        {
            get
            {
                return Location.Y;
            }

            set
            {
                Location = new Point(Left, value);
            }
        }

        public virtual int Left
        {
            get
            {
                return Location.X;
            }

            set
            {
                Location = new Point(value, Top);
            }
        }

        public virtual Size Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public virtual int WidthPen
        {
            get
            {
                return Size.Width;
            }

            set
            {
                Size = new Size(value, Height);
            }
        }

        public virtual int Height
        {
            get
            {
                return Size.Height;
            }

            set
            {
                Size = new Size(WidthPen, value);
            }
        }

        public virtual Point TopLeft
        {
            get
            {
                return Location;
            }

            set
            {
                Location = value;
            }
        }

        public virtual Point TopRight
        {
            get
            {
                return new Point(BottomRight.X, TopLeft.Y);
            }

            set
            {
                Location = new Point(value.X - WidthPen, value.Y);
            }
        }

        public virtual Point BottomLeft
        {
            get
            {
                return new Point(TopLeft.X, BottomRight.Y);
            }

            set
            {
                Location = new Point(value.X, value.Y - Height);
            }
        }

        public virtual Point BottomRight
        {
            get
            {
                return Point.Subtract(Location, Size);
            }

            set
            {
                Location = new Point(value.X - WidthPen, value.Y - Height);
            }
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        public override int Area
        {
            get
            {
                return WidthPen * Height;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return Size.Equals(obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Shape CreateNewShape()
        {
            ShapeConst shape = (ShapeConst)base.CreateNewShape();
            shape.Size = Size;
            return shape;
        }

        public ShapeConst CreateNewShape(Point newLocation)
        {
            ShapeConst shape = (ShapeConst)base.CreateNewShape();
            shape.Size = Size;
            shape.Location = newLocation;
            return shape;
        }

        public override string MoreDetails()
        {
            return string.Format("location ({0},{4},{5},{6}), width: {1}, height: {2}, Shetach: {3}"
                , Location, WidthPen, Height, Area, TopRight, BottomLeft,BottomRight);
        }

        public int CompareTo(object obj)
        {
            if(obj is ShapeConst)
            {
                ShapeConst shape = (ShapeConst)obj;
                return Area - shape.Area;
            }
            return -1;
        }
    }
}
