using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignPattern
{
    class UndoRedo {
        GraphicsList graphicsList;
        List<Command> historyList;
        int nextUndo;

        public UndoRedo(GraphicsList graphicsList) {
            this.graphicsList = graphicsList;
            ClearHistory(); }

        public void Undo() {
            if (canUndo) {
                Command command = historyList[nextUndo];
                command.Undo(graphicsList);
                nextUndo--; } }

        public void Redo()
        {
            if (canRedo) {
                int itemToRedo = nextUndo + 1;
                Command command = historyList[itemToRedo];
                command.Redo(graphicsList);
                nextUndo++; } }

        public bool canUndo { get { if (nextUndo < 0 || nextUndo > historyList.Count - 1) return false; else return true; } }
        public bool canRedo { get { if (nextUndo == historyList.Count - 1) return false; else return true; } }

        public void ClearHistory() { historyList = new List<Command>(); nextUndo = -1; }
        public void AddCommand(Command command) {
            this.TrimHistoryList();
            historyList.Add(command);
            nextUndo++;
        }

        private void TrimHistoryList() {
            if (historyList.Count == 0) return;
            if (nextUndo == historyList.Count - 1) return;
            for (int index = historyList.Count - 1; index > nextUndo; index--)
                historyList.RemoveAt(index);
        }
    }
}
