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
                lblResult.Text = solver.SGValue(n).ToString();
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


    }
}
