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
            Application.Idle += delegate (object o, EventArgs a) { SetStateOfControls(); }; }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized && drawArea != null)
                ResizeDrawArea(); }

        void MainForm_DropDownOpened(object sender, EventArgs e) {
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer; }

        public void SetStateOfControls()
        {
            ButtonSelect.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            ButtonRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            ButtonEllipse.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);

            ButtonUndo.Enabled = drawArea.CanUndo;
            ButtonRedo.Enabled = drawArea.CanRedo;

            bool selectedObjects = (drawArea.GraphicsList.SelectionCount > 0);

            ButtonDelete.Enabled = selectedObjects;

        }

        private void ResizeDrawArea() {
            Rectangle rect = this.ClientRectangle;
            drawArea.Left = rect.Left;
            drawArea.Top = rect.Top;
            drawArea.Width = rect.Width;
            drawArea.Height = rect.Height; }

        private void command_New_Click(object sender, EventArgs e) { }
        private void command_Open_Click(object sender, EventArgs e) { }
        private void command_Save_Click(object sender, EventArgs e) { }

        private void command_Undo_Click(object sender, EventArgs e) { drawArea.Undo(); }
        private void command_Redo_Click(object sender, EventArgs e) { drawArea.Redo(); }
        private void tools_Select_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Pointer; }
        private void tools_Rectangle_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Rectangle; }
        private void tools_Ellipse_Click(object sender, EventArgs e) { drawArea.ActiveTool = DrawArea.DrawToolType.Ellipse; }

        private void tools_Delete_Click(object sender, EventArgs e) {
            Delete command = new Delete(drawArea.GraphicsList);
            if (drawArea.GraphicsList.DeleteSelection()) {
                drawArea.Refresh();
                drawArea.AddCommand(command);
            }

        }

    }
}