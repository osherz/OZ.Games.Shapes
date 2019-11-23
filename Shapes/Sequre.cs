using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Sequre : ShapeConst
    {
        public Sequre() : base()
        {
        }

        public Sequre(Color color) : base(color) { }

        public Sequre(Color color, Point location) : base(color, location) { }

        public Sequre(Color color, Point location, Size size) : base(color, location, size) { }

        public Sequre(Color color, int x, int y) : base(color, x, y) { }

        public Sequre(Color color, int x, int y, Size size) : base(color, x,y, size) { }

        public Sequre(Color color, Point location, int width, int height) : base(color, location, width, height) { }

        public Sequre(Color color, int x, int y, int width, int height) : base(color, x, y, width, height) { }

        public override int Area
        {
            get
            {
                return Height * WidthPen;
            }
        }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Sequere;
            }
        }

        protected override void DrawFill(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), Rectangle.Round(Rect));
        }

        protected override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen, Rectangle.Round(Rect));
            
        }

        protected override Shape Clone()
        {
            return new Sequre();
            
        }
    }
}
