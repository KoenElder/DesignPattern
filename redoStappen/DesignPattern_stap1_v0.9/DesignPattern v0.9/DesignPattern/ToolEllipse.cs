using System;
using System.Windows.Forms;

namespace DesignPattern {
	class ToolEllipse : DesignPattern.ToolRectangle {
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e) {
            AddNewObject(drawArea, new DrawEllipse(e.X, e.Y, 1, 1)); } }
}
