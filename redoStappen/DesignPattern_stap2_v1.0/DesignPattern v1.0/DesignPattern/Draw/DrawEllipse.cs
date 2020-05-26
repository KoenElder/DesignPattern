using System;
using System.Windows.Forms;
using System.Drawing;

namespace DesignPattern {
	class DrawEllipse : DrawControls {
		public DrawEllipse() : this(0, 0, 1, 1) { }
        public DrawEllipse(int x, int y, int width, int height) : base() {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize(); }
        public override void Draw(Graphics g) {
            Pen pen = new Pen(Color, PenWidth);
            g.DrawEllipse(pen, DrawControls.GetNormalizedRectangle(Rectangle));
            pen.Dispose(); } }
}
