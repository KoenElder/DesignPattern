using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// class van decorated vormen
    /// </summary>
    class Ornament : Decorator
    {
        //font en brush voor tekst
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        //x- en y-coordinaten voor tekst
        int x;
        int y;

        /// <summary>
        /// constructor, maakt kopie van geselcteerde vorm, en voegt tekst toe
        /// </summary>
        /// <param name="selected">geselecteerde vorm</param>
        /// <param name="place">plaatsing voor tekst</param>
        /// <param name="text">tekst voor bijschrift</param>
        public Ornament(BaseShape selected, int place, String text)
        {
            //waardes voor decoratedshape overnemen van geselcteerde vorm
            this.X = selected.X;
            this.Y = selected.Y;
            this.W = selected.W;
            this.H = selected.H;
            this.Type = selected.Type;
            this.Colour = selected.Colour;
            this.childs = selected.childs;
            this.filewritten = selected.filewritten;

            //locatie en tekst voor bijschrift setten
            this.location = place;
            switch (location)
            {
                case (0):
                    this.bijschrift = text;
                    break;
                case (1):
                    this.bijschrift = text;
                    break;
                case (2):
                    this.bijschrift = text;
                    break;
                case (3):
                    this.bijschrift = text;
                    break;
            }
        }

        /// <summary>
        /// methode die tekst toevoegd aan vorm
        /// </summary>
        /// <param name="g">Graphics waarmee de tekst getekent wordt</param>
        public override void AddOrnament(Graphics g)
        {
            //kijken waar de tekst moet komen te staan
            switch (location)
            {
                //boven
                case (0):
                    //x locatie = x locatie van vorm, plus de helft van de breedte, - de helft van de lengte van de tekst
                    x = (W / 2) - ((bijschrift.Length / 2) * 10) + X;
                    // y locatie = y locatie van vorm, min een klein beetje om niet in de vorm te zitten
                    y = Y - 24;
                    g.DrawString(bijschrift, drawFont, drawBrush, x, y);
                    break;
                //rechts
                case (1):
                    //x locatie = x locatie vorm plus de breedte vorm
                    x = X += W;
                    //y locatie = y locatie vorm + helft van de hoogte van de vorm, - hoogte van lettertype
                    y = (Y += (H / 2)) - 16;
                    g.DrawString(bijschrift, drawFont, drawBrush, x, y);
                    break;
                //onder
                case (2):
                    //x locatie = x locatie van vorm, plus de helft van de breedte, - de helft van de lengte van de tekst
                    x = (X += (W / 2)) - ((bijschrift.Length / 2) * 10);
                    //y locatie = y locatie vorm + hoogte van de vorm
                    y = Y + H;
                    g.DrawString(bijschrift, drawFont, drawBrush, x, y);
                    break;
                //links
                case (3):
                    //x locatie = x locatie vorm - lengte van de letters
                    x = X - (bijschrift.Length * 10) - 10;
                    //y locatie = y locatie vorm + helft hoogte vorm
                    y = (Y += (H / 2)) - 8;
                    g.DrawString(bijschrift, drawFont, drawBrush, x, y);
                    break;
            }
        }
    }
}
