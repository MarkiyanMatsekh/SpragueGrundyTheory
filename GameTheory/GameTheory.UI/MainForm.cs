﻿using System;
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
                var list = CalculateSpragueGrundyUpTo(n, solver);

                UpdateGrid(list);
                lblResult.Text = solver.SGValue(n) > 0 ? "Виграшна ситуація" : "Програшна ситуація";
                gViewer.Graph = g;
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

        private void UpdateGrid(List<uint> results)
        {
            dgvResults.Rows.Clear();

            dgvResults.Rows.Add(results.Count);

            for (int i = 0; i < results.Count; i++)
            {
                dgvResults[0, i].Value = i;
                dgvResults[1, i].Value = results[i];
            }

        }

        private List<uint> CalculateSpragueGrundyUpTo(int key, GenericGrundyGame game)
        {
            var list = new List<uint>();

            for (int i = 0; i <= key; i++)
            {
                var value = game.SGValue(i);
                list.Add(value);
            }

            return list;
        }

        object selectedObject;
        object selectedObjectAttr;
        void gViewer_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                var edge1 = selectedObject as Edge;
                if (edge1 != null)
                    edge1.Attr = selectedObjectAttr as EdgeAttr;
                else
                {
                    var node1 = selectedObject as Node;
                    if (node1 != null)
                        node1.Attr = selectedObjectAttr as NodeAttr;
                }
                selectedObject = null;
            }

            selectedObject = gViewer.SelectedObject;

            var edge = gViewer.SelectedObject as Edge;
            if (edge != null)
            {
                selectedObjectAttr = edge.Attr.Clone();

                if (edge.Attr.Color == Microsoft.Glee.Drawing.Color.Black)
                {
                    edge.Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                    edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
                }
                edge.Attr.LineWidth *= 2;
            }

            else
            {
                var node = selectedObject as Node;
                if (node != null)
                {
                    selectedObjectAttr = node.Attr.Clone();

                    if (node.Attr.Color == Microsoft.Glee.Drawing.Color.Black)
                    {
                        node.Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                        node.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
                    }
                    node.Attr.LineWidth *= 2;
                }
            }
            gViewer.Invalidate();
        }

        private void btnDawsonsChessGame_Click(object sender, EventArgs e)
        {
            var game = "n-2; i-2 & n-i-1, i=2..n-1";
            tbGameLogic.Text = game;
        }

        private void btnSubstractionGame_Click(object sender, EventArgs e)
        {
            var substractions = "n-i, i=1..3";
            tbGameLogic.Text = substractions;
        }

        private void btnKaylesGame_Click(object sender, EventArgs e)
        {
            var kayles = "i & n-i-1, i=0..n-1; i & n-i-2, i=0..n-2;";
            tbGameLogic.Text = kayles;

        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form= new Help();
            form.ShowDialog();
        }
    }
}
