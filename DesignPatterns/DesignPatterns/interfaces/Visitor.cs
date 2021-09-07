using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// visitor interface, hier erfen klasses van die een object aanpassen
    /// 1 functie voor elk type vorm die een visitor kan visiten
    /// </summary>
    public interface Visitor
    {
        void Visit(Rect shape, int selected, Rectangle draw, Invoker panel);
        void Visit(Ellips shape, int selected, Rectangle draw, Invoker panel);
        void Visit(Decorator ornament, int selected, Rectangle draw, Invoker panel);
    }
}
