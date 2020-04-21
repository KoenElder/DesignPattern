using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
        public char Type;
        public System.Drawing.Color Colour;

        public Rect(int X,int Y,int W,int H, char T, System.Drawing.Color C)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
            this.Type = T;
            this.Colour = C;
        }

        public int getX()
        {
            return this.X;
        }
        public void setX(int x)
        {
            this.X = x;
        }
        public int getY()
        {
            return this.Y;
        }
        public void setY(int y)
        {
            this.X = y;
        }
        public int getW()
        {
            return this.W;
        }
        public void setW(int w)
        {
            this.X = w;
        }
        public int getH()
        {
            return this.H;
        }
        public void setH(int h)
        {
            this.X = h;
        }
    }
}
