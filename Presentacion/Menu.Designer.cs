namespace Presentacion
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEditorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFORMESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESERVASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.iNFORMESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1183, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.salirToolStripMenuItem.Text = "SALIR";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMLibroToolStripMenuItem,
            this.aBMEditorialToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.aBMToolStripMenuItem.Text = "ABM";
            // 
            // aBMLibroToolStripMenuItem
            // 
            this.aBMLibroToolStripMenuItem.Name = "aBMLibroToolStripMenuItem";
            this.aBMLibroToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.aBMLibroToolStripMenuItem.Text = "ABM Libro";
            this.aBMLibroToolStripMenuItem.Click += new System.EventHandler(this.aBMLibroToolStripMenuItem_Click);
            // 
            // aBMEditorialToolStripMenuItem
            // 
            this.aBMEditorialToolStripMenuItem.Name = "aBMEditorialToolStripMenuItem";
            this.aBMEditorialToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.aBMEditorialToolStripMenuItem.Text = "ABM Editorial";
            this.aBMEditorialToolStripMenuItem.Click += new System.EventHandler(this.aBMEditorialToolStripMenuItem_Click);
            // 
            // iNFORMESToolStripMenuItem
            // 
            this.iNFORMESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.rESERVASToolStripMenuItem});
            this.iNFORMESToolStripMenuItem.Name = "iNFORMESToolStripMenuItem";
            this.iNFORMESToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.iNFORMESToolStripMenuItem.Text = "INFORMES";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cLIENTESToolStripMenuItem.Text = "INFORMES";
            this.cLIENTESToolStripMenuItem.Click += new System.EventHandler(this.cLIENTESToolStripMenuItem_Click);
            // 
            // rESERVASToolStripMenuItem
            // 
            this.rESERVASToolStripMenuItem.Name = "rESERVASToolStripMenuItem";
            this.rESERVASToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rESERVASToolStripMenuItem.Text = "RESERVAS Y PAGOS";
            this.rESERVASToolStripMenuItem.Click += new System.EventHandler(this.rESERVASToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1183, 554);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Leer más";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEditorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNFORMESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESERVASToolStripMenuItem;
    }
}

