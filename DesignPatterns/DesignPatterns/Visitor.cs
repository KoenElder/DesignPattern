using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface Visitor
    {
        void Visit(Rect shape, int selected, Rectangle draw, Invoker panel);
        void Visit(Ellips shape, int selected, Rectangle draw, Invoker panel);
    }
}
