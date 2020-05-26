using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    class Add : Command
    {
        DrawObject drawObject;
        public Add(DrawObject drawObject) : base() {
            this.drawObject = drawObject.Clone(); }
        public override void Undo(GraphicsList graphicsList) {
            graphicsList.DeleteLastAddedObject(); }
        public override void Redo(GraphicsList graphicsList) {
            graphicsList.UnselectAll();
            graphicsList.Add(drawObject); }
    }
}
