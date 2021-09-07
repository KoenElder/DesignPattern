using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    /// <summary>
    /// command die figuren tekent
    /// </summary>
    class DrawCommand : Command
    {
        private Receiver receiver;
        /// <summary>
        /// constructor voor concrete draw-command
        /// </summary>
        /// <param name="baseshape">Receiver die getekend moet worden</param>
        public DrawCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        /// <summary>
        /// methode die een command laat uitvoeren
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public void Execute(Graphics g)
        {
            //vorm tekenen via receiver
            receiver.ExecuteStrategy(g);            
        } 

        public void Execute() { }
        
        /// <summary>
        /// methode die vorm ophaalt waarop een draw command is uitgevoerd
        /// </summary>
        /// <returns>betreffende vorm</returns>
        public BaseShape GetReceiver()
        {
            return receiver.Strategy;
        }
    }
}
