using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_01_29_2020_Cotisation_sportive
{
    public partial class frmCotisationSport : Form
    {
        public frmCotisationSport()
        {
            InitializeComponent();
        }

        private void frmCotisationSport_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Back) || e.KeyChar == (char)(Keys.Delete))
            {
                // On autorise
            }
            else if (e.KeyChar == (char)(Keys.Enter))
            {
                lblAffichPrixBase.Text = CalculPrixBase().ToString() + " €";
                lblAffichPrixReduc.Text = CalculCotisation().ToString() + " €";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private double CalculPrixBase()
        {
            double cotisation = 0;
            int nbEnfants = int.Parse(txbNbrEnfants.Text);

            if (nbEnfants == 1)
            {
                cotisation = 100;
            }
            else if (nbEnfants == 2)
            {
                cotisation = 100 + 85;
            }
            else if (nbEnfants >= 3)
            {
                cotisation = 100 + 85 + (60 * (nbEnfants - 2));
            }
            else { } // Rien

            return cotisation;
        }

        private double CalculCotisation()
        {
            double cotisation = CalculPrixBase();
            double reduction = 1;


            if (ckbMembre.Checked)
            {
                if (ckbAnim.Checked)
                {
                    reduction = 0.70;
                }
                else
                {
                    reduction = 0.80;
                }
            }
            else
            {
                if (ckbAnim.Checked)
                {
                    reduction = 0.70;
                }
            }

            return cotisation * reduction;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            lblAffichPrixBase.Text = CalculPrixBase().ToString() + " €";
            lblAffichPrixReduc.Text = CalculCotisation().ToString() + " €";
        }
    }
}
