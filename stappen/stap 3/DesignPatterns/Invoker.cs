using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    class Invoker
    {
        public bool redraw = false;
        private bool redo = false;
        private bool newChar = true;
        private List<Command> doneStack = new List<Command>();
        private List<Command> undoneStack = new List<Command>();
        private List<Rectangle> rectangles = new List<Rectangle>();
        private List<Receiver> shapes = new List<Receiver>();
        private Command command;
        
        public Invoker() { }
        public Invoker(Command command)
        {
            this.command = command;
        }

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void Execute(Graphics g)
        {
            command.Execute(g);
            InsertInDone(command);
            newChar = true;
            redraw = false;
            if(redo == true)
            {
                redraw = true;
                newChar = false;
            }
        }

        public void Undo(Graphics g)
        {
            if (doneStack.Count() != 0)
            {
                Command command = doneStack.ElementAt(doneStack.Count - 1);
                if(redraw == true)
                {
                    for (int i = shapes.Count() - 1; i < doneStack.Count(); i++)
                    {
                        doneStack.RemoveAt(doneStack.Count - 1);
                    }
                    if (undoneStack.Count != 0)
                    {
                        Redo(g);
                        return;
                    }
                }
                //else { 
                if(newChar == true) { 
                    doneStack.RemoveAt(doneStack.Count() - 1);
                    shapes.RemoveAt(shapes.Count() - 1);
                    rectangles.RemoveAt(rectangles.Count() - 1);
                }
                InsertInUndone(command);

                g.Clear(Color.White);

                for (int i = 0; i < doneStack.Count(); i++)
                {
                    Command redoCommand = doneStack.ElementAt(i);
                    Invoker panel = new Invoker(redoCommand);
                    panel.Execute(g);
                }                
            }
        }

        public void Redo(Graphics g)
        {
            redo = true;
            if (undoneStack.Count() != 0)
            {
                Command command = undoneStack.ElementAt(undoneStack.Count - 1);
                undoneStack.RemoveAt(undoneStack.Count() - 1);

                if(redraw == true)
                {
                    Command switched = doneStack.ElementAt(doneStack.Count() - 1);
                    doneStack.RemoveAt(doneStack.Count() - 1);
                    undoneStack.Add(switched);
                }
                else
                {
                    redraw = false;
                }
                               
                doneStack.Add(command);
                Receiver backup = command.GetReceiver();
                Rectangle backupp = backup.ConvertToRectangle();
                shapes.Add(backup);
                rectangles.Add(backupp);

                g.Clear(Color.White);

                for (int i = 0; i < doneStack.Count(); i++)
                {
                    Command redoCommand = doneStack.ElementAt(i);
                    Invoker panel = new Invoker(redoCommand);
                    panel.Execute(g);
                }
            }
        }

        public void InsertInDone(Command command)
        {
            doneStack.Add(command);
        }

        public void InsertInUndone(Command command)
        {
            undoneStack.Add(command);
        }

        public void InsertInRectangles(int index, Rectangle rhoek)
        {
            rectangles.Insert(index, rhoek);
            //rectangles.Add(rhoek);
        }

        public void InsertInRectangles(Rectangle rhoek)
        {
            rectangles.Add(rhoek);
        }

        public void RemoveFromRectangles(int index)
        {
            rectangles.RemoveAt(index);
        }

        public void InsertInShapes(int index, Receiver shape)
        {
            shapes.Insert(index, shape);
            //shapes.Add(shape);
        }

        public void InsertInShapes(Receiver shape)
        {
            shapes.Add(shape);
        }

        public void RemoveFromShapes(int index)
        {
            shapes.RemoveAt(index);
        }

        public Receiver GetShape(int index)
        {
            return shapes.ElementAt(index);
        }

        public Rectangle GetRectangle(int index)
        {
            return rectangles.ElementAt(index);
        }

        public int GetRectangleCount()
        {
            return rectangles.Count();
        }
    }
}
