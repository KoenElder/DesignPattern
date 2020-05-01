using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    class DrawCommand : Command
    {
        private Receiver receiver;
        public DrawCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute(Graphics g)
        {
            receiver.Draw(g);
        } 
        
        public Receiver GetReceiver()
        {
            return receiver;
        }
    }
}
