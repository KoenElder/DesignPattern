using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern {
    class Delete : Command {
        List<DrawObject> cloneList;
        List<int> indexList;
        public Delete(GraphicsList graphicsList) {
            cloneList = new List<DrawObject>();
            indexList = new List<int>();
            for (int index = graphicsList.Count - 1; index >= 0; index--) {
                if (graphicsList[index].Selected) {
                    indexList.Add(index);
                    cloneList.Add(graphicsList[index].Clone()); } } }

        public override void Undo(GraphicsList graphicsList) {
            graphicsList.UnselectAll();
            for (int index = cloneList.Count - 1; index >= 0; index--) {
                graphicsList.Insert(indexList[index], cloneList[index]); }
        }
        public override void Redo(GraphicsList graphicsList) {
            for (int index = indexList.Count - 1; index >= 0; index--) {
                graphicsList.RemoveAt(indexList[index]); }
        }
    }
}
