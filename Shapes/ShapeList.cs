using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    public class ShapeList : List<Shape>
    {
        public ShapeList() : base() { }

        public ShapeList(int capacity) : base(capacity) { }

        public ShapeList(IEnumerable<Shape> collection) : base(collection) { }

        public ShapeList(params Shape[] shape) : base()
        {
            for(int i=0; i<shape.Length;i++)
            {
                Add(shape[i]);
            }
        }

        public int SpaceNeeds()
        {
            int sum = 0;
            foreach(Shape shape in this)
            {
                sum += shape.Area;
            }
            return sum;
        }

        public Shape FindCloseArea(int area)
        {
            if (Count > 0)
            {
                int sum = Math.Abs(area - this[0].Area);
                Shape shapeRe = this[0];
                foreach (Shape shape in this)
                {
                    int temp = Math.Abs(area - shape.Area);
                    if (sum > temp)
                    {
                        sum = temp;
                        shapeRe = shape;
                    }
                }
                return shapeRe;
            }
            return null;
        }

        public void DrawShapes(Graphics g)
        {
            foreach (Shape shape in this) shape.DrawShape(g);
        }

        public void DrawShapes(Graphics g, ShapeStyle shapeStyle)
        {
            foreach (Shape shape in this) shape.DrawShape(g, shapeStyle);
        }

        public override string ToString()
        {
            StringBuilder shapesStr = new StringBuilder("the shapes:");
            shapesStr.AppendLine();
            foreach (Shape shape in this) shapesStr.AppendLine(shape.ToString());
            return shapesStr.ToString();
        }
    }
}
