﻿using System.Windows.Forms;
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblInitialGameState = new System.Windows.Forms.Label();
            this.tbInputN = new System.Windows.Forms.TextBox();
            this.tbGameLogic = new System.Windows.Forms.TextBox();
            this.lblInputLogic = new System.Windows.Forms.Label();
            this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.pnlInputLogic.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1028, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // pnlInputLogic
            // 
            this.pnlInputLogic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInputLogic.Controls.Add(this.lblResult);
            this.pnlInputLogic.Controls.Add(this.btnCalculate);
            this.pnlInputLogic.Controls.Add(this.lblInitialGameState);
            this.pnlInputLogic.Controls.Add(this.tbInputN);
            this.pnlInputLogic.Controls.Add(this.tbGameLogic);
            this.pnlInputLogic.Controls.Add(this.lblInputLogic);
            this.pnlInputLogic.Location = new System.Drawing.Point(12, 27);
            this.pnlInputLogic.Name = "pnlInputLogic";
            this.pnlInputLogic.Size = new System.Drawing.Size(176, 200);
            this.pnlInputLogic.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(3, 149);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(67, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "результат...";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 110);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(160, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Порахувати";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblInitialGameState
            // 
            this.lblInitialGameState.AutoSize = true;
            this.lblInitialGameState.Location = new System.Drawing.Point(3, 68);
            this.lblInitialGameState.Name = "lblInitialGameState";
            this.lblInitialGameState.Size = new System.Drawing.Size(167, 13);
            this.lblInitialGameState.TabIndex = 3;
            this.lblInitialGameState.Text = "Введіть початковий стан гри (n)";
            // 
            // tbInputN
            // 
            this.tbInputN.Location = new System.Drawing.Point(6, 84);
            this.tbInputN.Name = "tbInputN";
            this.tbInputN.Size = new System.Drawing.Size(160, 20);
            this.tbInputN.TabIndex = 2;
            // 
            // tbGameLogic
            // 
            this.tbGameLogic.Location = new System.Drawing.Point(6, 36);
            this.tbGameLogic.Multiline = true;
            this.tbGameLogic.Name = "tbGameLogic";
            this.tbGameLogic.Size = new System.Drawing.Size(160, 20);
            this.tbGameLogic.TabIndex = 1;
            this.tbGameLogic.WordWrap = false;
            // 
            // lblInputLogic
            // 
            this.lblInputLogic.AutoSize = true;
            this.lblInputLogic.Location = new System.Drawing.Point(3, 10);
            this.lblInputLogic.Name = "lblInputLogic";
            this.lblInputLogic.Size = new System.Drawing.Size(163, 13);
            this.lblInputLogic.TabIndex = 0;
            this.lblInputLogic.Text = "Задайте переходи дял стану n:";
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
            this.gViewer.Location = new System.Drawing.Point(194, 27);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = true;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.Size = new System.Drawing.Size(822, 399);
            this.gViewer.TabIndex = 3;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            this.gViewer.SelectionChanged += new System.EventHandler(this.gViewer_SelectionChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 438);
            this.Controls.Add(this.gViewer);
            this.Controls.Add(this.pnlInputLogic);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "Функція Шпрага-Гранді";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlInputLogic.ResumeLayout(false);
            this.pnlInputLogic.PerformLayout();
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
    }
}

