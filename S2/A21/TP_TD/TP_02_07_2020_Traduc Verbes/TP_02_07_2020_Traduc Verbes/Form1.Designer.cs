namespace TP_02_07_2020_Traduc_Verbes
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
            this.lblChoixduverbe = new System.Windows.Forms.Label();
            this.cboChoixverbe = new System.Windows.Forms.ComboBox();
            this.grbChoixlangue = new System.Windows.Forms.GroupBox();
            this.rdbItalien = new System.Windows.Forms.RadioButton();
            this.rdbEspagnol = new System.Windows.Forms.RadioButton();
            this.rdbAllemand = new System.Windows.Forms.RadioButton();
            this.rdbAnglais = new System.Windows.Forms.RadioButton();
            this.grbResultats = new System.Windows.Forms.GroupBox();
            this.lblResultats = new System.Windows.Forms.Label();
            this.grbChoixlangue.SuspendLayout();
            this.grbResultats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChoixduverbe
            // 
            this.lblChoixduverbe.AutoSize = true;
            this.lblChoixduverbe.Location = new System.Drawing.Point(39, 43);
            this.lblChoixduverbe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixduverbe.Name = "lblChoixduverbe";
            this.lblChoixduverbe.Size = new System.Drawing.Size(109, 18);
            this.lblChoixduverbe.TabIndex = 0;
            this.lblChoixduverbe.Text = "Choix du verbe : ";
            // 
            // cboChoixverbe
            // 
            this.cboChoixverbe.FormattingEnabled = true;
            this.cboChoixverbe.Location = new System.Drawing.Point(202, 40);
            this.cboChoixverbe.Name = "cboChoixverbe";
            this.cboChoixverbe.Size = new System.Drawing.Size(272, 26);
            this.cboChoixverbe.TabIndex = 1;
            this.cboChoixverbe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboChoixverbe_KeyPress);
            // 
            // grbChoixlangue
            // 
            this.grbChoixlangue.Controls.Add(this.rdbItalien);
            this.grbChoixlangue.Controls.Add(this.rdbEspagnol);
            this.grbChoixlangue.Controls.Add(this.rdbAllemand);
            this.grbChoixlangue.Controls.Add(this.rdbAnglais);
            this.grbChoixlangue.Location = new System.Drawing.Point(12, 88);
            this.grbChoixlangue.Name = "grbChoixlangue";
            this.grbChoixlangue.Size = new System.Drawing.Size(573, 213);
            this.grbChoixlangue.TabIndex = 2;
            this.grbChoixlangue.TabStop = false;
            this.grbChoixlangue.Text = "Choix de la langue";
            // 
            // rdbItalien
            // 
            this.rdbItalien.AutoSize = true;
            this.rdbItalien.Location = new System.Drawing.Point(6, 161);
            this.rdbItalien.Name = "rdbItalien";
            this.rdbItalien.Size = new System.Drawing.Size(63, 22);
            this.rdbItalien.TabIndex = 3;
            this.rdbItalien.TabStop = true;
            this.rdbItalien.Text = "Italien";
            this.rdbItalien.UseVisualStyleBackColor = true;
            this.rdbItalien.CheckedChanged += new System.EventHandler(this.rdbAnglais_CheckedChanged);
            // 
            // rdbEspagnol
            // 
            this.rdbEspagnol.AutoSize = true;
            this.rdbEspagnol.Location = new System.Drawing.Point(7, 119);
            this.rdbEspagnol.Name = "rdbEspagnol";
            this.rdbEspagnol.Size = new System.Drawing.Size(82, 22);
            this.rdbEspagnol.TabIndex = 2;
            this.rdbEspagnol.TabStop = true;
            this.rdbEspagnol.Text = "Espagnol";
            this.rdbEspagnol.UseVisualStyleBackColor = true;
            this.rdbEspagnol.CheckedChanged += new System.EventHandler(this.rdbAnglais_CheckedChanged);
            // 
            // rdbAllemand
            // 
            this.rdbAllemand.AutoSize = true;
            this.rdbAllemand.Location = new System.Drawing.Point(7, 77);
            this.rdbAllemand.Name = "rdbAllemand";
            this.rdbAllemand.Size = new System.Drawing.Size(84, 22);
            this.rdbAllemand.TabIndex = 1;
            this.rdbAllemand.TabStop = true;
            this.rdbAllemand.Text = "Allemand";
            this.rdbAllemand.UseVisualStyleBackColor = true;
            this.rdbAllemand.CheckedChanged += new System.EventHandler(this.rdbAnglais_CheckedChanged);
            // 
            // rdbAnglais
            // 
            this.rdbAnglais.AutoSize = true;
            this.rdbAnglais.Location = new System.Drawing.Point(7, 37);
            this.rdbAnglais.Name = "rdbAnglais";
            this.rdbAnglais.Size = new System.Drawing.Size(71, 22);
            this.rdbAnglais.TabIndex = 0;
            this.rdbAnglais.TabStop = true;
            this.rdbAnglais.Text = "Anglais";
            this.rdbAnglais.UseVisualStyleBackColor = true;
            this.rdbAnglais.CheckedChanged += new System.EventHandler(this.rdbAnglais_CheckedChanged);
            // 
            // grbResultats
            // 
            this.grbResultats.Controls.Add(this.lblResultats);
            this.grbResultats.Location = new System.Drawing.Point(12, 307);
            this.grbResultats.Name = "grbResultats";
            this.grbResultats.Size = new System.Drawing.Size(573, 100);
            this.grbResultats.TabIndex = 3;
            this.grbResultats.TabStop = false;
            this.grbResultats.Text = "Résultats";
            // 
            // lblResultats
            // 
            this.lblResultats.AutoSize = true;
            this.lblResultats.Location = new System.Drawing.Point(30, 45);
            this.lblResultats.Name = "lblResultats";
            this.lblResultats.Size = new System.Drawing.Size(0, 18);
            this.lblResultats.TabIndex = 0;
            // 
            // frmDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 434);
            this.Controls.Add(this.grbResultats);
            this.Controls.Add(this.grbChoixlangue);
            this.Controls.Add(this.cboChoixverbe);
            this.Controls.Add(this.lblChoixduverbe);
            this.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDepart";
            this.Text = "Traduction des verbes usuels";
            this.Load += new System.EventHandler(this.frmDepart_Load);
            this.grbChoixlangue.ResumeLayout(false);
            this.grbChoixlangue.PerformLayout();
            this.grbResultats.ResumeLayout(false);
            this.grbResultats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoixduverbe;
        private System.Windows.Forms.ComboBox cboChoixverbe;
        private System.Windows.Forms.GroupBox grbChoixlangue;
        private System.Windows.Forms.RadioButton rdbItalien;
        private System.Windows.Forms.RadioButton rdbEspagnol;
        private System.Windows.Forms.RadioButton rdbAllemand;
        private System.Windows.Forms.RadioButton rdbAnglais;
        private System.Windows.Forms.GroupBox grbResultats;
        private System.Windows.Forms.Label lblResultats;
    }
}

