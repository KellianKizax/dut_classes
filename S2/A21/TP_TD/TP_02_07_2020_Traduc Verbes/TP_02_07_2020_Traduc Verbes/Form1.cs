using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_02_07_2020_Traduc_Verbes
{
    public partial class frmDepart : Form
    {
        List<string> listAller = new List<string>
        {
            "to go", "gehen", "ir", "andare"
        };
        List<string> listBoire = new List<string>
        {
            "to drink", "trinken", "beber", "bere"
        };
        List<string> listChanter = new List<string>
        {
            "to sing", "singen", "cantar", "cantare"
        };
        List<string> listDanser = new List<string>
        {
            "to dance", "tanzen", "bailar", "ballare"
        };
        List<string> listFermer = new List<string>
        {
            "to close", "schliessen", "cerrar", "chiudere"
        };
        List<string> listManger = new List<string>
        {
            "to eat", "essen", "comer", "mangiare"
        };
        List<string> listTravailler = new List<string>
        {
            "to work", "arbeiten", "trabajar", "lavorare"
        };
        
        //----------------------------------------------------------------------------

        public frmDepart()
        {
            InitializeComponent();
        }

        private void frmDepart_Load(object sender, EventArgs e)
        {
            grbResultats.Hide();
            Dictionary<string, List<string>> dicoVerbes = new Dictionary<string, List<string>>
            {
                { "Aller", listAller },
                { "Boire", listBoire },
                { "Chanter", listChanter },
                { "Danser", listChanter },
                { "Fermer", listFermer },
                { "Manger", listManger },
                { "Travailler", listTravailler }
            };

            foreach (KeyValuePair<string, List<string>> valuepair in dicoVerbes)
            {
                cboChoixverbe.Items.Add(valuepair.Key);
            }
        }

        private void rdbAnglais_CheckedChanged(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> dicoVerbes = new Dictionary<string, List<string>>
            {
                { "Aller", listAller },
                { "Boire", listBoire },
                { "Chanter", listChanter },
                { "Danser", listChanter },
                { "Fermer", listFermer },
                { "Manger", listManger },
                { "Travailler", listTravailler }
            };

            if (dicoVerbes.TryGetValue(cboChoixverbe.Text, out List<string> traductions))
            {
                grbResultats.Show();
                lblResultats.Text = "Traduction de \"" + cboChoixverbe.Text + "\" en " + ((RadioButton)sender).Text.ToLower() + " : ";
                lblResultats.Text += traductions[Convert.ToInt32(((RadioButton)sender).Tag)];
            }

        }

        private void cboChoixverbe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
