using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// command die het schrijven naar een file uitvoert
    /// </summary>
    public class SaveCommand : Command
    {
        StreamWriter writer;
        private Invoker panel;
        /// <summary>
        /// constructor, maakt nieuwe savecommand
        /// </summary>
        /// <param name="panel">panel waarvan de vormen naar file geschreven worden</param>
        public SaveCommand(Invoker panel)
        {
            this.panel = panel;
        }
        /// <summary>
        /// vormen worden naar file geschreven
        /// </summary>
        /// <param name="g">Graphics g, wordt eigenlijk niet bij deze command gebruikt</param>
        public void Execute(Graphics g)
        {
            string docPath = @"..\..\..\..\";
            writer = new StreamWriter(Path.Combine(docPath, "panel.txt"));            
            for (int i = 0; i < panel.GetRectangleCount(); i++)
            {
                BaseShape box = panel.GetShape(i);

                if (box.filewritten == false)
                {
                    //parent depth = 0
                    fileWriter(box, 0);
                }
            }
            writer.Close();
        }

        public void Execute()
        {
            string docPath = @"..\..\..\..\";
            writer = new StreamWriter(Path.Combine(docPath, "panel.txt"));
            for (int i = 0; i < panel.GetRectangleCount(); i++)
            {
                BaseShape box = panel.GetShape(i);

                if (box.filewritten == false)
                {
                    //parent depth = 0
                    fileWriter(box, 0);
                }
            }
            writer.Close();
        }

        /// <summary>
        /// returned vorm, niet relevant voor deze concrete command
        /// </summary>
        /// <returns>vorm</returns>
        public BaseShape GetReceiver()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// methode die de positie van de tekst recursief berekent
        /// </summary>
        /// <param name="shape">vorm die in de file geschreven wordt</param>
        /// <param name="depth">diepte van de vorm (aantal tabs)</param>
        public void fileWriter(BaseShape shape, int depth)
        {            
            if (shape.filewritten == false)
            {
                for (int i = 0; i < depth; i++)
                {
                    //aantal tabs = depth, dus een child heeft 1 tab, grand-child heeft 2 tabs
                    writer.Write("\t");
                }
                shape.toString(writer);
                shape.filewritten = true;
            }
            foreach(BaseShape child in shape.childs)
            {
                //depth of child = 1, grand-child = 2, etc
                fileWriter(child, depth + 1);
            }
        }
    }
}
