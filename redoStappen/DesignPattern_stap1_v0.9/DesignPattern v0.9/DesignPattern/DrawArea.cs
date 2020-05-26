using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DesignPattern {
    partial class DrawArea : UserControl {
        public enum DrawToolType { Pointer, Rectangle, Ellipse, NumberOfDrawTools };
       // private GraphicsList graphicsList;
//
        private Tool[] tools;
        public MainWindow Owner { get; set; }
        public DrawToolType ActiveTool { get; set; }
        public GraphicsList GraphicsList { get; set; }
        public DrawArea() { InitializeComponent(); }

        public void Initialize(MainWindow owner) {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.Owner = owner;
            ActiveTool = DrawToolType.Pointer;
            GraphicsList = new GraphicsList();
            tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
            tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            tools[(int)DrawToolType.Ellipse] = new ToolEllipse(); }

        private void DrawArea_Paint(object sender, PaintEventArgs e) {
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            if (GraphicsList != null) GraphicsList.Draw(e.Graphics);
            brush.Dispose(); }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) tools[(int)ActiveTool].OnMouseDown(this, e); }
        private void DrawArea_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
                tools[(int)ActiveTool].OnMouseMove(this, e);
            else
                this.Cursor = Cursors.Default; }
        private void DrawArea_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                tools[(int)ActiveTool].OnMouseUp(this, e);}

    }
}
