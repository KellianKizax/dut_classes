namespace TP_01_29_2020
{
    partial class Form1
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
            this.lblCelsius = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFarhenheit = new System.Windows.Forms.TextBox();
            this.txbCelsius = new System.Windows.Forms.TextBox();
            this.grbConversion = new System.Windows.Forms.GroupBox();
            this.rdbFarhenheitCelsius = new System.Windows.Forms.RadioButton();
            this.rdbCelsiusFarhenheit = new System.Windows.Forms.RadioButton();
            this.btnReinit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grbConversion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCelsius
            // 
            this.lblCelsius.AutoSize = true;
            this.lblCelsius.Location = new System.Drawing.Point(35, 58);
            this.lblCelsius.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCelsius.Name = "lblCelsius";
            this.lblCelsius.Size = new System.Drawing.Size(162, 15);
            this.lblCelsius.TabIndex = 0;
            this.lblCelsius.Text = "Température en celsius :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Température en fahrenheit :";
            // 
            // txbFarhenheit
            // 
            this.txbFarhenheit.Location = new System.Drawing.Point(259, 129);
            this.txbFarhenheit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbFarhenheit.Name = "txbFarhenheit";
            this.txbFarhenheit.Size = new System.Drawing.Size(259, 23);
            this.txbFarhenheit.TabIndex = 1;
            this.txbFarhenheit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFarhenheit_KeyPress);
            // 
            // txbCelsius
            // 
            this.txbCelsius.Location = new System.Drawing.Point(259, 55);
            this.txbCelsius.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbCelsius.Name = "txbCelsius";
            this.txbCelsius.Size = new System.Drawing.Size(259, 23);
            this.txbCelsius.TabIndex = 0;
            this.txbCelsius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCelsius_KeyPress);
            // 
            // grbConversion
            // 
            this.grbConversion.Controls.Add(this.rdbFarhenheitCelsius);
            this.grbConversion.Controls.Add(this.rdbCelsiusFarhenheit);
            this.grbConversion.Location = new System.Drawing.Point(16, 198);
            this.grbConversion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbConversion.Name = "grbConversion";
            this.grbConversion.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbConversion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbConversion.Size = new System.Drawing.Size(1035, 237);
            this.grbConversion.TabIndex = 4;
            this.grbConversion.TabStop = false;
            this.grbConversion.Text = "Sens de conversion";
            // 
            // rdbFarhenheitCelsius
            // 
            this.rdbFarhenheitCelsius.AutoSize = true;
            this.rdbFarhenheitCelsius.Location = new System.Drawing.Point(22, 144);
            this.rdbFarhenheitCelsius.Name = "rdbFarhenheitCelsius";
            this.rdbFarhenheitCelsius.Size = new System.Drawing.Size(154, 19);
            this.rdbFarhenheitCelsius.TabIndex = 1;
            this.rdbFarhenheitCelsius.TabStop = true;
            this.rdbFarhenheitCelsius.Text = "Farhenheit > Celsius";
            this.rdbFarhenheitCelsius.UseVisualStyleBackColor = true;
            this.rdbFarhenheitCelsius.CheckedChanged += new System.EventHandler(this.rdbFarhenheitCelsius_CheckedChanged);
            // 
            // rdbCelsiusFarhenheit
            // 
            this.rdbCelsiusFarhenheit.AutoSize = true;
            this.rdbCelsiusFarhenheit.Location = new System.Drawing.Point(22, 72);
            this.rdbCelsiusFarhenheit.Name = "rdbCelsiusFarhenheit";
            this.rdbCelsiusFarhenheit.Size = new System.Drawing.Size(154, 19);
            this.rdbCelsiusFarhenheit.TabIndex = 0;
            this.rdbCelsiusFarhenheit.TabStop = true;
            this.rdbCelsiusFarhenheit.Text = "Celsius > Farhenheit";
            this.rdbCelsiusFarhenheit.UseVisualStyleBackColor = true;
            this.rdbCelsiusFarhenheit.CheckedChanged += new System.EventHandler(this.rdbCelsiusFarhenheit_CheckedChanged);
            // 
            // btnReinit
            // 
            this.btnReinit.Location = new System.Drawing.Point(843, 479);
            this.btnReinit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReinit.Name = "btnReinit";
            this.btnReinit.Size = new System.Drawing.Size(100, 27);
            this.btnReinit.TabIndex = 5;
            this.btnReinit.Text = "Reinitialiser";
            this.btnReinit.UseVisualStyleBackColor = true;
            this.btnReinit.Click += new System.EventHandler(this.btnReinit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(951, 479);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 27);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(1067, 519);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReinit);
            this.Controls.Add(this.grbConversion);
            this.Controls.Add(this.txbCelsius);
            this.Controls.Add(this.txbFarhenheit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCelsius);
            this.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversion Celisus - Farhenheit";
            this.grbConversion.ResumeLayout(false);
            this.grbConversion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCelsius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFarhenheit;
        private System.Windows.Forms.TextBox txbCelsius;
        private System.Windows.Forms.GroupBox grbConversion;
        private System.Windows.Forms.Button btnReinit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbFarhenheitCelsius;
        private System.Windows.Forms.RadioButton rdbCelsiusFarhenheit;
    }
}

