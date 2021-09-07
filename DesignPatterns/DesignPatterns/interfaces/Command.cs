using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    /// <summary>
    /// interface waaruit concrete commands erfen
    /// </summary>
    public interface Command
    {
        /// <summary>
        /// methode die commands uit laat voeren
        /// </summary>
        /// <param name="g">Graphics waarmee getekent kan worden</param>
        void Execute(Graphics g);

        void Execute();

        /// <summary>
        /// methode om te achterhalen op welke vorm een command is uitgevoerd
        /// </summary>
        /// <returns>de vorm waarop iets is uitgevoerd</returns>
        BaseShape GetReceiver();
    }
}
