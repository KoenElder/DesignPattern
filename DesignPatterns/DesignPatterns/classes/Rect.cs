using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream:DesignPatterns/DesignPatterns/Rect.cs
=======
using System.Drawing;
using System.IO;
>>>>>>> Stashed changes:DesignPatterns/DesignPatterns/classes/Rect.cs

namespace DesignPatterns
{
    /// <summary>
    /// zelfgemaakte variant van Rectangle, hiermee wordt ook soort en kleur bijgehouden
    /// </summary>
<<<<<<< Updated upstream:DesignPatterns/DesignPatterns/Rect.cs
    class Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
        public char Type;
        public System.Drawing.Color Colour;
=======
    public class Rect : BaseShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public char Type { get; set; }
        public System.Drawing.Color Colour { get; set; }
        public List<BaseShape> childs { get; set; }
        public bool filewritten { get; set; }
>>>>>>> Stashed changes:DesignPatterns/DesignPatterns/classes/Rect.cs

        public static Rect instance;
        /// <summary>
        /// constructor, maakt nieuwe instanties aan
        /// </summary>
        /// <param name="X">X-coördinaat van vorm</param>
        /// <param name="Y">Y-coördinaat van vorm</param>
        /// <param name="W">breedte van vorm</param>
        /// <param name="H">hoogte van vorm</param>
        /// <param name="T">soort van vorm (ellips of rechthoek)</param>
        /// <param name="C">kleur van vorm</param>
        public Rect(int X,int Y,int W,int H, char T, System.Drawing.Color C)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
            this.Type = T;
            this.Colour = C;
<<<<<<< Updated upstream:DesignPatterns/DesignPatterns/Rect.cs
=======
            this.childs = new List<BaseShape>();
        }

        /// <summary>
        /// methode die de instantie tekent op het de panel
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Colour, 5);
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            g.DrawRectangle(pen, rhoek);
        }

        /// <summary>
        /// methode die Rect omzet naar Rectangle
        /// </summary>
        /// <returns>Rectangle variant van Rect</returns>
        public Rectangle ConvertToRectangle()
        {
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            return rhoek;
        }

        /// <summary>
        /// voegt vorm die binnen huidige instantie zit toe aan child lijst
        /// </summary>
        /// <param name="shape">child dat aan child lijst wordt toegevoegd</param>
        public void AddChild(BaseShape shape)
        {
            childs.Add(shape);
        }

        /// <summary>
        /// accepteert een visitor die iets met deze instantie gaat doen
        /// </summary>
        /// <param name="visitor">visitor die iets fucntionaliteit uit gaat voeren</param>
        /// <param name="selected">index van geselecteerde vorm</param>
        /// <param name="draw">Rectangle variant die getekent gaat worden</param>
        /// <param name="panel">panel waarop getekent wordt</param>
        public void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel)
        {
            visitor.Visit(this, selected, draw, panel);
>>>>>>> Stashed changes:DesignPatterns/DesignPatterns/classes/Rect.cs
        }

        /// <summary>
        /// schrijft info over instantie als string
        /// </summary>
        public void toString(StreamWriter sw)
        {
            sw.WriteLine("Rectangle " + X + " " + Y + " " + W + " " + H);
        }

    }
}
