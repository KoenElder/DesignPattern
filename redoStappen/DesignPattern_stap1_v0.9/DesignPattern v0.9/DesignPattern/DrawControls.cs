using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace DesignPattern
{
	/// <summary>
	/// Rectangle graphic object
	/// </summary>
	class DrawControls : DrawObject
	{
        private Rectangle rectangle;
        protected Rectangle Rectangle { get { return rectangle; } set { rectangle = value; } }
        protected void SetRectangle(int x, int y, int width, int height) { rectangle = new Rectangle(x, y, width, height); }

        public override int HandleCount { get { return 8; } }

        public override Point GetHandlePosition(int handleNumber) {
            switch ( handleNumber ) { 
                case 2: return new Point(rectangle.X + rectangle.Width / 2, rectangle.Y);
                case 3: return new Point(rectangle.Right, rectangle.Y);
                case 4: return new Point(rectangle.Right, rectangle.Y + rectangle.Height / 2);
                case 5: return new Point(rectangle.Right, rectangle.Bottom);
                case 6: return new Point(rectangle.X + rectangle.Width / 2, rectangle.Bottom);
                case 7: return new Point(rectangle.X, rectangle.Bottom);
                case 8: return new Point(rectangle.X, rectangle.Y + rectangle.Height / 2); }
            return new Point(rectangle.X, rectangle.Y); }

        public override int HitTest(Point point) {
            if ( Selected ) {
                for ( int i = 1; i <= HandleCount; i++ ) {
                    if ( GetHandleRectangle(i).Contains(point) )
                        return i; } }
            if ( PointInObject(point) ) return 0;
            return -1; }


        public override bool PointInObject(Point point) { return rectangle.Contains(point); }
        
        public override Cursor GetHandleCursor(int handleNumber) {
            switch ( handleNumber ) {
                case 1: return Cursors.SizeNWSE;
                case 2: return Cursors.SizeNS;
                case 3: return Cursors.SizeNESW;
                case 4: return Cursors.SizeWE;
                case 5: return Cursors.SizeNWSE;
                case 6: return Cursors.SizeNS;
                case 7: return Cursors.SizeNESW;
                case 8: return Cursors.SizeWE;
                default: return Cursors.Default; }
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = Rectangle.Left;
            int top = Rectangle.Top;
            int right = Rectangle.Right;
            int bottom = Rectangle.Bottom;

            switch ( handleNumber )
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }

            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle rectangle) {
            return Rectangle.IntersectsWith(rectangle); }

        public override void Move(int deltaX, int deltaY) {
            rectangle = new Rectangle(rectangle.X += deltaX, rectangle.Y += deltaY, rectangle.Width, rectangle.Height); }

        /// <summary>
        /// Normalize rectangle
        /// </summary>
        public override void Normalize() {
            rectangle = DrawControls.GetNormalizedRectangle(rectangle); }

        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if ( x2 < x1 )
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if ( y2 < y1 )
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }
    }
}
