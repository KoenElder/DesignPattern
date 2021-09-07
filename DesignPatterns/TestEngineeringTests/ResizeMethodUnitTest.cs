using System;
using System.Drawing;
using DesignPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngineeringTests
{
    [TestClass]
    public class ResizeMethodUnitTest
    {
        [TestMethod]
        public void ResizeShapeToBiggerWidth()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 100, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToBiggerHeight()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 100, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToSmallerWidth()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 10;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 10, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToSmallerHeight()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 10;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 10, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToWidthBiggerThanPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 999999999;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 999999999, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToHeightBiggerThanPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 999999999;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 999999999, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToWidthEqualToPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 1920; //width of personal screen
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 1920, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToHeightEqualToPanel()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 1080; //height of personal screen
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 1080, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToSameWidth()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 50;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToSameHeight()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 50;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToWidthOfZero()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = 0;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 0, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToHeightOfZero()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = 0;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: 0, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }

        [TestMethod]
        public void ResizeShapeToNegativeWidth()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newW = -100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, newW, rectangle.H);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: -100, H: 50, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual width does not match expected width");
        }

        [TestMethod]
        public void ResizeShapeToNegativeHeight()
        {
            //Arrange
            Invoker panel = Invoker.GetInstance();

            Visitor moveVisitor = new MoveVisitor();
            BaseShape rectangle = new Rect(X: 100, Y: 100, W: 50, H: 50, System.Drawing.Color.Black);
            int indexOfRectangle = 0;
            panel.InsertInShapes(indexOfRectangle, rectangle);
            panel.InsertInRectangles(rectangle.ConvertToRectangle());

            int newH = -100;
            Rectangle rectangleWithNewCoordinates = new Rectangle(rectangle.X, rectangle.Y, rectangle.W, newH);

            //Act
            moveVisitor.Visit((Rect)rectangle, indexOfRectangle, rectangleWithNewCoordinates, panel);

            //Assert
            BaseShape expectedShape = new Rect(X: 100, Y: 100, W: 50, H: -100, System.Drawing.Color.Black);
            Assert.AreEqual(expectedShape.X, panel.GetShape(indexOfRectangle).X, "Actual height does not match expected height");
        }
    }
}
