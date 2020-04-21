using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        int x = -1;
        int y = -1;
        int w, h;
        int clicks = 0;
        int selected = -1;
        bool moving = false;
        //Color colour;
        Pen pen;
        SolidBrush brush;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rect> shapes = new List<Rect>();
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
            brush = new SolidBrush(Color.Black);
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized; 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.LightGray;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.LightGray;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.LightGray;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }
              
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            w = e.X - x;
            h = e.Y - y;
            Rectangle rhoek = new Rectangle(x, y, w, h);            
            if(!cursorButton.Checked)
            {
                rectangles.Add(rhoek);
            }            
            if (ellipsButton.Checked)
            {
                g.DrawEllipse(pen, rhoek);
                Rect shape = new Rect(x, y, w, h, 'E', pen.Color);
                shapes.Add(shape);
            }
            if(rhoekButton.Checked)
            {
                g.DrawRectangle(pen, rhoek);
                Rect shape = new Rect(x, y, w, h, 'R', pen.Color);
                shapes.Add(shape);
            }

            moving = false;
            x = -1;
            y = -1;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {                              
                //Graphics g = panel1.CreateGraphics();
                //w = e.X - x;
                //h = e.Y - y;
                //Rectangle rhoek = new Rectangle(x, y, w, h);

                    //if (radioButton1.Checked)
                    //{
                    //    g.FillEllipse(brush, rhoek);
                    //    g.Dispose();
                    //}
                    //if (radioButton2.Checked)
                    //{
                    //    g.FillRectangle(brush, rhoek);
                    //    g.Dispose();
                    //}
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(cursorButton.Checked)
            {
                label1.Text = "";
                if (clicks == 1)
                {
                    int rw = rectangles.ElementAt(selected).Width;
                    int rh = rectangles.ElementAt(selected).Height;
                    int rx = e.X; //uit muis halen
                    int ry = e.Y;
                    moveShape(rx, ry, rw, rh);
                }
                for (int i = 0; i < rectangles.Count; i++)
                {                    
                    if (rectangles[i].Contains(e.Location))
                    {
                        if(clicks == 1)
                        {
                            clicks = 0;
                        }              
                        else
                        {
                            clicks++;
                            selected = i;
                            label1.Text = "figuur geselecteerd!";
                        }
                        break;
                    }
                }
            }            
        }

        public void moveShape(int rx, int ry, int rw, int rh)
        {
            Graphics g = panel1.CreateGraphics();
            Rectangle draw = new Rectangle(rx, ry, rw, rh);
            if (shapes.ElementAt(selected).Type == 'E')
            {
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, draw);
                Rect shape = new Rect(rx, ry, rw, rh, 'E', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            else
            {
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, draw);
                Rect shape = new Rect(rx, ry, rw, rh, 'R', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            g.Clear(BackColor);
            for (int i = 0; i < rectangles.Count(); i++)
            {
                if (shapes.ElementAt(i).Type == 'R')
                {
                    pen.Color = shapes.ElementAt(i).Colour;
                    g.DrawRectangle(pen, rectangles.ElementAt(i));
                }
                else
                {
                    pen.Color = shapes.ElementAt(i).Colour;
                    g.DrawEllipse(pen, rectangles.ElementAt(i));
                }
            }
        }
    }
}
