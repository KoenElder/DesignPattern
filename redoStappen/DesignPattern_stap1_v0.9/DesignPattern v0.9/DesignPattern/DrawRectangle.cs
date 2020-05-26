using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DesignPattern {
    class DrawRectangle : DrawControls {
        public DrawRectangle() : this(0, 0, 1, 1) { }
        public DrawRectangle(int x, int y, int width, int height) : base() {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize(); }

        public override void Draw(Graphics g){
            Pen pen = new Pen(Color, PenWidth);
            pen.DashPattern = new float[] { 5, 5 };
            g.DrawRectangle(pen, DrawControls.GetNormalizedRectangle(Rectangle));
            pen.Dispose(); }
    }
}
