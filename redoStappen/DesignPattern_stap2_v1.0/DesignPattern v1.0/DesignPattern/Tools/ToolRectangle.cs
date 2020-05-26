using System;
using System.Windows.Forms;
using System.Drawing;


namespace DesignPattern {
	class ToolRectangle : ToolShape {
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e) {
            AddNewObject(drawArea, new DrawRectangle(e.X, e.Y, 1, 1));}

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e) {
            if ( e.Button == MouseButtons.Left ) {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            } }
	}
}
