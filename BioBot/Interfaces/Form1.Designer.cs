namespace BioBot
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.activerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dofusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerTousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nettoyerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.focusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.dofusToolStripMenuItem,
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1149, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activerToolStripMenuItem,
            this.desactiverToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "MITM";
            // 
            // activerToolStripMenuItem
            // 
            this.activerToolStripMenuItem.Name = "activerToolStripMenuItem";
            this.activerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.activerToolStripMenuItem.Text = "Activer";
            this.activerToolStripMenuItem.Click += new System.EventHandler(this.EnableMITM);
            // 
            // desactiverToolStripMenuItem
            // 
            this.desactiverToolStripMenuItem.Name = "desactiverToolStripMenuItem";
            this.desactiverToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.desactiverToolStripMenuItem.Text = "Desactiver";
            this.desactiverToolStripMenuItem.Click += new System.EventHandler(this.DisableMITM);
            // 
            // dofusToolStripMenuItem
            // 
            this.dofusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.fermerTousToolStripMenuItem});
            this.dofusToolStripMenuItem.Name = "dofusToolStripMenuItem";
            this.dofusToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dofusToolStripMenuItem.Text = "Dofus";
            // 
            // fermerTousToolStripMenuItem
            // 
            this.fermerTousToolStripMenuItem.Name = "fermerTousToolStripMenuItem";
            this.fermerTousToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fermerTousToolStripMenuItem.Text = "Fermer tous";
            this.fermerTousToolStripMenuItem.Click += new System.EventHandler(this.CloseAllDofus);
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.childToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.formToolStripMenuItem.Text = "Forms";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nettoyerToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.fermerToolStripMenuItem});
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            // 
            // nettoyerToolStripMenuItem
            // 
            this.nettoyerToolStripMenuItem.Name = "nettoyerToolStripMenuItem";
            this.nettoyerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nettoyerToolStripMenuItem.Text = "Nettoyer";
            this.nettoyerToolStripMenuItem.Click += new System.EventHandler(this.nettoyerToolStripMenuItem_Click);
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fermerToolStripMenuItem.Text = "Cacher";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
            // 
            // childToolStripMenuItem
            // 
            this.childToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.childToolStripMenuItem.Name = "childToolStripMenuItem";
            this.childToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.childToolStripMenuItem.Text = "Bot";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem1.Text = "Ajouter";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.AddNewChild);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.focusToolStripMenuItem,
            this.tousToolStripMenuItem});
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem1.Text = "Supprimer";
            // 
            // focusToolStripMenuItem
            // 
            this.focusToolStripMenuItem.Name = "focusToolStripMenuItem";
            this.focusToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.focusToolStripMenuItem.Text = "Focus";
            this.focusToolStripMenuItem.Click += new System.EventHandler(this.DeleteFocusChild);
            // 
            // tousToolStripMenuItem
            // 
            this.tousToolStripMenuItem.Name = "tousToolStripMenuItem";
            this.tousToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.tousToolStripMenuItem.Text = "Tous";
            this.tousToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllChilds);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AddDofusProcess);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 532);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BioBot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem activerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactiverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dofusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nettoyerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem focusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerTousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
    }
}

