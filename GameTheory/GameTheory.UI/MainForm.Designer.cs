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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblInitialGameState = new System.Windows.Forms.Label();
            this.tbInputN = new System.Windows.Forms.TextBox();
            this.tbGameLogic = new System.Windows.Forms.TextBox();
            this.lblInputLogic = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.pnlInputLogic.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(997, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // pnlInputLogic
            // 
            this.pnlInputLogic.Controls.Add(this.lblResult);
            this.pnlInputLogic.Controls.Add(this.btnCalculate);
            this.pnlInputLogic.Controls.Add(this.lblInitialGameState);
            this.pnlInputLogic.Controls.Add(this.tbInputN);
            this.pnlInputLogic.Controls.Add(this.tbGameLogic);
            this.pnlInputLogic.Controls.Add(this.lblInputLogic);
            this.pnlInputLogic.Location = new System.Drawing.Point(15, 121);
            this.pnlInputLogic.Name = "pnlInputLogic";
            this.pnlInputLogic.Size = new System.Drawing.Size(237, 200);
            this.pnlInputLogic.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(122, 108);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Порахувати";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblInitialGameState
            // 
            this.lblInitialGameState.AutoSize = true;
            this.lblInitialGameState.Location = new System.Drawing.Point(3, 92);
            this.lblInitialGameState.Name = "lblInitialGameState";
            this.lblInitialGameState.Size = new System.Drawing.Size(167, 13);
            this.lblInitialGameState.TabIndex = 3;
            this.lblInitialGameState.Text = "Введіть початковий стан гри (n)";
            // 
            // tbInputN
            // 
            this.tbInputN.Location = new System.Drawing.Point(6, 108);
            this.tbInputN.Name = "tbInputN";
            this.tbInputN.Size = new System.Drawing.Size(100, 20);
            this.tbInputN.TabIndex = 2;
            // 
            // tbGameLogic
            // 
            this.tbGameLogic.Location = new System.Drawing.Point(6, 36);
            this.tbGameLogic.Name = "tbGameLogic";
            this.tbGameLogic.Size = new System.Drawing.Size(100, 20);
            this.tbGameLogic.TabIndex = 1;
            // 
            // lblInputLogic
            // 
            this.lblInputLogic.AutoSize = true;
            this.lblInputLogic.Location = new System.Drawing.Point(3, 10);
            this.lblInputLogic.Name = "lblInputLogic";
            this.lblInputLogic.Size = new System.Drawing.Size(194, 13);
            this.lblInputLogic.TabIndex = 0;
            this.lblInputLogic.Text = "Зі стану n гра може перейти у стани:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(36, 157);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(67, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "результат...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 479);
            this.Controls.Add(this.pnlInputLogic);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "С";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlInputLogic.ResumeLayout(false);
            this.pnlInputLogic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
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

