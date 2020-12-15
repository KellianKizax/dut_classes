using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_03_02_2020_Pendu
{
    public partial class frmJeu : Form
    {

        public static string[] tab_mots = new string[10] { "adherente", "coktail", "delation", "dahlia", "nationale",
            "rafteur", "macchabee", "schlitteur","talquer","twister" };

        public static string mot_mystère = String.Empty;

        //-----------------------------------------------------------------------------------------------------------------

        private int generePlace()
        {
            Random rnd = new Random();
            int pos = rnd.Next(0, 7);
            return (pos);
        }

        //-----------------------------------------------------------------------------------------------------------------

        public frmJeu()
        {
            InitializeComponent();
        }



        private void frmJeu_Load(object sender, EventArgs e)
        {
            int place_mot = generePlace();
            mot_mystère = tab_mots[place_mot];
            int longueur_mot = mot_mystère.Length;
            int hauteur = 40;
            int largeur = 40;


            for (int i = 0; i < longueur_mot; i++)
            {
                Label lblLettre = new System.Windows.Forms.Label();

                lblLettre.AutoSize = false;
                lblLettre.Width = 0;
                lblLettre.Location = new System.Drawing.Point(largeur, hauteur);
                lblLettre.Name = "lblLettre" + i.ToString();
                lblLettre.Size = new System.Drawing.Size(84, 21);
                lblLettre.TabStop = true;
                lblLettre.Tag = i.ToString();
                lblLettre.BackColor = System.Drawing.SystemColors.ControlLight;
                lblLettre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                if (i == 0)
                    lblLettre.Text = mot_mystère.Substring(0, 1);
                else if (i == longueur_mot - 1)
                    lblLettre.Text = mot_mystère.Substring(longueur_mot - 1, 1);
                else
                    lblLettre.Text = String.Empty;

                largeur = largeur + 80;

                pnlMot.Controls.Add(lblLettre);
            }

        } // fin load

        private void txbProposition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                string lettre = txbProposition.Text;
            }
            else if ( txbProposition.Text != String.Empty && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }
    }
}
