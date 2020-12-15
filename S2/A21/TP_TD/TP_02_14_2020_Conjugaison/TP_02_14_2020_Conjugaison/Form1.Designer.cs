namespace TP_02_14_2020_Conjugaison
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.cboVerbes = new System.Windows.Forms.ComboBox();
            this.grbChoixTemps = new System.Windows.Forms.GroupBox();
            this.rdbPasseSimple = new System.Windows.Forms.RadioButton();
            this.rdbImparfait = new System.Windows.Forms.RadioButton();
            this.rdbFutur = new System.Windows.Forms.RadioButton();
            this.rdbPresent = new System.Windows.Forms.RadioButton();
            this.grbVerbeConjug = new System.Windows.Forms.GroupBox();
            this.lblNous = new System.Windows.Forms.Label();
            this.lblVous = new System.Windows.Forms.Label();
            this.lblElles = new System.Windows.Forms.Label();
            this.lblJe = new System.Windows.Forms.Label();
            this.lblTu = new System.Windows.Forms.Label();
            this.lblElle = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnNouvVerbe = new System.Windows.Forms.Button();
            this.grbChoixTemps.SuspendLayout();
            this.grbVerbeConjug.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(158, 47);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(308, 18);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Conjugaison des verbes du premier groupe";
            // 
            // lblComboBox
            // 
            this.lblComboBox.AutoSize = true;
            this.lblComboBox.Location = new System.Drawing.Point(32, 138);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Size = new System.Drawing.Size(238, 18);
            this.lblComboBox.TabIndex = 1;
            this.lblComboBox.Text = "Veuillez sélectionner un verbe  : ";
            // 
            // cboVerbes
            // 
            this.cboVerbes.FormattingEnabled = true;
            this.cboVerbes.Location = new System.Drawing.Point(300, 135);
            this.cboVerbes.Name = "cboVerbes";
            this.cboVerbes.Size = new System.Drawing.Size(274, 26);
            this.cboVerbes.TabIndex = 2;
            this.cboVerbes.SelectedIndexChanged += new System.EventHandler(this.cboVerbes_SelectedIndexChanged);
            // 
            // grbChoixTemps
            // 
            this.grbChoixTemps.Controls.Add(this.rdbPasseSimple);
            this.grbChoixTemps.Controls.Add(this.rdbImparfait);
            this.grbChoixTemps.Controls.Add(this.rdbFutur);
            this.grbChoixTemps.Controls.Add(this.rdbPresent);
            this.grbChoixTemps.Location = new System.Drawing.Point(12, 221);
            this.grbChoixTemps.Name = "grbChoixTemps";
            this.grbChoixTemps.Size = new System.Drawing.Size(622, 230);
            this.grbChoixTemps.TabIndex = 3;
            this.grbChoixTemps.TabStop = false;
            this.grbChoixTemps.Text = "Choix du temps";
            // 
            // rdbPasseSimple
            // 
            this.rdbPasseSimple.AutoSize = true;
            this.rdbPasseSimple.Location = new System.Drawing.Point(334, 148);
            this.rdbPasseSimple.Name = "rdbPasseSimple";
            this.rdbPasseSimple.Size = new System.Drawing.Size(209, 22);
            this.rdbPasseSimple.TabIndex = 3;
            this.rdbPasseSimple.TabStop = true;
            this.rdbPasseSimple.Tag = "3";
            this.rdbPasseSimple.Text = "Passé simple de l\'indicatif";
            this.rdbPasseSimple.UseVisualStyleBackColor = true;
            this.rdbPasseSimple.Click += new System.EventHandler(this.rdbPresent_Click);
            // 
            // rdbImparfait
            // 
            this.rdbImparfait.AutoSize = true;
            this.rdbImparfait.Location = new System.Drawing.Point(334, 65);
            this.rdbImparfait.Name = "rdbImparfait";
            this.rdbImparfait.Size = new System.Drawing.Size(185, 22);
            this.rdbImparfait.TabIndex = 2;
            this.rdbImparfait.TabStop = true;
            this.rdbImparfait.Tag = "2";
            this.rdbImparfait.Text = "Imparfait de l\'indicatif";
            this.rdbImparfait.UseVisualStyleBackColor = true;
            this.rdbImparfait.Click += new System.EventHandler(this.rdbPresent_Click);
            // 
            // rdbFutur
            // 
            this.rdbFutur.AutoSize = true;
            this.rdbFutur.Location = new System.Drawing.Point(23, 148);
            this.rdbFutur.Name = "rdbFutur";
            this.rdbFutur.Size = new System.Drawing.Size(159, 22);
            this.rdbFutur.TabIndex = 1;
            this.rdbFutur.TabStop = true;
            this.rdbFutur.Tag = "1";
            this.rdbFutur.Text = "Futur de l\'indicatif";
            this.rdbFutur.UseVisualStyleBackColor = true;
            this.rdbFutur.Click += new System.EventHandler(this.rdbPresent_Click);
            // 
            // rdbPresent
            // 
            this.rdbPresent.AutoSize = true;
            this.rdbPresent.Location = new System.Drawing.Point(23, 65);
            this.rdbPresent.Name = "rdbPresent";
            this.rdbPresent.Size = new System.Drawing.Size(173, 22);
            this.rdbPresent.TabIndex = 0;
            this.rdbPresent.TabStop = true;
            this.rdbPresent.Tag = "0";
            this.rdbPresent.Text = "Présent de l\'indicatif";
            this.rdbPresent.UseVisualStyleBackColor = true;
            this.rdbPresent.Click += new System.EventHandler(this.rdbPresent_Click);
            // 
            // grbVerbeConjug
            // 
            this.grbVerbeConjug.Controls.Add(this.lblNous);
            this.grbVerbeConjug.Controls.Add(this.lblVous);
            this.grbVerbeConjug.Controls.Add(this.lblElles);
            this.grbVerbeConjug.Controls.Add(this.lblJe);
            this.grbVerbeConjug.Controls.Add(this.lblTu);
            this.grbVerbeConjug.Controls.Add(this.lblElle);
            this.grbVerbeConjug.Location = new System.Drawing.Point(12, 475);
            this.grbVerbeConjug.Name = "grbVerbeConjug";
            this.grbVerbeConjug.Size = new System.Drawing.Size(622, 196);
            this.grbVerbeConjug.TabIndex = 4;
            this.grbVerbeConjug.TabStop = false;
            this.grbVerbeConjug.Text = "Verbe conjugué";
            // 
            // lblNous
            // 
            this.lblNous.AutoSize = true;
            this.lblNous.Location = new System.Drawing.Point(331, 50);
            this.lblNous.Name = "lblNous";
            this.lblNous.Size = new System.Drawing.Size(50, 18);
            this.lblNous.TabIndex = 10;
            this.lblNous.Text = "label6";
            // 
            // lblVous
            // 
            this.lblVous.AutoSize = true;
            this.lblVous.Location = new System.Drawing.Point(331, 108);
            this.lblVous.Name = "lblVous";
            this.lblVous.Size = new System.Drawing.Size(50, 18);
            this.lblVous.TabIndex = 9;
            this.lblVous.Text = "label5";
            // 
            // lblElles
            // 
            this.lblElles.AutoSize = true;
            this.lblElles.Location = new System.Drawing.Point(331, 166);
            this.lblElles.Name = "lblElles";
            this.lblElles.Size = new System.Drawing.Size(50, 18);
            this.lblElles.TabIndex = 8;
            this.lblElles.Text = "label4";
            // 
            // lblJe
            // 
            this.lblJe.AutoSize = true;
            this.lblJe.Location = new System.Drawing.Point(20, 50);
            this.lblJe.Name = "lblJe";
            this.lblJe.Size = new System.Drawing.Size(50, 18);
            this.lblJe.TabIndex = 7;
            this.lblJe.Text = "label3";
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(20, 108);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(50, 18);
            this.lblTu.TabIndex = 6;
            this.lblTu.Text = "label2";
            // 
            // lblElle
            // 
            this.lblElle.AutoSize = true;
            this.lblElle.Location = new System.Drawing.Point(20, 166);
            this.lblElle.Name = "lblElle";
            this.lblElle.Size = new System.Drawing.Size(50, 18);
            this.lblElle.TabIndex = 0;
            this.lblElle.Text = "label1";
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(559, 677);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(75, 34);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnNouvVerbe
            // 
            this.btnNouvVerbe.Location = new System.Drawing.Point(580, 135);
            this.btnNouvVerbe.Name = "btnNouvVerbe";
            this.btnNouvVerbe.Size = new System.Drawing.Size(56, 26);
            this.btnNouvVerbe.TabIndex = 6;
            this.btnNouvVerbe.Text = "New";
            this.btnNouvVerbe.UseVisualStyleBackColor = true;
            this.btnNouvVerbe.Click += new System.EventHandler(this.btnNouvVerbe_Click);
            // 
            // frmDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 723);
            this.Controls.Add(this.btnNouvVerbe);
            this.Controls.Add(this.grbVerbeConjug);
            this.Controls.Add(this.grbChoixTemps);
            this.Controls.Add(this.cboVerbes);
            this.Controls.Add(this.lblComboBox);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnQuitter);
            this.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDepart";
            this.Text = "Aide à la conjugaison";
            this.Load += new System.EventHandler(this.frmDepart_Load);
            this.grbChoixTemps.ResumeLayout(false);
            this.grbChoixTemps.PerformLayout();
            this.grbVerbeConjug.ResumeLayout(false);
            this.grbVerbeConjug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.ComboBox cboVerbes;
        private System.Windows.Forms.GroupBox grbChoixTemps;
        private System.Windows.Forms.RadioButton rdbPasseSimple;
        private System.Windows.Forms.RadioButton rdbImparfait;
        private System.Windows.Forms.RadioButton rdbFutur;
        private System.Windows.Forms.RadioButton rdbPresent;
        private System.Windows.Forms.GroupBox grbVerbeConjug;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label lblNous;
        private System.Windows.Forms.Label lblVous;
        private System.Windows.Forms.Label lblElles;
        private System.Windows.Forms.Label lblJe;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.Label lblElle;
        private System.Windows.Forms.Button btnNouvVerbe;
    }
}

