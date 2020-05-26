using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace DesignPattern {
	abstract class DrawObject {
        public bool Selected { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public int ID { get; set; }

        public DrawObject() { }
        protected void Initialize() {
            Color = Color.Black;
            PenWidth = 1; }
        public virtual void Draw(Graphics g) { }
        public virtual void Move(int deltaX, int deltaY) { }
        public virtual void MoveHandleTo(Point point, int handleNumber) { }
        public virtual void Normalize() { }

        public virtual Rectangle GetHandleRectangle(int handleNumber) {
            Point point = GetHandlePosition(handleNumber);
            return new Rectangle(point.X - 3, point.Y - 3, 7, 7); }

        public virtual void DrawTracker(Graphics g) {
            if (!Selected) return;
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int i = 1; i <= HandleCount; i++) {
                g.FillEllipse(brush, GetHandleRectangle(i)); }
            brush.Dispose(); }

        public virtual int HandleCount { get { return 0; } }
        public virtual Point GetHandlePosition(int handleNumber) { return new Point(0, 0); }
        public virtual int HitTest(Point point) { return -1; }
        public virtual bool PointInObject(Point point) { return false; }
        public virtual Cursor GetHandleCursor(int handleNumber) { return Cursors.Default; }
        public virtual bool IntersectsWith(Rectangle rectangle) { return false; }
    }
}
