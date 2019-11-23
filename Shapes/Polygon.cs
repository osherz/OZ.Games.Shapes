using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Polygon : Line
    {
        public Polygon() : base() { }

        public Polygon(Color color) : base(color) { }

        public Polygon(Color color, params Point[] points) : base(color, points) { }

        public Polygon(params Point[] points) : base(points) { }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Polygon;
            }
        }

        protected override void DrawFill(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color), pointList.ToArray());
        }

        protected override void Draw(Graphics g)
        {
            g.DrawPolygon(Pen, pointList.ToArray());
        }

        protected override Shape Clone()
        {
            return new Polygon();
        }
    }
}
