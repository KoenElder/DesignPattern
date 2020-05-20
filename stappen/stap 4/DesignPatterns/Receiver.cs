using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    public interface Receiver
    {
        int X { get; set; }
        int Y { get; set; }
        int W { get; set; }
        int H { get; set; }
        char Type { get; set; }
        System.Drawing.Color Colour { get; set; }
        List<Receiver> childs { get; set; }
        void Draw(Graphics g);
        Rectangle ConvertToRectangle();
        void AddChild(Receiver shape);

        void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel);
    }
}
