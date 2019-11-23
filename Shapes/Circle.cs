using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Elipsa
    {
        public Circle() : base() { }

        public Circle(Color color) : base(color) { }

        public Circle(Color color, Point location) : base(color, location) { }

        public Circle(Color color, Point location, int r) : base(color, location, new Size(r*2,r*2)) { }

        public Circle(Color color, int x, int y, int r) : this(color, new Point(x, y), r) { }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Circle;
            }
        }

        public int Radius
        {
            get
            {
                return WidthPen/2;
            }

            set
            {
                WidthPen = value * 2;
            }
        }

        public override int WidthPen
        {
            get
            {
                return base.WidthPen;
            }

            set
            {
                base.WidthPen = base.Height = value;
            }
        }

        public override int Height
        {
            get
            {
                return base.Height;
            }

            set
            {
                WidthPen = value;
            }
        }

        protected override Shape Clone()
        {
            return new Circle();
        }
    }
}
