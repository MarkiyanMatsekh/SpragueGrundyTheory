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
            this.pnlInputParams = new System.Windows.Forms.Panel();
            this.tbGameParam = new System.Windows.Forms.TextBox();
            this.btnAddGameParam = new System.Windows.Forms.Button();
            this.pnlInputLogic = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblInputLogic = new System.Windows.Forms.Label();
            this.pnlInputParams.SuspendLayout();
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
            // pnlInputParams
            // 
            this.pnlInputParams.Controls.Add(this.tbGameParam);
            this.pnlInputParams.Controls.Add(this.btnAddGameParam);
            this.pnlInputParams.Location = new System.Drawing.Point(12, 12);
            this.pnlInputParams.Name = "pnlInputParams";
            this.pnlInputParams.Size = new System.Drawing.Size(157, 87);
            this.pnlInputParams.TabIndex = 1;
            // 
            // tbGameParam
            // 
            this.tbGameParam.Location = new System.Drawing.Point(3, 15);
            this.tbGameParam.Name = "tbGameParam";
            this.tbGameParam.Size = new System.Drawing.Size(100, 20);
            this.tbGameParam.TabIndex = 1;
            // 
            // btnAddGameParam
            // 
            this.btnAddGameParam.Location = new System.Drawing.Point(109, 12);
            this.btnAddGameParam.Name = "btnAddGameParam";
            this.btnAddGameParam.Size = new System.Drawing.Size(27, 23);
            this.btnAddGameParam.TabIndex = 0;
            this.btnAddGameParam.Text = "+";
            this.btnAddGameParam.UseVisualStyleBackColor = true;
            // 
            // pnlInputLogic
            // 
            this.pnlInputLogic.Controls.Add(this.textBox1);
            this.pnlInputLogic.Controls.Add(this.lblInputLogic);
            this.pnlInputLogic.Location = new System.Drawing.Point(15, 121);
            this.pnlInputLogic.Name = "pnlInputLogic";
            this.pnlInputLogic.Size = new System.Drawing.Size(237, 200);
            this.pnlInputLogic.TabIndex = 2;
            // S
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblInputLogic
            // 
            this.lblInputLogic.AutoSize = true;
            this.lblInputLogic.Location = new System.Drawing.Point(3, 10);
            this.lblInputLogic.Name = "lblInputLogic";
            this.lblInputLogic.Size = new System.Drawing.Size(194, 13);
            this.lblInputLogic.TabIndex = 0;
            this.lblInputLogic.Text = "Зі стану n гра може перейти у стани:";
            this.lblInputLogic.Click += new System.EventHandler(this.lblInputLogic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 479);
            this.Controls.Add(this.pnlInputLogic);
            this.Controls.Add(this.pnlInputParams);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "С";
            this.pnlInputParams.ResumeLayout(false);
            this.pnlInputParams.PerformLayout();
            this.pnlInputLogic.ResumeLayout(false);
            this.pnlInputLogic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.Panel pnlInputParams;
        private System.Windows.Forms.TextBox tbGameParam;
        private System.Windows.Forms.Button btnAddGameParam;
        private System.Windows.Forms.Panel pnlInputLogic;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblInputLogic;
    }
}

