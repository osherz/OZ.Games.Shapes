using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public class TextShape : ShapeConst
    {
        private string text;
        private Font font;

        public TextShape() : base()
        { }

        public TextShape(string text) : base()
        {
            Text = text;
        }

        public TextShape(string text, Color color) : base(color)
        {
            Text = text;
        }

        public TextShape(string text, Color color, Font font) : this(text,color)
        {
            Font = font;
        }

        public TextShape(string text, Color color, Point location) : base(color, location) { Text = text; }

        public TextShape(string text, Color color, Point location, Font font) : this(text, color, location)
        {
            Font = font;
        }

        public TextShape(string text, Color color, int x, int y) : base(color, x, y) { Text = text; }

        public TextShape(string text, Color color, int x, int y, Font font) : this(text, color, x, y)
        {
            Font = font;
        }


        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public Font Font
        {
            get
            {
                return font;
            }

            set
            {
                font = value;
            }
        }

        /// <summary>
        /// not set in text
        /// </summary>
        public override Size Size
        {
            get
            {
                Label label = new Label();
                label.Text = Text;
                label.Font = Font;
                label.AutoSize = true;
                return label.Size;
            }

            set
            {
            }
        }

        /// <summary>
        /// not set in text
        /// </summary>
        public override int WidthPen
        {
            get
            {
                return base.WidthPen;
            }

            set
            {
            }
        }

        /// <summary>
        /// not set in text
        /// </summary>
        public override int Height
        {
            get
            {
                return base.Height;
            }

            set
            {
            }
        }

        public override ShapesNames ShapeName
        {
            get
            {
                return ShapesNames.Text;
            }
        }

        protected override void Draw(Graphics g)
        {
            DrawFill(g);
        }

        protected override void DrawFill(Graphics g)
        {
            g.DrawString(Text, Font, new SolidBrush(Color), Location);
        }

        protected override Shape Clone()
        {
            TextShape text = new TextShape(Text);
            text.Font = Font;
            return text;
        }
    }
}
