using System;
using System.Drawing;
using System.IO;
using DesignPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngineeringTests
{
    [TestClass]
    public class SaveCommandUnitTest
    {
        [TestMethod]
        public void SaveCanvasWith1Shape()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            Command savecommand = new SaveCommand(panel);
            panel.SetCommand(savecommand);
            
            //Act
            panel.Execute();

            //Assert
            string docPath = @"..\..\..\..\panel.txt"; //path to file where the savecommand writes to
            string actualSavedText = File.ReadAllText(docPath);
            string expectedText = "Rectangle 100 100 50 50\r\n"; //because the SaveMethod uses WriteLine, "\r\n" is needed at each line
            Assert.AreEqual(expectedText, actualSavedText, "Actual text does not match expected text");
        }

        [TestMethod]
        public void SaveCanvasWithMultipleShapes()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            BaseShape ellips = new Ellips(X: 50, Y: 50, W: 100, H: 100, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            int indexOfEllips = 1;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());
            panel.InsertInShapes(indexOfEllips, ellips);
            panel.InsertInRectangles(ellips.ConvertToRectangle());

            Command savecommand = new SaveCommand(panel);
            panel.SetCommand(savecommand);

            //Act
            panel.Execute();

            //Assert
            string docPath = @"..\..\..\..\panel.txt"; //path to file where the savecommand writes to
            string actualSavedText = File.ReadAllText(docPath);
            string expectedText = "Rectangle 100 100 50 50\r\n" + "Ellips 50 50 100 100\r\n"; //because the SaveMethod uses WriteLine, "\r\n" is needed at each line
            Assert.AreEqual(expectedText, actualSavedText, "Actual text does not match expected text");
        }

        [TestMethod]
        public void SaveCanvasWithMultipleShapesInsideEachOther()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 100, H: 100, System.Drawing.Color.Black);
            BaseShape ellips = new Ellips(X: 150, Y: 50, W: 25, H: 25, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            int indexOfEllips = 1;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());
            panel.InsertInShapes(indexOfEllips, ellips);
            panel.InsertInRectangles(ellips.ConvertToRectangle());
            rectangle.AddChild(ellips); //normally happens after drawing a shape and checking if the location is inside another shape

            Command savecommand = new SaveCommand(panel);
            panel.SetCommand(savecommand);

            //Act
            panel.Execute();

            //Assert
            string docPath = @"..\..\..\..\panel.txt"; //path to file where the savecommand writes to
            string actualSavedText = File.ReadAllText(docPath);
            string expectedText = "Rectangle 100 100 100 100\r\n" + "\tEllips 150 50 25 25\r\n"; //"\r\n" is needed for WriteLine, "\t" is needed for the indent of child shapes.
            Assert.AreEqual(expectedText, actualSavedText, "Actual text does not match expected text");
        }

        [TestMethod]
        public void SaveCanvasWithoutShapes()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Command savecommand = new SaveCommand(panel);
            panel.SetCommand(savecommand);

            //Act
            panel.Execute();

            //Assert
            string docPath = @"..\..\..\..\panel.txt"; //path to file where the savecommand writes to
            string actualSavedText = File.ReadAllText(docPath);
            string expectedText = ""; 
            Assert.AreEqual(expectedText, actualSavedText, "Actual text does not match expected text");
        }
    }
}
