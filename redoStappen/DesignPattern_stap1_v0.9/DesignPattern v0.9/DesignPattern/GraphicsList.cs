#region Using directives

using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Reflection;


#endregion

namespace DesignPattern {
    class GraphicsList{
        private List<DrawObject> graphicsList;
        public GraphicsList() { graphicsList = new List<DrawObject>(); }
        public void Draw(Graphics g) {
            int n = graphicsList.Count;
            DrawObject o;
            for (int i = n - 1; i >= 0; i--) {
                o = graphicsList[i];
                o.Draw(g);
                if (o.Selected == true) o.DrawTracker(g); } }

        public int Count { get { return graphicsList.Count; } }

        public DrawObject this[int index] {
            get {
                if (index < 0 || index >= graphicsList.Count) return null;
                return graphicsList[index]; } }

        public int SelectionCount {
            get {
                int n = 0;
                foreach (DrawObject o in Selection) {
                    n++; }
                return n; } }

        public IEnumerable<DrawObject> Selection {
            get {
                foreach (DrawObject o in graphicsList) {
                    if (o.Selected) yield return o; } } }

        public void Add(DrawObject obj) { graphicsList.Insert(0, obj); }
        public void SelectInRectangle(Rectangle rectangle) {
            UnselectAll();
            foreach (DrawObject o in graphicsList) {
                if (o.IntersectsWith(rectangle)) o.Selected = true; } }
        public void UnselectAll() {
            foreach (DrawObject o in graphicsList) {
                o.Selected = false; } }
    }
}
