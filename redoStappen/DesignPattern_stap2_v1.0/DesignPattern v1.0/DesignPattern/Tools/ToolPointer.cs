using System;
using System.Windows.Forms;
using System.Drawing;


namespace DesignPattern {
	class ToolPointer : DesignPattern.ToolBase {
        private enum SelectionMode { None, Box, Move, Size }

        private SelectionMode selectMode = SelectionMode.None;

        // Object which is currently resized:
        private DrawObject resizedObject;
        private int resizedObjectHandle;

        // Keep state about last and current point (used to move and resize objects)
        private Point previousPosition = new Point(0, 0);
        private Point mouseDownPosition = new Point(0, 0);

		public ToolPointer() {}

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs eventArgs) {
            Point mousePosition = new Point(eventArgs.X, eventArgs.Y);
            this.ResetState(drawArea, mousePosition);
            this.Check4ModeSize(drawArea, mousePosition);
            if (selectMode == SelectionMode.None) this.Check4ModeMove(drawArea, mousePosition);
            if (selectMode == SelectionMode.None) this.Check4ModeBox(drawArea, mousePosition);
            drawArea.Capture = true;
            drawArea.Refresh(); }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs eventArgs) {
            Point mousePosition = new Point(eventArgs.X, eventArgs.Y);
            Point savedPosition = previousPosition;
            int dx = eventArgs.X - previousPosition.X;
            int dy = eventArgs.Y - previousPosition.Y;
            previousPosition = mousePosition;
            switch (eventArgs.Button) {
                case MouseButtons.None: HandleControlHoveroverCursor(drawArea, mousePosition); break;
                case MouseButtons.Left:
                    switch (selectMode) {
                        case SelectionMode.Size: this.OnMoveModeSize(drawArea, mousePosition); break;
                        case SelectionMode.Move: this.OnMoveModeMove(drawArea, dx, dy); break;
                        case SelectionMode.Box: this.OnMoveModeBox(drawArea, mousePosition, savedPosition); break; } break; } }


        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs eventArgs) {
            Point mousePosition = new Point(eventArgs.X, eventArgs.Y);
            switch (selectMode) {
                case SelectionMode.Size: break;
                case SelectionMode.Move: break;
                case SelectionMode.Box: executeModeBox(drawArea, previousPosition); break; }
            this.ResetState(drawArea, mousePosition); }

        private void Check4ModeSize(DrawArea drawArea, Point mousePosition) {
            foreach (DrawObject o in drawArea.GraphicsList.Selection) {
                int handleNumber = o.HitTest(mousePosition);
                if (handleNumber > 0) {
                    selectMode = SelectionMode.Size;
                    resizedObject = o;
                    resizedObjectHandle = handleNumber;
                    drawArea.GraphicsList.UnselectAll();
                    o.Selected = true;
                    break; } } }

        private void Check4ModeMove(DrawArea drawArea, Point mousePosition) {
                int n1 = drawArea.GraphicsList.Count;
                DrawObject o = null;
                for (int i = 0; i < n1; i++) {
                    if (drawArea.GraphicsList[i].HitTest(mousePosition) == 0) {
                        o = drawArea.GraphicsList[i]; break; } }
                if (o != null) {
                    selectMode = SelectionMode.Move;
                    if ((Control.ModifierKeys & Keys.Control) == 0 && !o.Selected)
                        drawArea.GraphicsList.UnselectAll();
                    o.Selected = true;
                    drawArea.Cursor = Cursors.SizeAll; } }

        private void Check4ModeBox(DrawArea drawArea, Point mousePosition) {
            if ((Control.ModifierKeys & Keys.Control) == 0) drawArea.GraphicsList.UnselectAll();
            selectMode = SelectionMode.Box; }

        private void ResetState(DrawArea drawArea, Point mousePosition) {
            previousPosition = mouseDownPosition = mousePosition;
            selectMode = SelectionMode.None;
            resizedObject = null;
            drawArea.Capture = false;
            drawArea.Refresh(); }

        private void HandleControlHoveroverCursor(DrawArea drawArea, Point mousePosition) {
            Cursor cursor = Cursors.Default;
            for (int index = 0; index < drawArea.GraphicsList.Count; index++) {
                int control = drawArea.GraphicsList[index].HitTest(mousePosition);
                if (control > 0) {
                    cursor = drawArea.GraphicsList[index].GetHandleCursor(control);
                    break; } }
            drawArea.Cursor = cursor; }

        private void OnMoveModeSize(DrawArea drawArea, Point mousePosition) {
            if (resizedObject != null) {
                resizedObject.MoveHandleTo(mousePosition, resizedObjectHandle);
                drawArea.Refresh(); } }

        private void OnMoveModeMove(DrawArea drawArea, int dx, int dy) {
            foreach (DrawObject o in drawArea.GraphicsList.Selection) { o.Move(dx, dy); }
            drawArea.Cursor = Cursors.SizeAll;
            drawArea.Refresh(); }

        private void OnMoveModeBox(DrawArea drawArea, Point mousePosition, Point savedPosition) {
            Rectangle rectOld = DrawControls.GetNormalizedRectangle(mouseDownPosition, savedPosition);
            Rectangle rectNew = DrawControls.GetNormalizedRectangle(mouseDownPosition, mousePosition);
            ControlPaint.DrawReversibleFrame( drawArea.RectangleToScreen(rectOld), Color.Black, FrameStyle.Dashed);
            ControlPaint.DrawReversibleFrame( drawArea.RectangleToScreen(rectNew), Color.Black, FrameStyle.Dashed); }

        private void executeModeBox(DrawArea drawArea, Point previousPosition) {
            Rectangle rectOld = DrawControls.GetNormalizedRectangle(mouseDownPosition, previousPosition);
            ControlPaint.DrawReversibleFrame(drawArea.RectangleToScreen(rectOld), Color.Black, FrameStyle.Dashed);
            drawArea.GraphicsList.SelectInRectangle(DrawControls.GetNormalizedRectangle(mouseDownPosition, previousPosition));
        }
	}
}
