using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace DesignPatterns
{
    /// <summary>
    /// zelfgemaakte variant van Rectangle, hiermee wordt ook soort en kleur bijgehouden
    /// </summary>
    public class Ellips : BaseShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public char Type { get; set; }
        public System.Drawing.Color Colour { get; set; }
        public List<BaseShape> childs { get; set; }
        public bool filewritten { get; set; }

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
            this.childs = new List<BaseShape>();
        }

        /// <summary>
        /// tekent huidige instantie
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Colour, 5);
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            g.DrawEllipse(pen, rhoek);        
        }

        /// <summary>
        /// methode die Ellips omzet naar Rectangle
        /// </summary>
        /// <returns>Rectangle variant van Ellips</returns>
        public Rectangle ConvertToRectangle()
        {
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            return rhoek;
        }

        /// <summary>
        /// voegt vorm, die binnen huidige instantie getekent is, toe aan childs lijst
        /// </summary>
        /// <param name="shape">vorm die aan child lijst wordt toegevoegd</param>
        public void AddChild(BaseShape shape)
        {
            childs.Add(shape);
        }

        /// <summary>
        /// methode accepteert een visitor die functionaliteit voer de vorm uit gaat voeren
        /// </summary>
        /// <param name="visitor">desbetreffende visitor</param>
        /// <param name="selected">index van geselcteerde vorm</param>
        /// <param name="draw">Rectangle variant die getekent gaat worden</param>
        /// <param name="panel">panel waarop getekent gaat worden</param>
        public void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel)
        {
            visitor.Visit(this, selected, draw, panel);
        }

        /// <summary>
        /// methode die info over ellips schrijft als string
        /// </summary>
        public void toString(StreamWriter sw)
        {
            sw.WriteLine("Ellips " + X + " " + Y + " " + W + " " + H);
        }
    }
}
