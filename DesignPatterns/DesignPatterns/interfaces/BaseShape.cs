using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace DesignPatterns
{
    /// <summary>
    /// baseshape, hier erfen vormen van over, fungeert als strategy
    /// </summary>
    public interface BaseShape
    {
        //x- en y-coordinaten en breedte en hoogte
        int X { get; set; }
        int Y { get; set; }
        int W { get; set; }
        int H { get; set; }

        //soort(ellips 'E' / rectangle 'R') en kleur 
        char Type { get; set; }        
        System.Drawing.Color Colour { get; set; }
        //lijst met childs voor composite pattern
        List<BaseShape> childs { get; set; }
        //bool voor als de vorm in .txt file is geschreven
        bool filewritten { get; set; }

        /// <summary>
        /// methode die een vorm tekent
        /// </summary>
        /// <param name="g">Graphics waarmee getkent wordt</param>
        void Draw(Graphics g);
        /// <summary>
        /// methode die BaseShape omzet in Rectangle
        /// </summary>
        /// <returns>Rectangle variant van BaseShape</returns>
        Rectangle ConvertToRectangle();
        /// <summary>
        /// methode voegt child toe aan child lijst
        /// </summary>
        /// <param name="shape">child dat toegevoegd wordt</param>
        void AddChild(BaseShape shape);
        /// <summary>
        /// methode die een visitor accepteert bij de vorm
        /// </summary>
        /// <param name="visitor">visitor die visit</param>
        /// <param name="selected">index van geselcteerde vorm</param>
        /// <param name="draw">Rectangle variant van de BaseShape vorm</param>
        /// <param name="panel">panel waarop de vorm getekent gaat worden</param>
        void Accept(Visitor visitor, int selected, Rectangle draw, Invoker panel);
        /// <summary>
        /// toString methode voor strategy pattern
        /// </summary>
        void toString(StreamWriter sw);

    }
}
