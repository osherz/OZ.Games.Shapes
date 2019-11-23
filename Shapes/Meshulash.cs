using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class MeshulashYashar : ShapeConst 
    {
        public MeshulashYashar() : base() { }

        public MeshulashYashar(Color color) : base(color) { }

        public MeshulashYashar(Color color, Point location) : base(color, location) { }

        public MeshulashYashar(Color color, Point location, Size size) : base(color, location, size) { }

        public MeshulashYashar(Color color, int x, int y) : base(color, x, y) { }

        public MeshulashYashar(Color color, int x, int y, Size size) : base(color, x,y, size) { }

        public MeshulashYashar(Color color, Point location, int width, int height) : base(color, location, width, height) { }

        public MeshulashYashar(Color color, int x, int y, int width, int height) : base(color, x, y, width, height) { }

        public override int Area
        {
            get
            {
                return base.Area / 2;
            }
        }

        public override Point Location
        {
            get
            {
                return base.Location;
            }

            set
            {
                base.Location = value;
                pointList.Add(new Point(Left + WidthPen, Top));
                pointList.Add(new Point(Left, Top + Height));
            }
        }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Meshulash;
            }
        }

        protected override Shape Clone()
        {
            return new MeshulashYashar();
        }

        protected override void Draw(Graphics g)
        {
            g.DrawPolygon(Pen, pointList.ToArray());
        }

        protected override void DrawFill(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color), pointList.ToArray());
        }
    }
}
