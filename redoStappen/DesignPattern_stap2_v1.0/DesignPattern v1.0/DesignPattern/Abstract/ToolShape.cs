using System;
using System.Windows.Forms;
using System.Drawing;


namespace DesignPattern {
	abstract class ToolShape : DesignPattern.ToolBase {
        protected Cursor Cursor { get; set; }
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e) {
           
            drawArea.GraphicsList[0].Normalize();
            drawArea.AddCommand(new Add(drawArea.GraphicsList[0]));
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
