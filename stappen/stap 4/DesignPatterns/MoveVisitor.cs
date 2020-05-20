using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class MoveVisitor : Visitor
    {
        public void Visit(Rect rhoek, int selected, Rectangle draw, Invoker panel)
        {
            Receiver shape = new Rect(draw.X, draw.Y, draw.Width, draw.Height, rhoek.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }

        public void Visit(Ellips ellips, int selected, Rectangle draw, Invoker panel)
        {
            Receiver shape = new Ellips(draw.X, draw.Y, draw.Width, draw.Height, ellips.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }
    }
}
