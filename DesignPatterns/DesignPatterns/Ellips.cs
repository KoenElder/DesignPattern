using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    /// <summary>
    /// zelfgemaakte variant van Rectangle, hiermee wordt ook soort en kleur bijgehouden
    /// </summary>
    public class Ellips : Receiver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public char Type { get; set; }
        public System.Drawing.Color Colour { get; set; }
        public List<Receiver> childs { get; set; }

        /// <summary>
        /// constructor, maakt nieuwe instanties aan
        /// </summary>
        /// <param name="X">X-coördinaat van vorm</param>
        /// <param name="Y">Y-coördinaat van vorm</param>
        /// <param name="W">breedte van vorm</param>
        /// <param name="H">hoogte van vorm</param>
        /// <param name="T">soort van vorm (ellips of rechthoek)</param>
        /// <param name="C">kleur van vorm</param>
        public Ellips(int X, int Y, int W, int H, System.Drawing.Color C)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
            this.Type = 'E';
            this.Colour = C;
            this.childs = new List<Receiver>();
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Colour, 5);
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            g.DrawEllipse(pen, rhoek);
            
        }

        public Rectangle ConvertToRectangle()
        {
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            return rhoek;
        }

        public void AddChild(Receiver shape)
        {
            childs.Add(shape);
        }

        public void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel)
        {
            visitor.Visit(this, selected, draw, panel);
        }
    }
}
