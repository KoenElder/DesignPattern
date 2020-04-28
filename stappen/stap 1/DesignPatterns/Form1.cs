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
        /// <summary>
        /// lijst van type Rectangle om de vormen te tekenen
        /// </summary>
        List<Rectangle> rectangles = new List<Rectangle>();
        /// <summary>
        /// lijst van type Rect om kleur en type vorm bij te houden
        /// </summary>
        List<Rect> shapes = new List<Rect>();
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
                rectangles.Add(rhoek);                
            }            
            if (ellipsButton.Checked)
            {
                //als ellips is geselecteerd, wordt de vorm getekent en opgeslagen als ellips
                g.DrawEllipse(pen, rhoek);
                Rect shape = new Rect(x, y, w, h, 'E', pen.Color);
                shapes.Add(shape);
            }
            if(rhoekButton.Checked)
            {
                //als rechthoek is geselcteerd, wordt de vorm getekent en opgeslagen als rechthoek
                g.DrawRectangle(pen, rhoek);
                Rect shape = new Rect(x, y, w, h, 'R', pen.Color);
                shapes.Add(shape);
            }
            if (cursorButton.Checked)
            {
                //als de cursor en een vorm zijn geselecteerd, wordt de vorm hertekent(resize)
                if (clicks == 1 && resizing == true)
                {
                    int rhoekX = rectangles.ElementAt(selected).X;
                    int rhoekY = rectangles.ElementAt(selected).Y;
                    int rhoekW = rectangles.ElementAt(selected).Width;
                    int rhoekH = rectangles.ElementAt(selected).Height;
                    int diffW = rhoekW + w;
                    int diffH = rhoekH + h;
                    resizeShape(rhoekX, rhoekY, diffW, diffH);
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
                        int rx = e.X; //uit muis halen
                        int ry = e.Y;
                        int rw = rectangles.ElementAt(selected).Width;
                        int rh = rectangles.ElementAt(selected).Height;
                        
                        moveShape(rx, ry, rw, rh);
                    }
                    //kijken of er een vorm is op de plaats van mouseclick
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        if (rectangles[i].Contains(e.Location))
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

        /// <summary>
        /// verplaatst vorm naar nieuwe locatie
        /// </summary>
        /// <param name="rx">X-coördinaat van nieuwe locatie</param>
        /// <param name="ry">Y-coördinaat van nieuwe locatie</param>
        /// <param name="rw">breedte van vorm</param>
        /// <param name="rh">hoogte van vorm</param>
        public void moveShape(int rx, int ry, int rw, int rh)
        {
            Graphics g = panel1.CreateGraphics();
            //kopie maken van vorm op nieuwe locatie
            Rectangle draw = new Rectangle(rx, ry, rw, rh);
            //kijken of vorm een ellips of rechthoek is
            if (shapes.ElementAt(selected).Type == 'E')
            {
                //oude ellips verwijderen uit lijsten en op de nieuwe locatie toevoegen in lijsten
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, draw);
                Rect shape = new Rect(rx, ry, rw, rh, 'E', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            else
            {
                //oude rechthoek verwijderen uit lijsten en op de nieuwe locatie toevoegen in lijsten
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, draw);
                Rect shape = new Rect(rx, ry, rw, rh, 'R', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            //tekenvlak opnieuw tekenen
            redrawShapes();
        }

        /// <summary>
        /// grootte van vorm veranderen
        /// </summary>
        /// <param name="rx">X-coördinaat van vorm</param>
        /// <param name="ry">Y-coördinaat van vorm</param>
        /// <param name="rw">nieuwe breedte van vorm</param>
        /// <param name="rh">nieuwe hoogte van vorm</param>
        public void resizeShape(int rx, int ry, int rw, int rh)
        {
            Graphics g = panel1.CreateGraphics();
            Rectangle resized = new Rectangle(rectangles.ElementAt(selected).Location, new Size(rw, rh));
            if (shapes.ElementAt(selected).Type == 'E')
            {
                //oude ellips verwijderen uit lijsten en met nieuwe afmetingen toevoegen in lijsten
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, resized);
                Rect shape = new Rect(rx, ry, rw, rh, 'E', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            else
            {
                //oude rechthoek verwijderen uit lijsten en met nieuwe afmetingen toevoegen in lijsten
                rectangles.RemoveAt(selected);
                rectangles.Insert(selected, resized);
                Rect shape = new Rect(rx, ry, rw, rh, 'R', shapes[selected].Colour);
                shapes.RemoveAt(selected);
                shapes.Insert(selected, shape);
            }
            redrawShapes();

            resizing = false;
            clicks = 0;
            label1.Text = "";
            label2.Text = "";
        }

        /// <summary>
        /// door lijst van vormen loopen en deze vormen tekenen op tekenvlak
        /// </summary>
        public void redrawShapes()
        {
            Graphics g = panel1.CreateGraphics();
            //tekenvlak leegmaken, om daarna vormen weer correct te tekenen (nieuwe plaat/afmetingen)
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
