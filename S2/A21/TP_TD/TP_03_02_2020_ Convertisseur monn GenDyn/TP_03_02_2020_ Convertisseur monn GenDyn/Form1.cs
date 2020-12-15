using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_03_02_2020__Convertisseur_monn_GenDyn
{
    public partial class frmConvertisseur : Form
    {
        public frmConvertisseur()
        {
            InitializeComponent();
        }

        public static string[] tab_pays = { "Algerie", "Argentine", "Danemark", "Etats - Unis", "Inde", "Japon", "Royaume Uni", "Suisse" };

        private void frmConvertisseur_Load(object sender, EventArgs e)
        {
            int hauteur = 80;
            int largeur = 60;

            for (int i = 0; i < tab_pays.Length; i++)
            {
                RadioButton rdbPays = new System.Windows.Forms.RadioButton();

                rdbPays.AutoSize = true;
                rdbPays.Location = new System.Drawing.Point(largeur, hauteur);
                rdbPays.Name = "rdb" + tab_pays[i].ToString();
                rdbPays.Size = new System.Drawing.Size(84, 21);
                rdbPays.TabStop = true;
                rdbPays.Tag = i.ToString();
                rdbPays.Text = tab_pays[i];
                rdbPays.UseVisualStyleBackColor = true;
                rdbPays.Click += new EventHandler(rdbPays_click);

                grbListePays.Controls.Add(rdbPays);

                hauteur = hauteur + 60;

                if (i == 3)
                {
                    hauteur = 80;
                    largeur = 250;
                }
            }

        } // fin load frm

        private void rdbPays_click(object sender, EventArgs e)
        {

        }
    }
}
