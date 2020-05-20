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
        bool resizing = false;
        Pen pen;

        Invoker panel = new Invoker();
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized; 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

            
        }

        /// <summary>
        /// kleur van pen veranderen als je op de eerste kleur klikt, highlight bij geklikte kleur door panel3
        /// </summary>
        /// <param name="sender">picturebox1 / eerste kleurbox</param>
        /// <param name="e">data van event</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.LightGray;
        }

        /// <summary>
        /// kleur van pen veranderen als je op de tweede kleur klikt, highlight bij geklikte kleur door panel4
        /// </summary>
        /// <param name="sender">picturebox2 / tweede kleurbox</param>
        /// <param name="e">data van event</param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.LightGray;
        }

        /// <summary>
        /// kleur van pen veranderen als je op de derde kleur klikt, highlight bij geklikte kleur door panel5
        /// </summary>
        /// <param name="sender">picturebox3 / derde kleurbox</param>
        /// <param name="e">data van event</param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.LightGray;
        }

        /// <summary>
        /// kleur van pen veranderen als je op de vierde kleur klikt, highlight bij geklikte kleur door panel6
        /// </summary>
        /// <param name="sender">picturebox4 / vierde kleurbox</param>
        /// <param name="e">data van event</param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            panel3.BackColor = Color.LightGray;
            panel4.BackColor = Color.LightGray;
            panel5.BackColor = Color.LightGray;
            panel6.BackColor = Color.Black;
        }

        /// <summary>
        /// zet moving op true en slaat muiscoördinaten startpunt op
        /// </summary>
        /// <param name="sender">panel1 / tekenvlak</param>
        /// <param name="e">(muis)data van event</param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }
              
        /// <summary>
        /// kijkt wat voor vorm getekend moet worden en (her)tekent deze, zet moving weer op false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            w = e.X - x;
            h = e.Y - y;
            //maakt vorm van afgelegde afstand
            Rectangle rhoek = new Rectangle(x, y, w, h);            
            if(!cursorButton.Checked)
            {
                //als de cursor niet wordt gebruikt, wordt de vorm opgeslagen
                panel.InsertInRectangles(rhoek);
            }
            if (ellipsButton.Checked)
            {
                //als ellips is geselecteerd, wordt de vorm getekent en opgeslagen als ellips
                Receiver shape = new Ellips(x, y, w, h, pen.Color);
                Command drawCommand = new DrawCommand(shape);
                //panel = new Invoker(drawCommand);
                panel.SetCommand(drawCommand);
                panel.Execute(g);

                panel.InsertInShapes(shape);

                int count = panel.GetRectangleCount();
                for (int i = 0; i < count; i++)
                {
                    Rectangle RectI = panel.GetRectangle(i);
                    if (RectI.Contains(rhoek.Location))
                    {
                        Receiver ShapeI = panel.GetShape(i);
                        ShapeI.AddChild(shape);
                    }
                }
            }
            if(rhoekButton.Checked)
            {
                //als rechthoek is geselcteerd, wordt de vorm getekent en opgeslagen als rechthoek
                
                Rect shape = new Rect(x, y, w, h, pen.Color);
                //Rect shape = new Rect(x, y, w, h, pen.Color);
                Command drawCommand = new DrawCommand(shape);
                //panel = new Invoker(drawCommand);
                panel.SetCommand(drawCommand);
                panel.Execute(g);

                panel.InsertInShapes(shape);

                int count = panel.GetRectangleCount();
                for (int i = 0; i < count; i++)
                {
                    Rectangle RectI = panel.GetRectangle(i);
                    if (RectI.Contains(rhoek.Location))
                    {
                        Receiver ShapeI = panel.GetShape(i);
                        ShapeI.AddChild(shape);
                    }
                }
            }
            if (cursorButton.Checked)
            {
                //---------  R E S I Z E ----------//

                //als de cursor en een vorm zijn geselecteerd, wordt de vorm hertekent(resize)
                if (clicks == 1 && resizing == true)
                {
                    Visitor resizeVisitor = new ResizeVisitor();
                    Receiver selectedShape = panel.GetShape(selected);
                    Rectangle selectedRect = panel.GetRectangle(selected);
                    int rhoekX = selectedRect.X;
                    int rhoekY = selectedRect.Y;
                    int rhoekW = selectedRect.Width;
                    int rhoekH = selectedRect.Height;
                    int newW = rhoekW + w;
                    int newH = rhoekH + h;
                    Rectangle draw = new Rectangle(rhoekX, rhoekY, newW, newH);

                    selectedShape.Accept(resizeVisitor, selected, draw, panel);
                    redrawShapes();

                    resizing = false;
                    clicks = 0;
                    label1.Text = "";
                    label2.Text = "";
                }
            }
            moving = false;
            x = -1;
            y = -1;
        }

        /// <summary>
        /// zet bij beweging van muis resizing op true (anders wordt de vorm verplaatst ipv resized)
        /// </summary>
        /// <param name="sender">panel1 / tekenvlak</param>
        /// <param name="e">(muis)data van event</param>
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (moving && x != -1 && y != -1)
            {
                if (cursorButton.Checked)
                {
                    if (clicks == 1)
                    {
                        int rx = e.X - x; //uit muis halen
                        int ry = e.Y - y;
                        resizing = true;
                    }
                }
            }
        }

        /// <summary>
        /// selecteert een vorm en/of verplaatst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(resizing == false)
            {
                if (cursorButton.Checked)
                {
                    label1.Text = "";
                    label2.Text = "";
                    //als een vorm geselcteerd, deze vorm verplaatsen naar geklikte bestemming
                    if (clicks == 1)
                    {
                        Visitor moveVisitor = new MoveVisitor();
                        Receiver selectedShape = panel.GetShape(selected);
                        Rectangle selectedRect = panel.GetRectangle(selected);
                        int newX = e.X; //uit muis halen
                        int newY = e.Y;
                        int rw = selectedRect.Width;
                        int rh = selectedRect.Height;
                        Rectangle draw = new Rectangle(newX, newY, rw, rh);

                        selectedShape.Accept(moveVisitor, selected, draw, panel);
                        redrawShapes();
                    }
                    //kijken of er een vorm is op de plaats van mouseclick
                    int count = panel.GetRectangleCount();
                    for (int i = 0; i < count; i++)
                    {
                        Rectangle RectI = panel.GetRectangle(i);
                        if (RectI.Contains(e.Location))
                        {
                            if (clicks == 1)
                            {
                                //vorm deselecteren
                                clicks = 0;
                            }
                            else
                            {
                                //vorm selecteren
                                clicks++;
                                selected = i;
                                label1.Text = "figuur geselecteerd!";
                                label2.Text = "klik ergens op het scherm om het figuur daarheen te verplaatsen, of sleep te rechter onderhoek om de grootte aan te passen.";
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //undo
            Graphics g = panel1.CreateGraphics();
            panel.Undo(g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //redo
            Graphics g = panel1.CreateGraphics();
            panel.Redo(g);
        }

        /// <summary>
        /// door lijst van vormen loopen en deze vormen tekenen op tekenvlak
        /// </summary>
        public void redrawShapes()
        {
            Graphics g = panel1.CreateGraphics();
            //tekenvlak leegmaken, om daarna vormen weer correct te tekenen (nieuwe plaat/afmetingen)
            g.Clear(BackColor);
            int count = panel.GetRectangleCount();
            for (int i = 0; i < count; i++)
            {
                //Receiver shape = shapes.ElementAt(i);
                Receiver shape = panel.GetShape(i);
                Command drawCommand = new DrawCommand(shape);
                panel.SetCommand(drawCommand);
                panel.redraw = true;
                panel.Execute(g);
            }
        }         
    }
}
