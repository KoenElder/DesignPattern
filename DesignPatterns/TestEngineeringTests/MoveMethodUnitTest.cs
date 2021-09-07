using System;
using System.Drawing;
using DesignPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngineeringTests
{
    [TestClass]
    public class MoveMethodUnitTest
    {
        [TestMethod]
        public void MoveShapeToOtherXCoordinateInsidePanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());
            
            int newX = 50;
            Rectangle rectangleWithNewCoordinates = new Rectangle(newX, rectangle.Y, rectangle.W, rectangle.H);
            
            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 50, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual X-coordinate does not match expected X-coordinate");
        }

        [TestMethod]
        public void MoveShapeToOtherYCoordinateInsidePanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newY = 50;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, newY, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 50, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.Y, panel.GetShape(indexOfRectangle).Y, "Actual Y-coordinate does not match expected Y-coordinate");
        }

        [TestMethod]
        public void MoveShapeToOtherXCoordinateOutsidePanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newX = 999999999;
            Rectangle rectangleWithNewCoordinates = new Rectangle(newX, rectangle.Y, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 999999999, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual X-coordinate does not match expected X-coordinate");
        }

        [TestMethod]
        public void MoveShapeToOtherYCoordinateOutsidePanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newY = 999999999;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, newY, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 999999999, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.Y, panel.GetShape(indexOfRectangle).Y, "Actual Y-coordinate does not match expected Y-coordinate");
        }

        [TestMethod]
        public void MoveShapeToOtherXCoordinateOnPanelBorder()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());            

            int newX = 1920; //width of personal screen
            Rectangle rectangleWithNewCoordinates = new Rectangle(newX, rectangle.Y, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 1920, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual X-coordinate does not match expected X-coordinate");
        }

        [TestMethod]
        public void MoveShapeToOtherYCoordinateOnPanelBorder()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newY = 1080; //height of personal screen
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, newY, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 1080, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.Y, panel.GetShape(indexOfRectangle).Y, "Actual Y-coordinate does not match expected Y-coordinate");
        }

        [TestMethod]
        public void MoveShapeToSameXCoordinateOnPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newX = 100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(newX, rectangle.Y, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual X-coordinate does not match expected X-coordinate");
        }

        [TestMethod]
        public void MoveShapeToSameYCoordinateOnPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newY = 100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, newY, rectangle.W, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.Y, panel.GetShape(indexOfRectangle).Y, "Actual Y-coordinate does not match expected Y-coordinate");
        }
    }
}
