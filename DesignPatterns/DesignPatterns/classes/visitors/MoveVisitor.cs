using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// visitor die een vorm visit om deze vorm te verplaatsen
    /// </summary>
    public class MoveVisitor : Visitor
    {
        /// <summary>
        /// visit een rechthoek, om deze te verplaaten
        /// </summary>
        /// <param name="rhoek">Rect variant van de geselecteerde Rectangle</param>
        /// <param name="selected">index van de geselecteerde Rectangle, deze moet verplaatst worden</param>
        /// <param name="draw">Rectangle kopie van selected, met de nieuwe x- en y-coordinaten</param>
        /// <param name="panel">panel waarop de verplaatste vorm getekend moet worden</param>
        public void Visit(Rect rhoek, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Rect(draw.X, draw.Y, draw.Width, draw.Height, rhoek.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }

        /// <summary>
        /// visit een ellips, om deze te verplaatsen
        /// </summary>
        /// <param name="ellips">Ellips variant van de geselecterde Rectangle</param>
        /// <param name="selected">index van de geselecteerde Rectangle</param>
        /// <param name="draw">Rectangle kopie van selected, met de nieuwe x- en y-coordinaten</param>
        /// <param name="panel">panel waarop de verplaatste vorm getekend moet worden</param>
        public void Visit(Ellips ellips, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Ellips(draw.X, draw.Y, draw.Width, draw.Height, ellips.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }

        /// <summary>
        /// visit een decorater, om deze te verplaatsen
        /// </summary>
        /// <param name="ornament">Decorator variant van de geselecteerde Rectangle</param>
        /// <param name="selected">index van de geselecteerde Rectangle</param>
        /// <param name="draw">Rectangle kopie van selected, met de nieuwe x- en y-coordinaten</param>
        /// <param name="panel">panel waarop de vorm getekend moet worden</param>
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
