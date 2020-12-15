using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_02_07_2020_Déplacements_entre_listes
{
    public partial class frmDepart : Form
    {
        public frmDepart()
        {
            InitializeComponent();
        }

        private void btnGversD_Click(object sender, EventArgs e)
        {
            // boucle tant qu'il y a des elements selectionnes
            while ( lsbListeG.SelectedItems.Count != 0)
            {
                // on ajoute le premier element selectionne de la liste de gauche vers la liste de droite
                lsbListeD.Items.Add(lsbListeG.SelectedItems[0]);
                // on supprime cet element de la liste de gauche
                lsbListeG.Items.Remove(lsbListeG.SelectedItems[0]);
            }
        }

        private void btnDversG_Click(object sender, EventArgs e)
        {
            // boucle tant qu'il y a des elements selectionnes
            while (lsbListeD.SelectedItems.Count != 0)
            {
                // on ajoute le premier element selectionne de la liste de droite vers la liste de gauche
                lsbListeG.Items.Add(lsbListeD.SelectedItems[0]);
                // on supprime cet element de la liste de droite
                lsbListeD.Items.Remove(lsbListeD.SelectedItems[0]);
            }
        }

        private void btnAllGversD_Click(object sender, EventArgs e)
        {
            // on ajoute tous les items de la liste de gauche a celle de droite
            lsbListeD.Items.AddRange(lsbListeG.Items);
            // on supprime tous les items de la liste de gauche
            lsbListeG.Items.Clear();
        }

        private void btnAllDversG_Click_1(object sender, EventArgs e)
        {
            // On ajoute les items de la liste droite à celle de gauche
            lsbListeG.Items.AddRange(lsbListeD.Items);
            // on supprime tous les items de la liste droite
            lsbListeD.Items.Clear();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAjouterElem_Click(object sender, EventArgs e)
        {
            // On masque le panel devant les controles
            pnlAfficherAjouterElem.Hide();
            // et on donne le focus à la zone de texte
            txbAjouterElem.Focus();
        }

        private void txbAjouterElem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbAjouterElem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                string newElem = txbAjouterElem.Text;
                bool existe = false;

                // boucle pour verifier si l'élément n'est pas déjà présent dans la liste gauche
                foreach ( string item in lsbListeG.Items)
                {
                    if ( newElem.ToLower() == item.ToLower() )
                    {
                        existe = true;
                    }
                }

                // si le nouvel element n'est pas présent dans la liste gauche, on l'ajoute
                if (!existe)
                {
                    lsbListeG.Items.Add(newElem);
                    erpElemExiste.SetError(txbAjouterElem, "");
                    txbAjouterElem.Text = String.Empty;
                    pnlAfficherAjouterElem.Show();
                }
                // sinon il existe déjà => error provider
                else
                {
                    erpElemExiste.SetError(txbAjouterElem, "L'élément existe déjà !");
                    txbAjouterElem.Text = String.Empty;
                }
            }
        }
    }
}
