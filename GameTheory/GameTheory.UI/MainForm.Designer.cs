using System.Windows.Forms;
using Microsoft.Glee.GraphViewerGdi;

namespace GameTheory.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.pnlInputLogic = new System.Windows.Forms.Panel();
            this.btnKaylesGame = new System.Windows.Forms.Button();
            this.btnDawsonsChessGame = new System.Windows.Forms.Button();
            this.btnSubstractionGame = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblInitialGameState = new System.Windows.Forms.Label();
            this.tbInputN = new System.Windows.Forms.TextBox();
            this.tbGameLogic = new System.Windows.Forms.TextBox();
            this.lblInputLogic = new System.Windows.Forms.Label();
            this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.clmnIterator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGrundyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.pnlInputLogic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1028, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // pnlInputLogic
            // 
            this.pnlInputLogic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInputLogic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInputLogic.Controls.Add(this.btnKaylesGame);
            this.pnlInputLogic.Controls.Add(this.btnDawsonsChessGame);
            this.pnlInputLogic.Controls.Add(this.btnSubstractionGame);
            this.pnlInputLogic.Controls.Add(this.lblResult);
            this.pnlInputLogic.Controls.Add(this.btnCalculate);
            this.pnlInputLogic.Controls.Add(this.lblInitialGameState);
            this.pnlInputLogic.Controls.Add(this.tbInputN);
            this.pnlInputLogic.Controls.Add(this.tbGameLogic);
            this.pnlInputLogic.Controls.Add(this.lblInputLogic);
            this.pnlInputLogic.Location = new System.Drawing.Point(12, 27);
            this.pnlInputLogic.Name = "pnlInputLogic";
            this.pnlInputLogic.Size = new System.Drawing.Size(176, 399);
            this.pnlInputLogic.TabIndex = 2;
            // 
            // btnKaylesGame
            // 
            this.btnKaylesGame.Location = new System.Drawing.Point(6, 91);
            this.btnKaylesGame.Name = "btnKaylesGame";
            this.btnKaylesGame.Size = new System.Drawing.Size(160, 23);
            this.btnKaylesGame.TabIndex = 8;
            this.btnKaylesGame.Text = "гра \"Кеглі\"";
            this.btnKaylesGame.UseVisualStyleBackColor = true;
            this.btnKaylesGame.Click += new System.EventHandler(this.btnKaylesGame_Click);
            // 
            // btnDawsonsChessGame
            // 
            this.btnDawsonsChessGame.Location = new System.Drawing.Point(6, 120);
            this.btnDawsonsChessGame.Name = "btnDawsonsChessGame";
            this.btnDawsonsChessGame.Size = new System.Drawing.Size(160, 23);
            this.btnDawsonsChessGame.TabIndex = 7;
            this.btnDawsonsChessGame.Text = "гра \"Шахи Доусона\"";
            this.btnDawsonsChessGame.UseVisualStyleBackColor = true;
            this.btnDawsonsChessGame.Click += new System.EventHandler(this.btnDawsonsChessGame_Click);
            // 
            // btnSubstractionGame
            // 
            this.btnSubstractionGame.Location = new System.Drawing.Point(6, 62);
            this.btnSubstractionGame.Name = "btnSubstractionGame";
            this.btnSubstractionGame.Size = new System.Drawing.Size(160, 23);
            this.btnSubstractionGame.TabIndex = 6;
            this.btnSubstractionGame.Text = "гра \"Віднімашки\"";
            this.btnSubstractionGame.UseVisualStyleBackColor = true;
            this.btnSubstractionGame.Click += new System.EventHandler(this.btnSubstractionGame_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(3, 374);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(6, 335);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(160, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Обчислити";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblInitialGameState
            // 
            this.lblInitialGameState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInitialGameState.AutoSize = true;
            this.lblInitialGameState.Location = new System.Drawing.Point(3, 293);
            this.lblInitialGameState.Name = "lblInitialGameState";
            this.lblInitialGameState.Size = new System.Drawing.Size(167, 13);
            this.lblInitialGameState.TabIndex = 3;
            this.lblInitialGameState.Text = "Введіть початковий стан гри (n)";
            // 
            // tbInputN
            // 
            this.tbInputN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbInputN.Location = new System.Drawing.Point(6, 309);
            this.tbInputN.Name = "tbInputN";
            this.tbInputN.Size = new System.Drawing.Size(160, 20);
            this.tbInputN.TabIndex = 2;
            this.tbInputN.Text = "10";
            // 
            // tbGameLogic
            // 
            this.tbGameLogic.Location = new System.Drawing.Point(6, 36);
            this.tbGameLogic.Multiline = true;
            this.tbGameLogic.Name = "tbGameLogic";
            this.tbGameLogic.Size = new System.Drawing.Size(160, 20);
            this.tbGameLogic.TabIndex = 1;
            this.tbGameLogic.Text = "n-i, i=1..3";
            this.tbGameLogic.WordWrap = false;
            // 
            // lblInputLogic
            // 
            this.lblInputLogic.AutoSize = true;
            this.lblInputLogic.Location = new System.Drawing.Point(3, 10);
            this.lblInputLogic.Name = "lblInputLogic";
            this.lblInputLogic.Size = new System.Drawing.Size(163, 13);
            this.lblInputLogic.TabIndex = 0;
            this.lblInputLogic.Text = "Задайте переходи для стану n:";
            // 
            // gViewer
            // 
            this.gViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.Location = new System.Drawing.Point(324, 27);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = true;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.Size = new System.Drawing.Size(692, 399);
            this.gViewer.TabIndex = 3;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            this.gViewer.SelectionChanged += new System.EventHandler(this.gViewer_SelectionChanged);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIterator,
            this.clmnGrundyValue});
            this.dgvResults.Location = new System.Drawing.Point(194, 27);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.Size = new System.Drawing.Size(124, 399);
            this.dgvResults.TabIndex = 4;
            // 
            // clmnIterator
            // 
            this.clmnIterator.Frozen = true;
            this.clmnIterator.HeaderText = "i";
            this.clmnIterator.Name = "clmnIterator";
            this.clmnIterator.ReadOnly = true;
            this.clmnIterator.Width = 20;
            // 
            // clmnGrundyValue
            // 
            this.clmnGrundyValue.Frozen = true;
            this.clmnGrundyValue.HeaderText = "Значення Шпрага-Гранді";
            this.clmnGrundyValue.Name = "clmnGrundyValue";
            this.clmnGrundyValue.ReadOnly = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Вийти";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.вийтиToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.helpToolStripMenuItem.Text = "Допомога";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.infoToolStripMenuItem.Text = "Довідка";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 438);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.gViewer);
            this.Controls.Add(this.pnlInputLogic);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "Функція Шпрага-Гранді";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.pnlInputLogic.ResumeLayout(false);
            this.pnlInputLogic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.Panel pnlInputLogic;
        private System.Windows.Forms.TextBox tbGameLogic;
        private System.Windows.Forms.Label lblInputLogic;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblInitialGameState;
        private System.Windows.Forms.TextBox tbInputN;
        private System.Windows.Forms.Label lblResult;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn clmnIterator;
        private DataGridViewTextBoxColumn clmnGrundyValue;
        private Button btnKaylesGame;
        private Button btnDawsonsChessGame;
        private Button btnSubstractionGame;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
    }
}

