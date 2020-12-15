namespace TP_01_29_2020_Cotisation_sportive
{
    partial class frmCotisationSport
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
            this.grbEnf = new System.Windows.Forms.GroupBox();
            this.txbNbrEnfants = new System.Windows.Forms.TextBox();
            this.lblNbrEnfants = new System.Windows.Forms.Label();
            this.grbMembAnim = new System.Windows.Forms.GroupBox();
            this.ckbAnim = new System.Windows.Forms.CheckBox();
            this.ckbMembre = new System.Windows.Forms.CheckBox();
            this.lblAnimMemb = new System.Windows.Forms.Label();
            this.grbResultats = new System.Windows.Forms.GroupBox();
            this.lblAffichPrixReduc = new System.Windows.Forms.Label();
            this.lblAffichPrixBase = new System.Windows.Forms.Label();
            this.lblPrixReduc = new System.Windows.Forms.Label();
            this.lblPrixBase = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grbEnf.SuspendLayout();
            this.grbMembAnim.SuspendLayout();
            this.grbResultats.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEnf
            // 
            this.grbEnf.Controls.Add(this.txbNbrEnfants);
            this.grbEnf.Controls.Add(this.lblNbrEnfants);
            this.grbEnf.Location = new System.Drawing.Point(12, 12);
            this.grbEnf.Name = "grbEnf";
            this.grbEnf.Size = new System.Drawing.Size(617, 103);
            this.grbEnf.TabIndex = 0;
            this.grbEnf.TabStop = false;
            this.grbEnf.Text = "Partie 1";
            // 
            // txbNbrEnfants
            // 
            this.txbNbrEnfants.Location = new System.Drawing.Point(196, 43);
            this.txbNbrEnfants.Name = "txbNbrEnfants";
            this.txbNbrEnfants.Size = new System.Drawing.Size(100, 22);
            this.txbNbrEnfants.TabIndex = 1;
            this.txbNbrEnfants.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblNbrEnfants
            // 
            this.lblNbrEnfants.AutoSize = true;
            this.lblNbrEnfants.Location = new System.Drawing.Point(30, 46);
            this.lblNbrEnfants.Name = "lblNbrEnfants";
            this.lblNbrEnfants.Size = new System.Drawing.Size(160, 16);
            this.lblNbrEnfants.TabIndex = 0;
            this.lblNbrEnfants.Text = "Nombre d\'enfants : ";
            // 
            // grbMembAnim
            // 
            this.grbMembAnim.Controls.Add(this.ckbAnim);
            this.grbMembAnim.Controls.Add(this.ckbMembre);
            this.grbMembAnim.Controls.Add(this.lblAnimMemb);
            this.grbMembAnim.Location = new System.Drawing.Point(12, 139);
            this.grbMembAnim.Name = "grbMembAnim";
            this.grbMembAnim.Size = new System.Drawing.Size(617, 166);
            this.grbMembAnim.TabIndex = 1;
            this.grbMembAnim.TabStop = false;
            this.grbMembAnim.Text = "Partie 2";
            // 
            // ckbAnim
            // 
            this.ckbAnim.AutoSize = true;
            this.ckbAnim.Location = new System.Drawing.Point(55, 111);
            this.ckbAnim.Name = "ckbAnim";
            this.ckbAnim.Size = new System.Drawing.Size(99, 20);
            this.ckbAnim.TabIndex = 2;
            this.ckbAnim.Text = "Animateur";
            this.ckbAnim.UseVisualStyleBackColor = true;
            // 
            // ckbMembre
            // 
            this.ckbMembre.AutoSize = true;
            this.ckbMembre.Location = new System.Drawing.Point(55, 68);
            this.ckbMembre.Name = "ckbMembre";
            this.ckbMembre.Size = new System.Drawing.Size(155, 20);
            this.ckbMembre.TabIndex = 1;
            this.ckbMembre.Text = "Membre du bureau";
            this.ckbMembre.UseVisualStyleBackColor = true;
            // 
            // lblAnimMemb
            // 
            this.lblAnimMemb.AutoSize = true;
            this.lblAnimMemb.Location = new System.Drawing.Point(30, 27);
            this.lblAnimMemb.Name = "lblAnimMemb";
            this.lblAnimMemb.Size = new System.Drawing.Size(104, 16);
            this.lblAnimMemb.TabIndex = 0;
            this.lblAnimMemb.Text = "Êtes-vous : ";
            // 
            // grbResultats
            // 
            this.grbResultats.Controls.Add(this.lblAffichPrixReduc);
            this.grbResultats.Controls.Add(this.lblAffichPrixBase);
            this.grbResultats.Controls.Add(this.lblPrixReduc);
            this.grbResultats.Controls.Add(this.lblPrixBase);
            this.grbResultats.Location = new System.Drawing.Point(12, 311);
            this.grbResultats.Name = "grbResultats";
            this.grbResultats.Size = new System.Drawing.Size(436, 231);
            this.grbResultats.TabIndex = 2;
            this.grbResultats.TabStop = false;
            this.grbResultats.Text = "Résultats";
            // 
            // lblAffichPrixReduc
            // 
            this.lblAffichPrixReduc.AutoSize = true;
            this.lblAffichPrixReduc.Location = new System.Drawing.Point(240, 118);
            this.lblAffichPrixReduc.Name = "lblAffichPrixReduc";
            this.lblAffichPrixReduc.Size = new System.Drawing.Size(48, 16);
            this.lblAffichPrixReduc.TabIndex = 3;
            this.lblAffichPrixReduc.Text = "0,00€";
            // 
            // lblAffichPrixBase
            // 
            this.lblAffichPrixBase.AutoSize = true;
            this.lblAffichPrixBase.Location = new System.Drawing.Point(240, 73);
            this.lblAffichPrixBase.Name = "lblAffichPrixBase";
            this.lblAffichPrixBase.Size = new System.Drawing.Size(48, 16);
            this.lblAffichPrixBase.TabIndex = 2;
            this.lblAffichPrixBase.Text = "0,00€";
            // 
            // lblPrixReduc
            // 
            this.lblPrixReduc.AutoSize = true;
            this.lblPrixReduc.Location = new System.Drawing.Point(30, 118);
            this.lblPrixReduc.Name = "lblPrixReduc";
            this.lblPrixReduc.Size = new System.Drawing.Size(192, 16);
            this.lblPrixReduc.TabIndex = 1;
            this.lblPrixReduc.Text = "Prix avec réductions : ";
            // 
            // lblPrixBase
            // 
            this.lblPrixBase.AutoSize = true;
            this.lblPrixBase.Location = new System.Drawing.Point(33, 73);
            this.lblPrixBase.Name = "lblPrixBase";
            this.lblPrixBase.Size = new System.Drawing.Size(128, 16);
            this.lblPrixBase.TabIndex = 0;
            this.lblPrixBase.Text = "Prix de base : ";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(500, 445);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(86, 23);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "Calculer";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(500, 490);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Quitter";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCotisationSport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(641, 554);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.grbResultats);
            this.Controls.Add(this.grbMembAnim);
            this.Controls.Add(this.grbEnf);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCotisationSport";
            this.Text = "Calcul Cotisation Sportive";
            this.Load += new System.EventHandler(this.frmCotisationSport_Load);
            this.grbEnf.ResumeLayout(false);
            this.grbEnf.PerformLayout();
            this.grbMembAnim.ResumeLayout(false);
            this.grbMembAnim.PerformLayout();
            this.grbResultats.ResumeLayout(false);
            this.grbResultats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEnf;
        private System.Windows.Forms.TextBox txbNbrEnfants;
        private System.Windows.Forms.Label lblNbrEnfants;
        private System.Windows.Forms.GroupBox grbMembAnim;
        private System.Windows.Forms.CheckBox ckbAnim;
        private System.Windows.Forms.CheckBox ckbMembre;
        private System.Windows.Forms.Label lblAnimMemb;
        private System.Windows.Forms.GroupBox grbResultats;
        private System.Windows.Forms.Label lblAffichPrixReduc;
        private System.Windows.Forms.Label lblAffichPrixBase;
        private System.Windows.Forms.Label lblPrixReduc;
        private System.Windows.Forms.Label lblPrixBase;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnExit;
    }
}

