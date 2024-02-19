namespace fotoshop
{
    partial class vyrez
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.načístBitovouMapuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyříznoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navrátitVyříznutéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.načístBitovouMapuToolStripMenuItem,
            this.vyříznoutToolStripMenuItem,
            this.navrátitVyříznutéToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // načístBitovouMapuToolStripMenuItem
            // 
            this.načístBitovouMapuToolStripMenuItem.Name = "načístBitovouMapuToolStripMenuItem";
            this.načístBitovouMapuToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.načístBitovouMapuToolStripMenuItem.Text = "Načíst Bitovou Mapu";
            this.načístBitovouMapuToolStripMenuItem.Click += new System.EventHandler(this.načístBitovouMapuToolStripMenuItem_Click);
            // 
            // vyříznoutToolStripMenuItem
            // 
            this.vyříznoutToolStripMenuItem.Name = "vyříznoutToolStripMenuItem";
            this.vyříznoutToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.vyříznoutToolStripMenuItem.Text = "Vyříznout Označené";
            this.vyříznoutToolStripMenuItem.Click += new System.EventHandler(this.vyříznoutToolStripMenuItem_Click);
            // 
            // navrátitVyříznutéToolStripMenuItem
            // 
            this.navrátitVyříznutéToolStripMenuItem.Name = "navrátitVyříznutéToolStripMenuItem";
            this.navrátitVyříznutéToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.navrátitVyříznutéToolStripMenuItem.Text = "Navrátit Vyříznuté";
            this.navrátitVyříznutéToolStripMenuItem.Click += new System.EventHandler(this.navrátitVyříznutéToolStripMenuItem_Click);
            // 
            // vyrez
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "vyrez";
            this.Text = "Dialogové Okno Výřezu Obrázku";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem načístBitovouMapuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyříznoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navrátitVyříznutéToolStripMenuItem;
    }
}