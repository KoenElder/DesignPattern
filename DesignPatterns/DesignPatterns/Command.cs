using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    public interface Command
    {
        void Execute(Graphics g);
        Receiver GetReceiver();
    }
}
