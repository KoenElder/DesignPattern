using System;
using System.Windows.Forms;
using System.Drawing;


namespace DesignPattern {
	abstract class ToolBase {
        public virtual void OnMouseDown(DrawArea drawArea, MouseEventArgs e) { }
        public virtual void OnMouseMove(DrawArea drawArea, MouseEventArgs e) { }
        public virtual void OnMouseUp(DrawArea drawArea, MouseEventArgs e) { } }
}
