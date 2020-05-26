using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    abstract class Command
    {
        public abstract void Undo(GraphicsList list);
        public abstract void Redo(GraphicsList list);
    }
}
