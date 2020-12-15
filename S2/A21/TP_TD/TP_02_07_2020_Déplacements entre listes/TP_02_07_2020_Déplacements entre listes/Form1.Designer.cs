namespace TP_02_07_2020_Déplacements_entre_listes
{
    partial class frmDepart
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
            this.components = new System.ComponentModel.Container();
            this.lsbListeG = new System.Windows.Forms.ListBox();
            this.lsbListeD = new System.Windows.Forms.ListBox();
            this.btnGversD = new System.Windows.Forms.Button();
            this.btnDversG = new System.Windows.Forms.Button();
            this.btnAllDversG = new System.Windows.Forms.Button();
            this.btnAllGversD = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnAjouterElem = new System.Windows.Forms.Button();
            this.lblNouvelleElem = new System.Windows.Forms.Label();
            this.txbAjouterElem = new System.Windows.Forms.TextBox();
            this.pnlAfficherAjouterElem = new System.Windows.Forms.Panel();
            this.erpElemExiste = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpElemExiste)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbListeG
            // 
            this.lsbListeG.BackColor = System.Drawing.Color.OldLace;
            this.lsbListeG.FormattingEnabled = true;
            this.lsbListeG.ItemHeight = 15;
            this.lsbListeG.Items.AddRange(new object[] {
            "Nom",
            "Prenom",
            "Date",
            "Heure"});
            this.lsbListeG.Location = new System.Drawing.Point(108, 47);
            this.lsbListeG.Name = "lsbListeG";
            this.lsbListeG.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbListeG.Size = new System.Drawing.Size(268, 469);
            this.lsbListeG.TabIndex = 0;
            // 
            // lsbListeD
            // 
            this.lsbListeD.BackColor = System.Drawing.Color.OldLace;
            this.lsbListeD.FormattingEnabled = true;
            this.lsbListeD.ItemHeight = 15;
            this.lsbListeD.Location = new System.Drawing.Point(463, 47);
            this.lsbListeD.Name = "lsbListeD";
            this.lsbListeD.Size = new System.Drawing.Size(268, 469);
            this.lsbListeD.TabIndex = 4;
            // 
            // btnGversD
            // 
            this.btnGversD.Location = new System.Drawing.Point(397, 158);
            this.btnGversD.Name = "btnGversD";
            this.btnGversD.Size = new System.Drawing.Size(44, 39);
            this.btnGversD.TabIndex = 5;
            this.btnGversD.Text = ">";
            this.btnGversD.UseVisualStyleBackColor = true;
            this.btnGversD.Click += new System.EventHandler(this.btnGversD_Click);
            // 
            // btnDversG
            // 
            this.btnDversG.Location = new System.Drawing.Point(397, 350);
            this.btnDversG.Name = "btnDversG";
            this.btnDversG.Size = new System.Drawing.Size(44, 39);
            this.btnDversG.TabIndex = 6;
            this.btnDversG.Text = "<";
            this.btnDversG.UseVisualStyleBackColor = true;
            this.btnDversG.Click += new System.EventHandler(this.btnDversG_Click);
            // 
            // btnAllDversG
            // 
            this.btnAllDversG.Location = new System.Drawing.Point(397, 305);
            this.btnAllDversG.Name = "btnAllDversG";
            this.btnAllDversG.Size = new System.Drawing.Size(44, 39);
            this.btnAllDversG.TabIndex = 7;
            this.btnAllDversG.Text = "<<<";
            this.btnAllDversG.UseVisualStyleBackColor = true;
            this.btnAllDversG.Click += new System.EventHandler(this.btnAllDversG_Click_1);
            // 
            // btnAllGversD
            // 
            this.btnAllGversD.Location = new System.Drawing.Point(397, 203);
            this.btnAllGversD.Name = "btnAllGversD";
            this.btnAllGversD.Size = new System.Drawing.Size(44, 39);
            this.btnAllGversD.TabIndex = 8;
            this.btnAllGversD.Text = ">>>";
            this.btnAllGversD.UseVisualStyleBackColor = true;
            this.btnAllGversD.Click += new System.EventHandler(this.btnAllGversD_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(638, 548);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(75, 23);
            this.btnQuitter.TabIndex = 9;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnAjouterElem
            // 
            this.btnAjouterElem.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterElem.Location = new System.Drawing.Point(397, 71);
            this.btnAjouterElem.Name = "btnAjouterElem";
            this.btnAjouterElem.Size = new System.Drawing.Size(44, 39);
            this.btnAjouterElem.TabIndex = 10;
            this.btnAjouterElem.Text = "😱";
            this.btnAjouterElem.UseVisualStyleBackColor = true;
            this.btnAjouterElem.Click += new System.EventHandler(this.btnAjouterElem_Click);
            // 
            // lblNouvelleElem
            // 
            this.lblNouvelleElem.AutoSize = true;
            this.lblNouvelleElem.Location = new System.Drawing.Point(122, 552);
            this.lblNouvelleElem.Name = "lblNouvelleElem";
            this.lblNouvelleElem.Size = new System.Drawing.Size(175, 15);
            this.lblNouvelleElem.TabIndex = 11;
            this.lblNouvelleElem.Text = "Ajouter un nouvel élément : ";
            // 
            // txbAjouterElem
            // 
            this.txbAjouterElem.Location = new System.Drawing.Point(303, 549);
            this.txbAjouterElem.Name = "txbAjouterElem";
            this.txbAjouterElem.Size = new System.Drawing.Size(301, 22);
            this.txbAjouterElem.TabIndex = 12;
            this.txbAjouterElem.TextChanged += new System.EventHandler(this.txbAjouterElem_TextChanged);
            this.txbAjouterElem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbAjouterElem_KeyPress);
            // 
            // pnlAfficherAjouterElem
            // 
            this.pnlAfficherAjouterElem.Location = new System.Drawing.Point(108, 522);
            this.pnlAfficherAjouterElem.Name = "pnlAfficherAjouterElem";
            this.pnlAfficherAjouterElem.Size = new System.Drawing.Size(496, 63);
            this.pnlAfficherAjouterElem.TabIndex = 13;
            // 
            // erpElemExiste
            // 
            this.erpElemExiste.ContainerControl = this;
            // 
            // frmDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(839, 597);
            this.Controls.Add(this.pnlAfficherAjouterElem);
            this.Controls.Add(this.txbAjouterElem);
            this.Controls.Add(this.lblNouvelleElem);
            this.Controls.Add(this.btnAjouterElem);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnAllGversD);
            this.Controls.Add(this.btnAllDversG);
            this.Controls.Add(this.btnDversG);
            this.Controls.Add(this.btnGversD);
            this.Controls.Add(this.lsbListeD);
            this.Controls.Add(this.lsbListeG);
            this.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDepart";
            this.Text = "Déplacements entre listes";
            ((System.ComponentModel.ISupportInitialize)(this.erpElemExiste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbListeG;
        private System.Windows.Forms.ListBox lsbListeD;
        private System.Windows.Forms.Button btnGversD;
        private System.Windows.Forms.Button btnDversG;
        private System.Windows.Forms.Button btnAllDversG;
        private System.Windows.Forms.Button btnAllGversD;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnAjouterElem;
        private System.Windows.Forms.Label lblNouvelleElem;
        private System.Windows.Forms.TextBox txbAjouterElem;
        private System.Windows.Forms.Panel pnlAfficherAjouterElem;
        private System.Windows.Forms.ErrorProvider erpElemExiste;
    }
}

