namespace TP_03_02_2020_Pendu
{
    partial class frmJeu
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblProposition = new System.Windows.Forms.Label();
            this.txbProposition = new System.Windows.Forms.TextBox();
            this.pnlMot = new System.Windows.Forms.Panel();
            this.btnRecommencer = new System.Windows.Forms.Button();
            this.lblGagnéPerdu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(22, 35);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(188, 16);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Le mot à trouver :";
            // 
            // lblProposition
            // 
            this.lblProposition.AutoSize = true;
            this.lblProposition.Location = new System.Drawing.Point(520, 35);
            this.lblProposition.Name = "lblProposition";
            this.lblProposition.Size = new System.Drawing.Size(208, 16);
            this.lblProposition.TabIndex = 1;
            this.lblProposition.Text = "Votre proposition : ";
            // 
            // txbProposition
            // 
            this.txbProposition.Location = new System.Drawing.Point(725, 32);
            this.txbProposition.Name = "txbProposition";
            this.txbProposition.Size = new System.Drawing.Size(54, 23);
            this.txbProposition.TabIndex = 2;
            this.txbProposition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProposition_KeyPress);
            // 
            // pnlMot
            // 
            this.pnlMot.Location = new System.Drawing.Point(12, 92);
            this.pnlMot.Name = "pnlMot";
            this.pnlMot.Size = new System.Drawing.Size(863, 166);
            this.pnlMot.TabIndex = 3;
            // 
            // btnRecommencer
            // 
            this.btnRecommencer.Location = new System.Drawing.Point(739, 462);
            this.btnRecommencer.Name = "btnRecommencer";
            this.btnRecommencer.Size = new System.Drawing.Size(136, 33);
            this.btnRecommencer.TabIndex = 4;
            this.btnRecommencer.Text = "Recommencer";
            this.btnRecommencer.UseVisualStyleBackColor = true;
            // 
            // lblGagnéPerdu
            // 
            this.lblGagnéPerdu.AutoSize = true;
            this.lblGagnéPerdu.BackColor = System.Drawing.SystemColors.Control;
            this.lblGagnéPerdu.Location = new System.Drawing.Point(350, 287);
            this.lblGagnéPerdu.Name = "lblGagnéPerdu";
            this.lblGagnéPerdu.Size = new System.Drawing.Size(18, 16);
            this.lblGagnéPerdu.TabIndex = 0;
            this.lblGagnéPerdu.Text = " ";
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 507);
            this.Controls.Add(this.lblGagnéPerdu);
            this.Controls.Add(this.btnRecommencer);
            this.Controls.Add(this.pnlMot);
            this.Controls.Add(this.txbProposition);
            this.Controls.Add(this.lblProposition);
            this.Controls.Add(this.lblTitre);
            this.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmJeu";
            this.Text = "Jeu du pendu";
            this.Load += new System.EventHandler(this.frmJeu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblProposition;
        private System.Windows.Forms.TextBox txbProposition;
        private System.Windows.Forms.Panel pnlMot;
        private System.Windows.Forms.Button btnRecommencer;
        private System.Windows.Forms.Label lblGagnéPerdu;
    }
}

