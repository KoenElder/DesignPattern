using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// decorator class, variant van BaseShape plus een bijschrift 
    /// </summary>
    public abstract class Decorator : BaseShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public char Type { get; set; }
        public System.Drawing.Color Colour { get; set; }
        public List<BaseShape> childs { get; set; }
        public bool filewritten { get; set; }

        //plek en tekst van bijschrift
        public int location;
        public String bijschrift;
        /// <summary>
        /// methode die vorm tekent
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Colour, 5);
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            //check of vorm een ellips of rectangle is
            if(this.Type == 'R')
            {
                g.DrawRectangle(pen, rhoek);
            }
            else
            {
                g.DrawEllipse(pen, rhoek);
            }         
            //ornament toevoegen aan vorm
            AddOrnament(g);
        }

        /// <summary>
        /// methode die vorm omzet in Rectangle variant
        /// </summary>
        /// <returns>Rectangle variant van vorm</returns>
        public Rectangle ConvertToRectangle()
        {
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            return rhoek;
        }

        /// <summary>
        /// methode voegt vorm, die zich binnen huidige instantie bevindt, toe aan childs lijst
        /// </summary>
        /// <param name="shape">vorm die aan childs toegevoegd wordt</param>
        public void AddChild(BaseShape shape)
        {
            childs.Add(shape);
        }

        /// <summary>
        /// methode accepteert een visitor die functionaliteit uit gaat voeren over deze vorm
        /// </summary>
        /// <param name="visitor">desbetreffende visitor</param>
        /// <param name="selected">index van geselecteerde vorm</param>
        /// <param name="draw">Rectangle variant van vorm, deze gaat getekent worden</param>
        /// <param name="panel">panel waarop de vorm getekent gaat worden</param>
        public void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel)
        {
            visitor.Visit(this, selected, draw, panel);
        }

        /// <summary>
        /// methode die info over decorated vorm schrijft als string
        /// </summary>
        public void toString(StreamWriter sw)
        {
            switch (location)
            {
                case (0):
                    sw.WriteLine("Ornament top " + '"' + bijschrift + '"');
                    break;
                case (1):
                    sw.WriteLine("Ornament right " + '"' + bijschrift + '"');
                    break;
                case (2):
                    sw.WriteLine("Ornament bottom " + '"' + bijschrift + '"');
                    break;
                case (3):
                    sw.WriteLine("Ornament left " + '"' + bijschrift + '"');
                    break;
            }
            if(this.Type == 'E')
            {
                sw.WriteLine("Ellips " + X + " " + Y + " " + W + " " + H);
            }
            else
            {                
                sw.WriteLine("Rectangle " + X + " " + Y + " " + W + " " + H);
            }
        }

        /// <summary>
        /// methode voegt bijschrift toe aan vorm
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public abstract void AddOrnament(Graphics g);

    }
}
