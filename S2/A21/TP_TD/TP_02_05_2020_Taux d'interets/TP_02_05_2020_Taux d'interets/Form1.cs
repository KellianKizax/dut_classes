using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_02_05_2020_Taux_d_interets
{
    public partial class frmInterets : Form
    {
        public frmInterets()
        {
            InitializeComponent();
        }

        // ---------- Fonctions -------------------------------------------------------

        private double Calculer(bool keyEnter)
        {
            double capital = double.Parse(txbCapitalDepart.Text.Substring(0, txbCapitalDepart.Text.Length - 2));
            double interet = (double.Parse(txbTauxInterets.Text.Substring(0, txbTauxInterets.Text.Length - 2)) ) /100;
            int annees;
            if (keyEnter)
            {
                annees = int.Parse(txbNbrAnnees.Text);
            }
            else
            {
                annees = int.Parse(txbNbrAnnees.Text.Substring(0, txbNbrAnnees.Text.Length - 7));
            }

            for (int i = 0; i < annees; i++)
            {
                capital += capital * interet;
            }
            
            return Math.Round(capital, 2);
        }

        // ------------- Button ---------------------------------------------------------

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRaz_Click(object sender, EventArgs e)
        {
            txbCapitalDepart.Text = String.Empty;
            txbTauxInterets.Text = String.Empty;
            txbNbrAnnees.Text = String.Empty;
            lblAffichCapitalFin.Text = "0,00 €";
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            lblAffichCapitalFin.Text = Calculer(false).ToString();
        }

        // ------------ TextBox ----------------------------------------------------------

        private void txbCapitalDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar != '.' && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Delete) || e.KeyChar == (char)(Keys.Back)) )
            {
                // On accepte
            }
            else if (e.KeyChar == ',' && !txbCapitalDepart.Text.Contains(","))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbTauxInterets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar != '.' && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Delete) || e.KeyChar == (char)(Keys.Back)) )
            {
                // On accepte
            }
            else if (e.KeyChar == ',' && !txbTauxInterets.Text.Contains(","))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbNbrAnnees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Delete) || e.KeyChar == (char)(Keys.Back)))
            {
                // On accepte
            }
            else if (e.KeyChar == ',' && !txbTauxInterets.Text.Contains(","))
            {

            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                lblAffichCapitalFin.Text = Calculer(true).ToString() + " €";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbCapitalDepart_Enter(object sender, EventArgs e)
        {
            txbCapitalDepart.Text = String.Empty;
        }

        private void txbTauxInterets_Enter(object sender, EventArgs e)
        {
            txbTauxInterets.Text = String.Empty;
        }

        private void txbNbrAnnees_Enter(object sender, EventArgs e)
        {
            txbNbrAnnees.Text = String.Empty;
        }

        private void txbCapitalDepart_Leave(object sender, EventArgs e)
        {
            if(!(txbCapitalDepart.Text == String.Empty))
            {
                txbCapitalDepart.Text = txbCapitalDepart.Text + " €";
            }
        }

        private void txbTauxInterets_Leave(object sender, EventArgs e)
        {
            if (!(txbTauxInterets.Text == String.Empty))
            {
                txbTauxInterets.Text = txbTauxInterets.Text + " %";
            }
        }

        private void txbNbrAnnees_Leave(object sender, EventArgs e)
        {
            if (!(txbNbrAnnees.Text == String.Empty))
            {
                txbNbrAnnees.Text = txbNbrAnnees.Text + " années";
            }
        }

        
    }
}
