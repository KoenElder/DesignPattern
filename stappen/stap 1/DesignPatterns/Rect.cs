using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// zelfgemaakte variant van Rectangle, hiermee wordt ook soort en kleur bijgehouden
    /// </summary>
    class Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
        public char Type;
        public System.Drawing.Color Colour;

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
        }
    }
}
