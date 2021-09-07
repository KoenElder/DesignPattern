using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        //start en eind posities van muis
        int x = -1;
        int y = -1;
        int w, h;
        //int die aantal mouseclick bijhoudt
        int clicks = 0;
        //index van geselcteerde shape
        int selected = -1;
        //bools voor verplaatsen en resizen
        bool moving = false;
        bool resizing = false;
        //pen voor draw functies
        Pen pen;
<<<<<<< Updated upstream
        /// <summary>
        /// lijst van type Rectangle om de vormen te tekenen
        /// </summary>
        List<Rectangle> rectangles = new List<Rectangle>();
        /// <summary>
        /// lijst van type Rect om kleur en type vorm bij te houden
        /// </summary>
        List<Rect> shapes = new List<Rect>();
=======
        //singleton die commmands uit laat voeren
        Invoker panel = Invoker.GetInstance(); //get singleton instance
>>>>>>> Stashed changes
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
<<<<<<< Updated upstream
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized; 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
=======
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;            
>>>>>>> Stashed changes
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
            w = e.X - x; //afstand tussen oude en nieuwe positie muis
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
                //------- D R A W   E L L I P S -------//
                //als ellips is geselecteerd, wordt de vorm getekent en opgeslagen als ellips
<<<<<<< Updated upstream
                g.DrawEllipse(pen, rhoek);
                Rect shape = new Rect(x, y, w, h, 'E', pen.Color);
                shapes.Add(shape);
=======
                BaseShape shape = new Ellips(x, y, w, h, pen.Color);
                Receiver baseShape = new Receiver(shape);
                //draw command aanmaken en uitvoeren
                Command drawCommand = new DrawCommand(baseShape);
                panel.SetCommand(drawCommand);
                panel.Execute(g);

                panel.InsertInShapes(shape);

                //toevoegen als child, mits shape binnen andere vorm getekent wordt
                int count = panel.GetRectangleCount();
                //aftellen van shapes, anders wordt een shape in meerdere lijsten toegevoegd als child
                for (int i = count - 1; i-- > 0;)
                {
                    Rectangle EllipsI = panel.GetRectangle(i);
                    if (EllipsI.Contains(rhoek.Location))
                    {
                        BaseShape ShapeI = panel.GetShape(i);
                        ShapeI.AddChild(shape);
                        break; //break, zodat hij maar bij 1 vorm als child wordt toegevoegd
                    }
                }
