using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_02_10_2020_Convertisseur_Monnaie
{
    public partial class frmDepart : Form
    {
        public static string[] tab_pays = { "algerie", "argentine", "danemark", "etats - unis", "inde", "japon", "royaume uni", "suisse" };
        public static string[] tab_devise = { "Dinar", "Peso Argentin", "Couronne Danoise", "Dollar Americain", "Roupie", "Yen", "Livre Sterling", "Franc Suisse" };
        public static double[] tab_taux = { 131.73, 66.48, 7.47, 1.09, 78.10, 120.15, 0.85, 1.07 };

        public frmDepart()
        {
            InitializeComponent();
        }

        private void frmDepart_Load(object sender, EventArgs e)
        {
            grb_conversion.Hide();
            grb_informations.Hide();
            lbl_temp0.Hide();
            lbl_temp1.Hide();
        }

        private void txt_somme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Delete) || e.KeyChar == (char)(Keys.Back)))
            {
                // On accepte
            }
            else if (e.KeyChar == ',' && !txt_somme.Text.Contains(","))
            {

            }
            else if(e.KeyChar == '-' && !txt_somme.Text.Contains("-") && txt_somme.SelectionStart == 0)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void rdb_algerie_CheckedChanged(object sender, EventArgs e)
        {
            lbl_resultat.Text = String.Empty;
            if (txt_somme.Text != String.Empty)
            {
                RadioButton rdb = (RadioButton)sender;

                int indice = Convert.ToInt32(rdb.Tag);

                string devise = tab_devise[indice];
                double taux = tab_taux[indice];

                double somme = double.Parse(txt_somme.Text);

                rdb_euromonnaie.Text = "Euro vers " + devise;
                rdb_monnaieeuro.Text = devise + " vers Euro";

                lbl_valeuro.Text = "1 euro = " + taux.ToString() + " " + devise;
                lbl_valmonnaie.Text = "1 " + devise + " = " + (1 / taux) + " euro";

                lbl_temp0.Text = somme.ToString() + " euros = " + (somme * taux).ToString() + " " + devise;
                lbl_temp1.Text = somme.ToString() + " " + devise + " = " + ((1 / taux) * somme).ToString() + " euros";

                grb_conversion.Show();
            }
        }

        private void rdb_euromonnaie_CheckedChanged(object sender, EventArgs e)
        {
            // Euro vers monnaie
            if ( Convert.ToInt32(((RadioButton)sender).Tag) == 0)
            {
                lbl_resultat.Text = lbl_temp0.Text;
            }
            // monnaie vers Euro
            else if (Convert.ToInt32(((RadioButton)sender).Tag) == 1)
            {
                lbl_resultat.Text = lbl_temp1.Text;
            }
            else
            {
                // rien
            }
        }

        private void btn_convertir_Click(object sender, EventArgs e)
        {
            if (lbl_temp0.Text != String.Empty)
            {
                grb_informations.Show();
            }
        }

        private void btn_raz_Click(object sender, EventArgs e)
        {
            txt_somme.Text = String.Empty;
            foreach(RadioButton rdb in grb_pays.Controls)
            {
                rdb.Checked = false;
            }
            rdb_euromonnaie.Checked = false;
            rdb_monnaieeuro.Checked = false;

            lbl_temp0.Text = String.Empty;
            lbl_temp1.Text = String.Empty;

            grb_conversion.Hide();
            grb_informations.Hide();
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
