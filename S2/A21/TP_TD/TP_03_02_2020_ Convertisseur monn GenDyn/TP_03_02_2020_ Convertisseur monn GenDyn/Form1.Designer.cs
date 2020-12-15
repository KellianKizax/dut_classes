namespace TP_03_02_2020__Convertisseur_monn_GenDyn
{
    partial class frmConvertisseur
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
            this.grbListePays = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grbListePays
            // 
            this.grbListePays.Location = new System.Drawing.Point(13, 13);
            this.grbListePays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbListePays.Name = "grbListePays";
            this.grbListePays.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbListePays.Size = new System.Drawing.Size(483, 419);
            this.grbListePays.TabIndex = 0;
            this.grbListePays.TabStop = false;
            this.grbListePays.Text = "Liste des pays : ";
            // 
            // frmConvertisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 445);
            this.Controls.Add(this.grbListePays);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConvertisseur";
            this.Text = "Convertisseur (génération only)";
            this.Load += new System.EventHandler(this.frmConvertisseur_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbListePays;
    }
}

