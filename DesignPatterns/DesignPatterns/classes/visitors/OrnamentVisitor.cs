using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// visitor die een shape vervangt met een ornament-decorated shape
    /// </summary>
    class OrnamentVisitor : Visitor
    {
        //zelfde fucntionaliteit als andere visitors, echter alleen voor ornament, dus geen implementatie voor rect
        public void Visit(Rect rhoek, int selected, Rectangle draw, Invoker panel)
        {
            throw new NotImplementedException();
        }

        //zelfde fucntionaliteit als andere visitors, echter alleen voor ornament, dus geen implementatie voor ellips
        public void Visit(Ellips ellips, int selected, Rectangle draw, Invoker panel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vervangt selected met een kopie, plus zijn ornament
        /// </summary>
        /// <param name="ornament">kopie van selected met ornament</param>
        /// <param name="selected">index van selected</param>
        /// <param name="draw">Rectangle variant van ornament, deze wordt getekent</param>
        /// <param name="panel">panel waarop de vorm getekent moet worden</param>
        public void Visit(Decorator ornament, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Ornament(ornament, ornament.location, ornament.bijschrift);
            shape.X = draw.X;
            shape.Y = draw.Y;
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }
    }
}
