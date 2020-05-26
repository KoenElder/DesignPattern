using System;
using System.Windows.Forms;
using System.Drawing;


namespace DesignPattern {
	abstract class ToolObject : DesignPattern.Tool {
        protected Cursor Cursor { get; set; }
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e) {
            drawArea.GraphicsList[0].Normalize();
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;
            drawArea.Capture = false;
            drawArea.Refresh(); }

        protected void AddNewObject(DrawArea drawArea, DrawObject o) {
            drawArea.GraphicsList.UnselectAll();
            o.Selected = true;
            drawArea.GraphicsList.Add(o);
            drawArea.Capture = true;
            drawArea.Refresh(); } }
}
