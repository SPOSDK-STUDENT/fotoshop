namespace fotoshop
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazitFotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazotFotoOVelikostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazit4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přehrávatFotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vykreslitKružniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.komprimaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.upravyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.výběrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.upravyToolStripMenuItem,
            this.výběrToolStripMenuItem,
            this.paletaToolStripMenuItem,
            this.hraToolStripMenuItem,
            this.pokusToolStripMenuItem,
            this.colorMapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.přehrávatFotoToolStripMenuItem,
            this.vykreslitKružniciToolStripMenuItem,
            this.komprimaceToolStripMenuItem,
            this.otevřítToolStripMenuItem,
            this.uložitJakoToolStripMenuItem,
            this.toolStripMenuItem5});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zobrazitFotoToolStripMenuItem,
            this.zobrazotFotoOVelikostiToolStripMenuItem,
            this.zobrazit4ToolStripMenuItem});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem6.Text = "Zobrazit";
            // 
            // zobrazitFotoToolStripMenuItem
            // 
            this.zobrazitFotoToolStripMenuItem.Name = "zobrazitFotoToolStripMenuItem";
            this.zobrazitFotoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.zobrazitFotoToolStripMenuItem.Text = "Zobrazit Foto";
            this.zobrazitFotoToolStripMenuItem.Click += new System.EventHandler(this.soubor_zobrazit_foto_Click);
            // 
            // zobrazotFotoOVelikostiToolStripMenuItem
            // 
            this.zobrazotFotoOVelikostiToolStripMenuItem.Name = "zobrazotFotoOVelikostiToolStripMenuItem";
            this.zobrazotFotoOVelikostiToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.zobrazotFotoOVelikostiToolStripMenuItem.Text = "Zobrazit foto o velikosti";
            // 
            // zobrazit4ToolStripMenuItem
            // 
            this.zobrazit4ToolStripMenuItem.Name = "zobrazit4ToolStripMenuItem";
            this.zobrazit4ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.zobrazit4ToolStripMenuItem.Text = "Zobrazit 4";
            this.zobrazit4ToolStripMenuItem.Click += new System.EventHandler(this.soubor_zobrazit_4_Click);
            // 
            // přehrávatFotoToolStripMenuItem
            // 
            this.přehrávatFotoToolStripMenuItem.Name = "přehrávatFotoToolStripMenuItem";
            this.přehrávatFotoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.přehrávatFotoToolStripMenuItem.Text = "Přehrávat foto";
            // 
            // vykreslitKružniciToolStripMenuItem
            // 
            this.vykreslitKružniciToolStripMenuItem.Name = "vykreslitKružniciToolStripMenuItem";
            this.vykreslitKružniciToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.vykreslitKružniciToolStripMenuItem.Text = "Vykreslit Kružnici";
            // 
            // komprimaceToolStripMenuItem
            // 
            this.komprimaceToolStripMenuItem.Name = "komprimaceToolStripMenuItem";
            this.komprimaceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.komprimaceToolStripMenuItem.Text = "Komprimace";
            // 
            // otevřítToolStripMenuItem
            // 
            this.otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            this.otevřítToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.otevřítToolStripMenuItem.Text = "Otevřít";
            this.otevřítToolStripMenuItem.Click += new System.EventHandler(this.soubor_otevrit_Click);
            // 
            // uložitJakoToolStripMenuItem
            // 
            this.uložitJakoToolStripMenuItem.Name = "uložitJakoToolStripMenuItem";
            this.uložitJakoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.uložitJakoToolStripMenuItem.Text = "Uložit Jako";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem5.Text = "Zpět";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.soubor_zpet_Click);
            // 
            // upravyToolStripMenuItem
            // 
            this.upravyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem8});
            this.upravyToolStripMenuItem.Name = "upravyToolStripMenuItem";
            this.upravyToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.upravyToolStripMenuItem.Text = "Upravy";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Černobílí";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem2.Text = "Černobílá";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.upravy_cernobili_cernobila_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem3.Text = "Bílá a Černá";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.upravy_cernobili_bilacerna_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem4.Text = "5 Odstínů šedi";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.upravy_cernobili_petodstinu_Click);
            // 
            // výběrToolStripMenuItem
            // 
            this.výběrToolStripMenuItem.Name = "výběrToolStripMenuItem";
            this.výběrToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.výběrToolStripMenuItem.Text = "Výběr";
            // 
            // paletaToolStripMenuItem
            // 
            this.paletaToolStripMenuItem.Name = "paletaToolStripMenuItem";
            this.paletaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.paletaToolStripMenuItem.Text = "Paleta";
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.hraToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.hraToolStripMenuItem.Text = "Hra";
            // 
            // pokusToolStripMenuItem
            // 
            this.pokusToolStripMenuItem.Name = "pokusToolStripMenuItem";
            this.pokusToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.pokusToolStripMenuItem.Text = "Pokus";
            // 
            // colorMapToolStripMenuItem
            // 
            this.colorMapToolStripMenuItem.Name = "colorMapToolStripMenuItem";
            this.colorMapToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.colorMapToolStripMenuItem.Text = "ColorMap";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem9});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem8.Text = "Odstíny Barvy";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem7.Text = "Odstíny 5 barev";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.upravy_odstinybarvy_5barev_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem9.Text = "5 odstínů barvy";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.upravy_odstinybarvy_5odstinu1barvy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fotošop";
            this.Move += new System.EventHandler(this.form_redraw);
            this.Resize += new System.EventHandler(this.form_redraw);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přehrávatFotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vykreslitKružniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem komprimaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem výběrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paletaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pokusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem zobrazitFotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobrazotFotoOVelikostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobrazit4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
    }
}

