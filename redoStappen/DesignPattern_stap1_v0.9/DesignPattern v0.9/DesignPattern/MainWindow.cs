using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace DesignPattern{
    partial class MainWindow : Form {
        private DrawArea drawArea;
        public MainWindow() { InitializeComponent(); }
        private void MainForm_Load(object sender, EventArgs e) {
            // Create draw area
            drawArea = new DrawArea();
            drawArea.Location = new System.Drawing.Point(0, 0);
            drawArea.Size = new System.Drawing.Size(10, 10);
            drawArea.Owner = this;
            this.Controls.Add(drawArea);
            drawArea.Initialize(this);
            ResizeDrawArea();
            // Submit to Idle event to set controls state at idle time
            Application.Idle += delegate (object o, EventArgs a) {
                SetStateOfControls(); }; }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized && drawArea != null)
                ResizeDrawArea(); }

        void MainForm_DropDownOpened(object sender, EventArgs e) {
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer; }

        public void SetStateOfControls() {
            toolStripButtonPointer.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            toolStripButtonRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            toolStripButtonEllipse.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            bool objects = (drawArea.GraphicsList.Count > 0);
            bool selectedObjects = (drawArea.GraphicsList.SelectionCount > 0); }

        private void ResizeDrawArea() {
            Rectangle rect = this.ClientRectangle;
            drawArea.Left = rect.Left;
            drawArea.Top = rect.Top;
            drawArea.Width = rect.Width;
            drawArea.Height = rect.Height; }

        private void toolStripButtonPointer_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Pointer; }
        private void toolStripButtonRectangle_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Rectangle; }
        private void toolStripButtonEllipse_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Ellipse; }
    }
}