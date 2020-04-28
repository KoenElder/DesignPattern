﻿using System;
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
    class Rect : Receiver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public char Type { get; set; }
        public System.Drawing.Color Colour { get; set; }


        /// <summary>
        /// constructor, maakt nieuwe instanties aan
        /// </summary>
        /// <param name="X">X-coördinaat van vorm</param>
        /// <param name="Y">Y-coördinaat van vorm</param>
        /// <param name="W">breedte van vorm</param>
        /// <param name="H">hoogte van vorm</param>
        /// <param name="T">soort van vorm (ellips of rechthoek)</param>
        /// <param name="C">kleur van vorm</param>
        public Rect(int X,int Y,int W,int H, System.Drawing.Color C)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
            this.Type = 'R';
            this.Colour = C;            
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Colour, 5);
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            g.DrawRectangle(pen, rhoek);                        
        }

        public Rectangle ConvertToRectangle()
        {
            Rectangle rhoek = new Rectangle(X, Y, W, H);
            return rhoek;
        }
    }
}
