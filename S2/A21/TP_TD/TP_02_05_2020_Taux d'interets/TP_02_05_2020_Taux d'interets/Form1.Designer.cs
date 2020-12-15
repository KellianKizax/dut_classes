namespace TP_02_05_2020_Taux_d_interets
{
    partial class frmInterets
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
            this.lblCapitalDepart = new System.Windows.Forms.Label();
            this.lblNbrAnnees = new System.Windows.Forms.Label();
            this.lblTauxInteret = new System.Windows.Forms.Label();
            this.txbCapitalDepart = new System.Windows.Forms.TextBox();
            this.txbTauxInterets = new System.Windows.Forms.TextBox();
            this.txbNbrAnnees = new System.Windows.Forms.TextBox();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRaz = new System.Windows.Forms.Button();
            this.btnCalculer = new System.Windows.Forms.Button();
            this.lblCapitalFin = new System.Windows.Forms.Label();
            this.lblAffichCapitalFin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCapitalDepart
            // 
            this.lblCapitalDepart.AutoSize = true;
            this.lblCapitalDepart.Location = new System.Drawing.Point(47, 67);
            this.lblCapitalDepart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCapitalDepart.Name = "lblCapitalDepart";
            this.lblCapitalDepart.Size = new System.Drawing.Size(201, 19);
            this.lblCapitalDepart.TabIndex = 0;
            this.lblCapitalDepart.Text = "Entrez le capital de départ : ";
            // 
            // lblNbrAnnees
            // 
            this.lblNbrAnnees.AutoSize = true;
            this.lblNbrAnnees.Location = new System.Drawing.Point(46, 267);
            this.lblNbrAnnees.Name = "lblNbrAnnees";
            this.lblNbrAnnees.Size = new System.Drawing.Size(202, 19);
            this.lblNbrAnnees.TabIndex = 1;
            this.lblNbrAnnees.Text = "Entrez le nombre d\'années : ";
            // 
            // lblTauxInteret
            // 
            this.lblTauxInteret.AutoSize = true;
            this.lblTauxInteret.Location = new System.Drawing.Point(65, 168);
            this.lblTauxInteret.Name = "lblTauxInteret";
            this.lblTauxInteret.Size = new System.Drawing.Size(183, 19);
            this.lblTauxInteret.TabIndex = 2;
            this.lblTauxInteret.Text = "Entrez le taux d\'intérêts : ";
            // 
            // txbCapitalDepart
            // 
            this.txbCapitalDepart.Location = new System.Drawing.Point(305, 64);
            this.txbCapitalDepart.Name = "txbCapitalDepart";
            this.txbCapitalDepart.Size = new System.Drawing.Size(221, 26);
            this.txbCapitalDepart.TabIndex = 3;
            this.txbCapitalDepart.Enter += new System.EventHandler(this.txbCapitalDepart_Enter);
            this.txbCapitalDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCapitalDepart_KeyPress);
            this.txbCapitalDepart.Leave += new System.EventHandler(this.txbCapitalDepart_Leave);
            // 
            // txbTauxInterets
            // 
            this.txbTauxInterets.Location = new System.Drawing.Point(305, 165);
            this.txbTauxInterets.Name = "txbTauxInterets";
            this.txbTauxInterets.Size = new System.Drawing.Size(221, 26);
            this.txbTauxInterets.TabIndex = 4;
            this.txbTauxInterets.Enter += new System.EventHandler(this.txbTauxInterets_Enter);
            this.txbTauxInterets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTauxInterets_KeyPress);
            this.txbTauxInterets.Leave += new System.EventHandler(this.txbTauxInterets_Leave);
            // 
            // txbNbrAnnees
            // 
            this.txbNbrAnnees.Location = new System.Drawing.Point(305, 264);
            this.txbNbrAnnees.Name = "txbNbrAnnees";
            this.txbNbrAnnees.Size = new System.Drawing.Size(221, 26);
            this.txbNbrAnnees.TabIndex = 5;
            this.txbNbrAnnees.Enter += new System.EventHandler(this.txbNbrAnnees_Enter);
            this.txbNbrAnnees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNbrAnnees_KeyPress);
            this.txbNbrAnnees.Leave += new System.EventHandler(this.txbNbrAnnees_Leave);
            // 
            // btnQuitter
            // 
            this.btnQuitter.ForeColor = System.Drawing.Color.DarkRed;
            this.btnQuitter.Location = new System.Drawing.Point(648, 356);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(121, 23);
            this.btnQuitter.TabIndex = 6;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnRaz
            // 
            this.btnRaz.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnRaz.Location = new System.Drawing.Point(648, 308);
            this.btnRaz.Name = "btnRaz";
            this.btnRaz.Size = new System.Drawing.Size(121, 23);
            this.btnRaz.TabIndex = 8;
            this.btnRaz.Text = "Remise à zero";
            this.btnRaz.UseVisualStyleBackColor = true;
            this.btnRaz.Click += new System.EventHandler(this.btnRaz_Click);
            // 
            // btnCalculer
            // 
            this.btnCalculer.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCalculer.Location = new System.Drawing.Point(648, 260);
            this.btnCalculer.Name = "btnCalculer";
            this.btnCalculer.Size = new System.Drawing.Size(121, 23);
            this.btnCalculer.TabIndex = 9;
            this.btnCalculer.Text = "Calculer";
            this.btnCalculer.UseVisualStyleBackColor = true;
            this.btnCalculer.Click += new System.EventHandler(this.btnCalculer_Click);
            // 
            // lblCapitalFin
            // 
            this.lblCapitalFin.AutoSize = true;
            this.lblCapitalFin.Location = new System.Drawing.Point(132, 356);
            this.lblCapitalFin.Name = "lblCapitalFin";
            this.lblCapitalFin.Size = new System.Drawing.Size(116, 19);
            this.lblCapitalFin.TabIndex = 10;
            this.lblCapitalFin.Text = "Capital de fin : ";
            // 
            // lblAffichCapitalFin
            // 
            this.lblAffichCapitalFin.AutoSize = true;
            this.lblAffichCapitalFin.Location = new System.Drawing.Point(301, 356);
            this.lblAffichCapitalFin.Name = "lblAffichCapitalFin";
            this.lblAffichCapitalFin.Size = new System.Drawing.Size(50, 19);
            this.lblAffichCapitalFin.TabIndex = 11;
            this.lblAffichCapitalFin.Text = "0,00 €";
            // 
            // frmInterets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(861, 413);
            this.Controls.Add(this.lblAffichCapitalFin);
            this.Controls.Add(this.lblCapitalFin);
            this.Controls.Add(this.btnCalculer);
            this.Controls.Add(this.btnRaz);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.txbNbrAnnees);
            this.Controls.Add(this.txbTauxInterets);
            this.Controls.Add(this.txbCapitalDepart);
            this.Controls.Add(this.lblTauxInteret);
            this.Controls.Add(this.lblNbrAnnees);
            this.Controls.Add(this.lblCapitalDepart);
            this.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmInterets";
            this.Text = "Intérêts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCapitalDepart;
        private System.Windows.Forms.Label lblNbrAnnees;
        private System.Windows.Forms.Label lblTauxInteret;
        private System.Windows.Forms.TextBox txbCapitalDepart;
        private System.Windows.Forms.TextBox txbTauxInterets;
        private System.Windows.Forms.TextBox txbNbrAnnees;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnRaz;
        private System.Windows.Forms.Button btnCalculer;
        private System.Windows.Forms.Label lblCapitalFin;
        private System.Windows.Forms.Label lblAffichCapitalFin;
    }
}

