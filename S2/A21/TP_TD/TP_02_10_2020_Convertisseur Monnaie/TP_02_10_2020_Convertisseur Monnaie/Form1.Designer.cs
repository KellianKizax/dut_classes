namespace TP_02_10_2020_Convertisseur_Monnaie
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
            this.lbl_somme = new System.Windows.Forms.Label();
            this.txt_somme = new System.Windows.Forms.TextBox();
            this.grb_pays = new System.Windows.Forms.GroupBox();
            this.rdb_suisse = new System.Windows.Forms.RadioButton();
            this.rdb_royaumeuni = new System.Windows.Forms.RadioButton();
            this.rdb_japon = new System.Windows.Forms.RadioButton();
            this.rdb_inde = new System.Windows.Forms.RadioButton();
            this.rdb_etatsunis = new System.Windows.Forms.RadioButton();
            this.rdb_danemark = new System.Windows.Forms.RadioButton();
            this.rdb_argentine = new System.Windows.Forms.RadioButton();
            this.rdb_algerie = new System.Windows.Forms.RadioButton();
            this.grb_conversion = new System.Windows.Forms.GroupBox();
            this.rdb_monnaieeuro = new System.Windows.Forms.RadioButton();
            this.rdb_euromonnaie = new System.Windows.Forms.RadioButton();
            this.grb_informations = new System.Windows.Forms.GroupBox();
            this.lbl_resultat = new System.Windows.Forms.Label();
            this.lbl_textresultat = new System.Windows.Forms.Label();
            this.lbl_valmonnaie = new System.Windows.Forms.Label();
            this.lbl_valeuro = new System.Windows.Forms.Label();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.btn_convertir = new System.Windows.Forms.Button();
            this.btn_raz = new System.Windows.Forms.Button();
            this.lbl_temp0 = new System.Windows.Forms.Label();
            this.lbl_temp1 = new System.Windows.Forms.Label();
            this.grb_pays.SuspendLayout();
            this.grb_conversion.SuspendLayout();
            this.grb_informations.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_somme
            // 
            this.lbl_somme.AutoSize = true;
            this.lbl_somme.Location = new System.Drawing.Point(43, 47);
            this.lbl_somme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_somme.Name = "lbl_somme";
            this.lbl_somme.Size = new System.Drawing.Size(188, 21);
            this.lbl_somme.TabIndex = 0;
            this.lbl_somme.Text = "Entrez la somme à convertir : ";
            // 
            // txt_somme
            // 
            this.txt_somme.Location = new System.Drawing.Point(238, 44);
            this.txt_somme.Name = "txt_somme";
            this.txt_somme.Size = new System.Drawing.Size(223, 27);
            this.txt_somme.TabIndex = 1;
            this.txt_somme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_somme_KeyPress);
            // 
            // grb_pays
            // 
            this.grb_pays.Controls.Add(this.rdb_suisse);
            this.grb_pays.Controls.Add(this.rdb_royaumeuni);
            this.grb_pays.Controls.Add(this.rdb_japon);
            this.grb_pays.Controls.Add(this.rdb_inde);
            this.grb_pays.Controls.Add(this.rdb_etatsunis);
            this.grb_pays.Controls.Add(this.rdb_danemark);
            this.grb_pays.Controls.Add(this.rdb_argentine);
            this.grb_pays.Controls.Add(this.rdb_algerie);
            this.grb_pays.Location = new System.Drawing.Point(12, 106);
            this.grb_pays.Name = "grb_pays";
            this.grb_pays.Size = new System.Drawing.Size(558, 217);
            this.grb_pays.TabIndex = 2;
            this.grb_pays.TabStop = false;
            this.grb_pays.Text = "Selection du pays de votre choix";
            // 
            // rdb_suisse
            // 
            this.rdb_suisse.AutoSize = true;
            this.rdb_suisse.Location = new System.Drawing.Point(412, 103);
            this.rdb_suisse.Name = "rdb_suisse";
            this.rdb_suisse.Size = new System.Drawing.Size(68, 25);
            this.rdb_suisse.TabIndex = 7;
            this.rdb_suisse.TabStop = true;
            this.rdb_suisse.Tag = "7";
            this.rdb_suisse.Text = "Suisse";
            this.rdb_suisse.UseVisualStyleBackColor = true;
            this.rdb_suisse.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_royaumeuni
            // 
            this.rdb_royaumeuni.AutoSize = true;
            this.rdb_royaumeuni.Location = new System.Drawing.Point(412, 38);
            this.rdb_royaumeuni.Name = "rdb_royaumeuni";
            this.rdb_royaumeuni.Size = new System.Drawing.Size(109, 25);
            this.rdb_royaumeuni.TabIndex = 6;
            this.rdb_royaumeuni.TabStop = true;
            this.rdb_royaumeuni.Tag = "6";
            this.rdb_royaumeuni.Text = "Royaume Uni";
            this.rdb_royaumeuni.UseVisualStyleBackColor = true;
            this.rdb_royaumeuni.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_japon
            // 
            this.rdb_japon.AutoSize = true;
            this.rdb_japon.Location = new System.Drawing.Point(226, 168);
            this.rdb_japon.Name = "rdb_japon";
            this.rdb_japon.Size = new System.Drawing.Size(65, 25);
            this.rdb_japon.TabIndex = 5;
            this.rdb_japon.TabStop = true;
            this.rdb_japon.Tag = "5";
            this.rdb_japon.Text = "Japon";
            this.rdb_japon.UseVisualStyleBackColor = true;
            this.rdb_japon.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_inde
            // 
            this.rdb_inde.AutoSize = true;
            this.rdb_inde.Location = new System.Drawing.Point(226, 103);
            this.rdb_inde.Name = "rdb_inde";
            this.rdb_inde.Size = new System.Drawing.Size(54, 25);
            this.rdb_inde.TabIndex = 4;
            this.rdb_inde.TabStop = true;
            this.rdb_inde.Tag = "4";
            this.rdb_inde.Text = "Inde";
            this.rdb_inde.UseVisualStyleBackColor = true;
            this.rdb_inde.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_etatsunis
            // 
            this.rdb_etatsunis.AutoSize = true;
            this.rdb_etatsunis.Location = new System.Drawing.Point(226, 38);
            this.rdb_etatsunis.Name = "rdb_etatsunis";
            this.rdb_etatsunis.Size = new System.Drawing.Size(99, 25);
            this.rdb_etatsunis.TabIndex = 3;
            this.rdb_etatsunis.TabStop = true;
            this.rdb_etatsunis.Tag = "3";
            this.rdb_etatsunis.Text = "Etats - Unis";
            this.rdb_etatsunis.UseVisualStyleBackColor = true;
            this.rdb_etatsunis.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_danemark
            // 
            this.rdb_danemark.AutoSize = true;
            this.rdb_danemark.Location = new System.Drawing.Point(23, 168);
            this.rdb_danemark.Name = "rdb_danemark";
            this.rdb_danemark.Size = new System.Drawing.Size(89, 25);
            this.rdb_danemark.TabIndex = 2;
            this.rdb_danemark.TabStop = true;
            this.rdb_danemark.Tag = "2";
            this.rdb_danemark.Text = "Danemark";
            this.rdb_danemark.UseVisualStyleBackColor = true;
            this.rdb_danemark.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_argentine
            // 
            this.rdb_argentine.AutoSize = true;
            this.rdb_argentine.Location = new System.Drawing.Point(23, 103);
            this.rdb_argentine.Name = "rdb_argentine";
            this.rdb_argentine.Size = new System.Drawing.Size(88, 25);
            this.rdb_argentine.TabIndex = 1;
            this.rdb_argentine.TabStop = true;
            this.rdb_argentine.Tag = "1";
            this.rdb_argentine.Text = "Argentine";
            this.rdb_argentine.UseVisualStyleBackColor = true;
            this.rdb_argentine.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // rdb_algerie
            // 
            this.rdb_algerie.AutoSize = true;
            this.rdb_algerie.Location = new System.Drawing.Point(23, 38);
            this.rdb_algerie.Name = "rdb_algerie";
            this.rdb_algerie.Size = new System.Drawing.Size(70, 25);
            this.rdb_algerie.TabIndex = 0;
            this.rdb_algerie.TabStop = true;
            this.rdb_algerie.Tag = "0";
            this.rdb_algerie.Text = "Algérie";
            this.rdb_algerie.UseVisualStyleBackColor = true;
            this.rdb_algerie.CheckedChanged += new System.EventHandler(this.rdb_algerie_CheckedChanged);
            // 
            // grb_conversion
            // 
            this.grb_conversion.Controls.Add(this.lbl_temp1);
            this.grb_conversion.Controls.Add(this.lbl_temp0);
            this.grb_conversion.Controls.Add(this.rdb_monnaieeuro);
            this.grb_conversion.Controls.Add(this.rdb_euromonnaie);
            this.grb_conversion.Location = new System.Drawing.Point(12, 329);
            this.grb_conversion.Name = "grb_conversion";
            this.grb_conversion.Size = new System.Drawing.Size(558, 134);
            this.grb_conversion.TabIndex = 3;
            this.grb_conversion.TabStop = false;
            this.grb_conversion.Text = "Choix du type de conversion";
            // 
            // rdb_monnaieeuro
            // 
            this.rdb_monnaieeuro.AutoSize = true;
            this.rdb_monnaieeuro.Location = new System.Drawing.Point(23, 86);
            this.rdb_monnaieeuro.Name = "rdb_monnaieeuro";
            this.rdb_monnaieeuro.Size = new System.Drawing.Size(142, 25);
            this.rdb_monnaieeuro.TabIndex = 1;
            this.rdb_monnaieeuro.TabStop = true;
            this.rdb_monnaieeuro.Tag = "1";
            this.rdb_monnaieeuro.Text = "Monnaie vers Euro";
            this.rdb_monnaieeuro.UseVisualStyleBackColor = true;
            // 
            // rdb_euromonnaie
            // 
            this.rdb_euromonnaie.AutoSize = true;
            this.rdb_euromonnaie.Location = new System.Drawing.Point(23, 41);
            this.rdb_euromonnaie.Name = "rdb_euromonnaie";
            this.rdb_euromonnaie.Size = new System.Drawing.Size(142, 25);
            this.rdb_euromonnaie.TabIndex = 0;
            this.rdb_euromonnaie.TabStop = true;
            this.rdb_euromonnaie.Tag = "0";
            this.rdb_euromonnaie.Text = "Euro vers Monnaie";
            this.rdb_euromonnaie.UseVisualStyleBackColor = true;
            this.rdb_euromonnaie.CheckedChanged += new System.EventHandler(this.rdb_euromonnaie_CheckedChanged);
            // 
            // grb_informations
            // 
            this.grb_informations.Controls.Add(this.lbl_resultat);
            this.grb_informations.Controls.Add(this.lbl_textresultat);
            this.grb_informations.Controls.Add(this.lbl_valmonnaie);
            this.grb_informations.Controls.Add(this.lbl_valeuro);
            this.grb_informations.Location = new System.Drawing.Point(12, 469);
            this.grb_informations.Name = "grb_informations";
            this.grb_informations.Size = new System.Drawing.Size(558, 173);
            this.grb_informations.TabIndex = 2;
            this.grb_informations.TabStop = false;
            this.grb_informations.Text = "Informations";
            // 
            // lbl_resultat
            // 
            this.lbl_resultat.AutoSize = true;
            this.lbl_resultat.Location = new System.Drawing.Point(198, 131);
            this.lbl_resultat.Name = "lbl_resultat";
            this.lbl_resultat.Size = new System.Drawing.Size(103, 21);
            this.lbl_resultat.TabIndex = 7;
            this.lbl_resultat.Text = "somme <=> res";
            // 
            // lbl_textresultat
            // 
            this.lbl_textresultat.AutoSize = true;
            this.lbl_textresultat.Location = new System.Drawing.Point(19, 131);
            this.lbl_textresultat.Name = "lbl_textresultat";
            this.lbl_textresultat.Size = new System.Drawing.Size(173, 21);
            this.lbl_textresultat.TabIndex = 6;
            this.lbl_textresultat.Text = "Résultat de la conversion : ";
            // 
            // lbl_valmonnaie
            // 
            this.lbl_valmonnaie.AutoSize = true;
            this.lbl_valmonnaie.Location = new System.Drawing.Point(19, 89);
            this.lbl_valmonnaie.Name = "lbl_valmonnaie";
            this.lbl_valmonnaie.Size = new System.Drawing.Size(84, 21);
            this.lbl_valmonnaie.TabIndex = 5;
            this.lbl_valmonnaie.Text = "1 monnaie =";
            // 
            // lbl_valeuro
            // 
            this.lbl_valeuro.AutoSize = true;
            this.lbl_valeuro.Location = new System.Drawing.Point(19, 43);
            this.lbl_valeuro.Name = "lbl_valeuro";
            this.lbl_valeuro.Size = new System.Drawing.Size(63, 21);
            this.lbl_valeuro.TabIndex = 4;
            this.lbl_valeuro.Text = "1 euro = ";
            // 
            // btn_quitter
            // 
            this.btn_quitter.Location = new System.Drawing.Point(509, 648);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(61, 31);
            this.btn_quitter.TabIndex = 4;
            this.btn_quitter.Text = "Quitter";
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // btn_convertir
            // 
            this.btn_convertir.Location = new System.Drawing.Point(428, 648);
            this.btn_convertir.Name = "btn_convertir";
            this.btn_convertir.Size = new System.Drawing.Size(75, 31);
            this.btn_convertir.TabIndex = 5;
            this.btn_convertir.Text = "Convertir";
            this.btn_convertir.UseVisualStyleBackColor = true;
            this.btn_convertir.Click += new System.EventHandler(this.btn_convertir_Click);
            // 
            // btn_raz
            // 
            this.btn_raz.Location = new System.Drawing.Point(313, 648);
            this.btn_raz.Name = "btn_raz";
            this.btn_raz.Size = new System.Drawing.Size(109, 31);
            this.btn_raz.TabIndex = 6;
            this.btn_raz.Text = "Remise à zero";
            this.btn_raz.UseVisualStyleBackColor = true;
            this.btn_raz.Click += new System.EventHandler(this.btn_raz_Click);
            // 
            // lbl_temp0
            // 
            this.lbl_temp0.AutoSize = true;
            this.lbl_temp0.Location = new System.Drawing.Point(222, 43);
            this.lbl_temp0.Name = "lbl_temp0";
            this.lbl_temp0.Size = new System.Drawing.Size(0, 21);
            this.lbl_temp0.TabIndex = 2;
            // 
            // lbl_temp1
            // 
            this.lbl_temp1.AutoSize = true;
            this.lbl_temp1.Location = new System.Drawing.Point(222, 88);
            this.lbl_temp1.Name = "lbl_temp1";
            this.lbl_temp1.Size = new System.Drawing.Size(0, 21);
            this.lbl_temp1.TabIndex = 3;
            // 
            // frmDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 706);
            this.Controls.Add(this.btn_raz);
            this.Controls.Add(this.btn_convertir);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.grb_informations);
            this.Controls.Add(this.grb_conversion);
            this.Controls.Add(this.grb_pays);
            this.Controls.Add(this.txt_somme);
            this.Controls.Add(this.lbl_somme);
            this.Font = new System.Drawing.Font("HP Simplified", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDepart";
            this.Text = "Convertisseur Monnaie";
            this.Load += new System.EventHandler(this.frmDepart_Load);
            this.grb_pays.ResumeLayout(false);
            this.grb_pays.PerformLayout();
            this.grb_conversion.ResumeLayout(false);
            this.grb_conversion.PerformLayout();
            this.grb_informations.ResumeLayout(false);
            this.grb_informations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_somme;
        private System.Windows.Forms.TextBox txt_somme;
        private System.Windows.Forms.GroupBox grb_pays;
        private System.Windows.Forms.RadioButton rdb_suisse;
        private System.Windows.Forms.RadioButton rdb_royaumeuni;
        private System.Windows.Forms.RadioButton rdb_japon;
        private System.Windows.Forms.RadioButton rdb_inde;
        private System.Windows.Forms.RadioButton rdb_etatsunis;
        private System.Windows.Forms.RadioButton rdb_danemark;
        private System.Windows.Forms.RadioButton rdb_argentine;
        private System.Windows.Forms.RadioButton rdb_algerie;
        private System.Windows.Forms.GroupBox grb_conversion;
        private System.Windows.Forms.RadioButton rdb_monnaieeuro;
        private System.Windows.Forms.RadioButton rdb_euromonnaie;
        private System.Windows.Forms.GroupBox grb_informations;
        private System.Windows.Forms.Label lbl_resultat;
        private System.Windows.Forms.Label lbl_textresultat;
        private System.Windows.Forms.Label lbl_valmonnaie;
        private System.Windows.Forms.Label lbl_valeuro;
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Button btn_convertir;
        private System.Windows.Forms.Button btn_raz;
        private System.Windows.Forms.Label lbl_temp1;
        private System.Windows.Forms.Label lbl_temp0;
    }
}

