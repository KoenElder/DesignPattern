using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// visitor die een vorm van grootte verandert
    /// </summary>
    class ResizeVisitor : Visitor
    {
        /// <summary>
        /// visit een rectangle om deze te resizen
        /// </summary>
        /// <param name="rhoek">Rect variant van de selected Rectangle</param>
        /// <param name="selected">index van selected Rectangle</param>
        /// <param name="draw">Rectangle kopie met nieuwe width en height, deze wordt getekend</param>
        /// <param name="panel">panel waarop de vorm wordt getekent</param>
        public void Visit(Rect rhoek, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Rect(draw.X, draw.Y, draw.Width, draw.Height, rhoek.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }

        /// <summary>
        /// visit een ellips, om deze te resizen
        /// </summary>
        /// <param name="ellips">Ellips variant van selected Rectangle</param>
        /// <param name="selected">index van selected Rectangle</param>
        /// <param name="draw">kopie van selected Rectangle, met nieuwe width en height, deze wordt getekent</param>
        /// <param name="panel">panel waarop de vorm getekend moet worden</param>
        public void Visit(Ellips ellips, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Ellips(draw.X, draw.Y, draw.Width, draw.Height, ellips.Colour);
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }

        /// <summary>
        /// visit een decorator, om deze te veranderen van grootte
        /// </summary>
        /// <param name="ornament">Decorator variant van de selected Rectangle</param>
        /// <param name="selected">index van selected Rectangle</param>
        /// <param name="draw">Rectangle kopie met de nieuwe width en height, deze wordt getekent</param>
        /// <param name="panel">panel waarop de vorm getekend moet worden</param>
        public void Visit(Decorator ornament, int selected, Rectangle draw, Invoker panel)
        {
            BaseShape shape = new Ornament(ornament, ornament.location, ornament.bijschrift);
            shape.W = draw.Width;
            shape.H = draw.Height;
            panel.RemoveFromRectangles(selected);
            panel.InsertInRectangles(selected, draw);
            panel.RemoveFromShapes(selected);
            panel.InsertInShapes(selected, shape);
        }
    }
}
