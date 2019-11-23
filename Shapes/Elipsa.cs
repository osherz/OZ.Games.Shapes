using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Elipsa : ShapeConst
    {
        public Elipsa() : base()
        {
        }

        public Elipsa(Color color) : base(color) { }

        public Elipsa(Color color, Point location) : base(color, location) { }

        public Elipsa(Color color, Point location, Size size) : base(color, location, size) { }

        public Elipsa(Color color, int x, int y) : base(color, x, y) { }

        public Elipsa(Color color, int x, int y, Size size) : base(color, x, y, size) { }

        public Elipsa(Color color, Point location, int width, int height) : base(color, location, width, height) { }

        public Elipsa(Color color, int x, int y, int width, int height) : base(color, x, y, width, height) { }

        public override int Area
        {
            get
            {
                return (int)(Math.PI * base.Area);
            }
        }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Elipsa;
            }
        }

        /// <summary>
        /// יותר צורה חדשה עם אותן הפרטים במיקום שונה ומחזיר אותה
        /// </summary>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        protected override void DrawFill(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color), Rect);
        }

        protected override void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, Rect);

        }

        protected override Shape Clone()
        {
            return new Elipsa();
        }
    }
}