>>>>>>> Stashed changes
            }
            if(rhoekButton.Checked)
            {
                //------ D R A W   R E C T ------//
                //als rechthoek is geselcteerd, wordt de vorm getekent en opgeslagen als rechthoek
<<<<<<< Updated upstream
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
=======
                Rect shape = new Rect(x, y, w, h, pen.Color);
                Receiver baseShape = new Receiver(shape);
                //draw command aanmaken en uitvoeren
                Command drawCommand = new DrawCommand(baseShape);
                panel.SetCommand(drawCommand);
                panel.Execute(g);

                panel.InsertInShapes(shape);

                //toevoegen als child, mits shape binnen andere vorm getekent wordt
                int count = panel.GetRectangleCount();
                //aftellen van shapes, anders wordt een shape in meerdere lijsten toegevoegd als child
                for (int i = count -1; i-- > 0;)
                {
                    Rectangle RectI = panel.GetRectangle(i);
                    if (RectI.Contains(rhoek.Location))
                    {
                        BaseShape ShapeI = panel.GetShape(i);
                        ShapeI.AddChild(shape);
                        break; //break, zodat hij maar bij 1 vorm als child wordt toegevoegd
                    }
                }
            }
            if (cursorButton.Checked)
            {
                //---------  R E S I Z E ----------//
                //als de cursor en een vorm zijn geselecteerd, wordt de vorm hertekent(resize)
                if (clicks == 1 && resizing == true)
                {
                    //visitor maken voor geselecteerde shape
                    Visitor resizeVisitor = new ResizeVisitor();
                    BaseShape selectedShape = panel.GetShape(selected);
                    Rectangle selectedRect = panel.GetRectangle(selected);
                    //nieuwe afmetingen van vorm aanmaken
                    int rhoekX = selectedRect.X;
                    int rhoekY = selectedRect.Y;
                    int rhoekW = selectedRect.Width;
                    int rhoekH = selectedRect.Height;
                    int newW = rhoekW + w;
                    int newH = rhoekH + h;
                    //vorm aanmaken met de nieuwe afmeting
                    Rectangle draw = new Rectangle(rhoekX, rhoekY, newW, newH);

                    //visitor accepteren
                    selectedShape.Accept(resizeVisitor, selected, draw, panel);
                    //vormen met juiste vorm opnieuw tekenen
                    redrawShapes();

                    resizing = false;
                    clicks = 0;
                    label1.Text = "";
                    label2.Text = "";
>>>>>>> Stashed changes
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
            if (moving && x != -1 && y != -1)
            {
                if (cursorButton.Checked)
                {
                    if (clicks == 1)
                    {
                        resizing = true;
                    }
                }
            }
        }

        /// <summary>
        /// selecteert een vorm en/of verplaatst
        /// </summary>
        /// <param name="sender">panel1 / tekenvlak</param>
        /// <param name="e">(muis) data van event</param>
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(resizing == false)
            {
                if (cursorButton.Checked)
                {
                    //-------- M O V E -------//
                    label1.Text = "";
                    //als een vorm geselcteerd, deze vorm verplaatsen naar geklikte bestemming
                    if (clicks == 1)
                    {
<<<<<<< Updated upstream
                        int rx = e.X; //uit muis halen
                        int ry = e.Y;
                        int rw = rectangles.ElementAt(selected).Width;
                        int rh = rectangles.ElementAt(selected).Height;
                        
                        moveShape(rx, ry, rw, rh);
                    }
                    //kijken of er een vorm is op de plaats van mouseclick
                    for (int i = 0; i < rectangles.Count; i++)
=======
                        //move visitor wordt aangemaakt voor geselcteerde vorm
                        Visitor moveVisitor = new MoveVisitor();
                        BaseShape selectedShape = panel.GetShape(selected);
                        Rectangle selectedRect = panel.GetRectangle(selected);
                        //nieuwe coordinaten van vorm worden aangemaakt
                        int newX = e.X; //uit muis halen
                        int newY = e.Y;
                        int rw = selectedRect.Width;
                        int rh = selectedRect.Height;
                        //vorm met de nieuwe data aanmaken
                        Rectangle draw = new Rectangle(newX, newY, rw, rh);

                        //vorm accepteert visitor
                        selectedShape.Accept(moveVisitor, selected, draw, panel);
                        //vormen, op juiste positie, opnieuw tekenen
                        redrawShapes();
                    }
                    //kijken of er een vorm is op de plaats van mouseclick
                    int count = panel.GetRectangleCount();
                    //achteraan beginnen bij shapes, zodat de kleinste shape geselecteerd wordt, ipv een grote parent
                    for (int i = count; i-- > 0;)
>>>>>>> Stashed changes
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
                            }
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
<<<<<<< Updated upstream
        /// verplaatst vorm naar nieuwe locatie
        /// </summary>
        /// <param name="rx">X-coördinaat van nieuwe locatie</param>
        /// <param name="ry">Y-coördinaat van nieuwe locatie</param>
        /// <param name="rw">breedte van vorm</param>
        /// <param name="rh">hoogte van vorm</param>
        public void moveShape(int rx, int ry, int rw, int rh)
        {
=======
        /// laatst gemaakte vorm wordt undone
        /// </summary>
        /// <param name="sender">button 1 / undone-knop</param>
        /// <param name="e">data van event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //------- U N D O ------//
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        /// grootte van vorm veranderen
        /// </summary>
        /// <param name="rx">X-coördinaat van vorm</param>
        /// <param name="ry">Y-coördinaat van vorm</param>
        /// <param name="rw">nieuwe breedte van vorm</param>
        /// <param name="rh">nieuwe hoogte van vorm</param>
        public void resizeShape(int rx, int ry, int rw, int rh)
        {
=======
        /// laatst gedane undone command wordt redone
        /// </summary>
        /// <param name="sender">button2 / redo-knop</param>
        /// <param name="e">data van event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            //------- R E D O -------//
>>>>>>> Stashed changes
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
        }

        /// <summary>
        /// bijschrift wordt aan geselcteerde vorm toegevoegd
        /// </summary>
        /// <param name="sender">button3 / bijschift knop</param>
        /// <param name="e">data van knop</param>
        private void button3_Click(object sender, EventArgs e)
        {  
            if(clicks != 0)
            {
                //bijschrift toevoegen
                String bijschrift = textBox1.Text;
                int locatie = comboBox1.SelectedIndex; //0=boven, 1=rechts, 2=onder, 3=links
                Graphics g = panel1.CreateGraphics();

                //ornament visitor aanmaken voor geselcteerde vorm
                Visitor ornamentVisitor = new OrnamentVisitor();
                //ornament aanmaken van geselcteerde vorm, plus tekst
                BaseShape selectedShape = new Ornament(panel.GetShape(selected), locatie, bijschrift);
                Rectangle selectedRect = panel.GetRectangle(selected);
                int ParentX = selectedRect.X;
                int ParentY = selectedRect.Y;
                int ParentW = selectedRect.Width;
                int ParentH = selectedRect.Height;
                Rectangle draw = new Rectangle(ParentX, ParentY, ParentW, ParentH);
                selectedShape.Accept(ornamentVisitor, selected, draw, panel);

                redrawShapes();

                //voor bijschrift wordt een figuur geselcteerd, deze moet niet geselecteerd blijven
                clicks = 0;
                selected = -1;
                label1.Text = "";
                label2.Text = "";
            }            
                      
        }

        /// <summary>
        /// data van gemaakte tekening wordt naar .txt file geschreven
        /// </summary>
        /// <param name="sender">button4 / filewrite-knop</param>
        /// <param name="e">data van event</param>
        private void button4_Click(object sender, EventArgs e)
        {
            //write to file
            Graphics g = panel1.CreateGraphics();
            //savecommand aanmaken en uitvoeren
            Command savecommand = new SaveCommand(panel);
            panel.SetCommand(savecommand);
            panel.Execute(g);            
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
<<<<<<< Updated upstream
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
=======
                BaseShape shape = panel.GetShape(i);
                Receiver receiver = new Receiver(shape);
                Command drawCommand = new DrawCommand(receiver);
                panel.SetCommand(drawCommand);
                panel.Execute(g);
>>>>>>> Stashed changes
            }
        }
    }
}
