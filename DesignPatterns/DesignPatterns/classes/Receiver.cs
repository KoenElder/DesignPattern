using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// class die fuctioneert als context voor strategy, en receiver voor commands
    /// </summary>
    class Receiver
    {
        public BaseShape Strategy;

        public Receiver(BaseShape strat)
        {
            Strategy = strat;
        }

        /// <summary>
        /// wanneer geroepen door invoker, laat de strategy zichzelf tekenen
        /// </summary>
        /// <param name="g">graphics om mee te tekenen</param>
        public void ExecuteStrategy(Graphics g)
        {
            Strategy.Draw(g);
        }
    }
}
