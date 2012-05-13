using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTheory.SpragueGrundy.Games;
using GameTheory.UI.Parser;
using Microsoft.Glee.Drawing;

namespace GameTheory.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var gameLogic = tbGameLogic.Text;
                var transitions = GameLogicParser.ParseMultipleTransitions(gameLogic);
                var solver = new GenericGrundyGame(transitions);
                var n = int.Parse(tbInputN.Text);

                Graph g = solver.GetTransitionsGraph(n);

                lblResult.Text = solver.SGValue(n).Str();

                gViewer.Graph = g;
                gViewer.Invalidate();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Неправильно введені параметри гри. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася невідома помилка: " + ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var exp1 = "i&n-i-1,i=0..n-1";
            var exp2 = "n-1;n-2;n-3";
            var exp3 = "n-i,i=1..3";
            tbGameLogic.Text = exp3;
            tbInputN.Text = "20";
        }

        object selectedObject;
        void gViewer_SelectionChanged(object sender, EventArgs e)
        {
            selectedObject = gViewer.SelectedObject;

            var edge = gViewer.SelectedObject as Edge;
            if (edge != null)
            {
                edge.Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
            }

            else
            {
                var node = selectedObject as Node;
                if (node != null)
                {
                    node.Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                    node.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
                }
            }
            gViewer.Invalidate();
        }
    }
}
