using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DesignPatterns
{
    /// <summary>
    /// invoker class die commands laat uitvoeren, tevens een singleton
    /// </summary>
    public class Invoker
    {
        //stack met commands die uitgevoerd zijn
        private List<Command> doneStack = new List<Command>();
        //stack met commands die undone zijn
        private List<Command> undoneStack = new List<Command>();
        //lijsten met de vormen(Rectangle/BaseShape) die op de panel getekend zijn
        private List<Rectangle> rectangles = new List<Rectangle>();
        private List<BaseShape> shapes = new List<BaseShape>();
        //command die de invoker kan laten uitvoeren
        private Command command;
        //instantie van singleton
        private static Invoker instance;
        
        private Invoker() { }
        /// <summary>
        /// private constructor, omdat het een singleton is mag dit niet public zijn
        /// </summary>
        /// <param name="command">command die de invoker kan laten uitvoeren</param>
        private Invoker(Command command)
        {
            this.command = command;
        }

        /// <summary>
        /// sets command van invoker
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(Command command)
        {
            this.command = command;
        }

        /// <summary>
        /// laat een command executen
        /// </summary>
        /// <param name="g">Graphics waarmee een command kan tekenen</param>
        public void Execute(Graphics g)
        {
            command.Execute(g);
            //wanneer een command is uitgevoerd, wordt hij toegevoegd aan de lijst met uitgevoerde commands
            if(command.ToString() == "DesignPatterns.DrawCommand")
            {
                //alleen drawcommands toevoegen, savecommands toevoegen geeft errors
                InsertInDone(command);
            }            
        }

        public void Execute()
        {
            command.Execute();
        }

        /// <summary>
        /// methode die een command undoet
        /// </summary>
        /// <param name="g">Graphics waarmee getekent kan worden</param>
        public void Undo(Graphics g)
        {
            if (doneStack.Count() != 0)
            {
                //bovenste command pakken
                Command command = doneStack.ElementAt(doneStack.Count - 1);
                //bij redraw worden alle vormen opnieuw getekent, dus 4 tekeningen bij 2 vormen
                if (doneStack.Count() > shapes.Count())
                {
                    //duplicates verwijderen
                    while(doneStack.Count() > shapes.Count())
                    {
                        int i = 0;
                        doneStack.RemoveAt(i);
                        i++;
                    }
                    doneStack.RemoveAt(doneStack.Count() - 1);
                    shapes.RemoveAt(shapes.Count() - 1);
                    rectangles.RemoveAt(rectangles.Count() - 1);
                }
                //als er geen duplicates zijn, alleen het bovenste command verwijderen
                else 
                {
                    doneStack.RemoveAt(doneStack.Count() - 1);
                    shapes.RemoveAt(shapes.Count() - 1);
                    rectangles.RemoveAt(rectangles.Count() - 1);
                }
                //bij undone ook als child verwijderen
                BaseShape child = command.GetReceiver();
                for (int i = 0; i < rectangles.Count(); i++)
                {
                    BaseShape parent = GetShape(i);
                    for (int j = 0; j < parent.childs.Count(); j++)
                    {
                        BaseShape check = parent.childs.ElementAt(j);
                        if (check.X == child.X && check.Y == child.Y && check.W == child.W && check.H == child.H)
                        {
                            parent.childs.RemoveAt(j);
                            break;
                        }
                    }
                }
                //het command wat undone is toevoegen aan undone stack
                InsertInUndone(command);

                //opniew tekenen, dus zonder laatst toegevoegde vorm
                g.Clear(Color.White);
                for (int i = 0; i < doneStack.Count(); i++)
                {
                    Command redoCommand = doneStack.ElementAt(i);
                    Invoker panel = new Invoker(redoCommand);
                    panel.Execute(g);
                }                
            }
        }

        /// <summary>
        /// methode die een undone command redoet
        /// </summary>
        /// <param name="g">Graphics waarmee getekent wordt</param>
        public void Redo(Graphics g)
        {
            if (undoneStack.Count() != 0)
            {
                //bovenste command pakken van undone stack
                Command command = undoneStack.ElementAt(undoneStack.Count - 1);
                undoneStack.RemoveAt(undoneStack.Count() - 1);

                //toevoegen aan donestack                               
                doneStack.Add(command);
                BaseShape backup = command.GetReceiver();
                Rectangle backupp = backup.ConvertToRectangle();
                shapes.Add(backup);
                rectangles.Add(backupp);

                //alle donestack commands opnieuw uitvoeren, dus inclusief redone command
                g.Clear(Color.White);
                for (int i = 0; i < doneStack.Count(); i++)
                {
                    Command redoCommand = doneStack.ElementAt(i);
                    Invoker panel = new Invoker(redoCommand);
                    panel.Execute(g);
                }
            }
        }

        /// <summary>
        /// command in private done stack toevoegen
        /// </summary>
        /// <param name="command">command die toegevoegd wordt</param>
        public void InsertInDone(Command command)
        {
            doneStack.Add(command);
        }

        /// <summary>
        /// command in private stack undone toevoegen
        /// </summary>
        /// <param name="command">command dat toegevoegd wordt</param>
        public void InsertInUndone(Command command)
        {
            undoneStack.Add(command);
        }

        /// <summary>
        /// Rectangle op specifieke index in private Rectangle lijst toevoegen
        /// </summary>
        /// <param name="index">index waarin hij wordt toegevoegd</param>
        /// <param name="rhoek">rectangle die toegevoegd wordt</param>
        public void InsertInRectangles(int index, Rectangle rhoek)
        {
            rectangles.Insert(index, rhoek);
        }

        /// <summary>
        /// Rectangle in private Rectangle lijst toevoegen
        /// </summary>
        /// <param name="rhoek">rechthoek die toegevoegd wordt</param>
        public void InsertInRectangles(Rectangle rhoek)
        {
            rectangles.Add(rhoek);
        }

        /// <summary>
        /// Rectangle uit private lijst rectangles halen, op index
        /// </summary>
        /// <param name="index">index van de te verwijderen rectangle</param>
        public void RemoveFromRectangles(int index)
        {
            rectangles.RemoveAt(index);
        }

        /// <summary>
        /// shape in private lijst shapes toevoegen, op specifieke index
        /// </summary>
        /// <param name="index">index van shape</param>
        /// <param name="shape">shape die toegevoegd gaat worden</param>
        public void InsertInShapes(int index, BaseShape shape)
        {
            shapes.Insert(index, shape);
        }

        /// <summary>
        /// shape aan private lijst shapes toevoegen
        /// </summary>
        /// <param name="shape">shape die toegevoegd wordt</param>
        public void InsertInShapes(BaseShape shape)
        {
            shapes.Add(shape);
        }

        /// <summary>
        /// shape uit private lijst halen aan de hand van index
        /// </summary>
        /// <param name="index">index van de te verwijderen shape</param>
        public void RemoveFromShapes(int index)
        {
            shapes.RemoveAt(index);
        }

        /// <summary>
        /// shape ophalen aan de hand van zijn index
        /// </summary>
        /// <param name="index">index van shape</param>
        /// <returns>shape die gevraagd is</returns>
        public BaseShape GetShape(int index)
        {
            return shapes.ElementAt(index);
        }

        /// <summary>
        /// rectangle ophalen aan de hand van zijn index
        /// </summary>
        /// <param name="index">index van rectangle</param>
        /// <returns>rectangle die gevraagd is</returns>
        public Rectangle GetRectangle(int index)
        {
            return rectangles.ElementAt(index);
        }

        /// <summary>
        /// grootte van Rectangle lijst ophalen
        /// </summary>
        /// <returns>grootte van lijst</returns>
        public int GetRectangleCount()
        {
            return rectangles.Count();
        }

        /// <summary>
        /// singleton instantie ophalen
        /// </summary>
        /// <returns>instantie van singleton</returns>
        public static Invoker GetInstance()
        {
            if(instance == null)
            {
                instance = new Invoker();
            }
            return instance;
        }
    }
}
