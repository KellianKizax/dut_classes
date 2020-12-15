using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_02_14_2020_Conjugaison
{
    public partial class frmDepart : Form
    {
        
        public static string[] verbes = { "aimer", "accepter", "expliquer", "voler", "dessiner", "se promener", "s'amuser", "gagner", "garder", "former", "regarder", "exister", "fermer", "garder", "avacancer", "briller", "brûler", "retourner", "rencontrer", "refuser", "jouer" };
        public static string[,] pronoms = new string[4, 6] { { "j'", "tu", "il / elle", "nous", "vous", "ils / elles" }, { "je", "tu", "il / elle", "nous", "vous", "ils / elles" },
                                        { "je me", "tu te", "il / elle se", "nous nous", "vous vous", "ils / elles se" }, {"je m'", "tu t'", "il / elle s'", "nous nous", "vous vous", "ils / elles s'" } };
        public static string[,] terminaisons = new string[4, 6] { {"e", "es", "e", "ons", "ez", "ent" }, { "erai", "eras", "era", "erons", "erez", "eront" }, { "ais", "ais", "ait", "ions", "iez", "aient" }, { "ai", "as", "a", "âmes", "âtes", "èrent" } };
        

        private void AfficheResultats(string[] pronoms, string radical, string[] terminaisons)
        {
            lblJe.Text = pronoms[0] + " " + radical + terminaisons[0];
            lblTu.Text = pronoms[1] + " " + radical + terminaisons[1];
            lblElle.Text = pronoms[2] + " " + radical + terminaisons[2];

            lblNous.Text = pronoms[3] + " " + radical + terminaisons[3];
            lblVous.Text = pronoms[4] + " " + radical + terminaisons[4];
            lblElles.Text = pronoms[5] + " " + radical + terminaisons[5];
            
            grbVerbeConjug.Show();
        }

        private int TypeVerbe(string verbe)
        {
            int res = 1;
            char[] voyelles = { 'a', 'e', 'i', 'o', 'u', 'y' };

            if (verbe.Contains(' '))
            {
                res = 2;
            }
            else if (verbe.Contains('\''))
            {
                res = 3;
            }
            else
            {
                foreach( char lettre in voyelles)
                {
                    if (verbe[0] == lettre)
                    {
                        res = 0;
                    }
                }
            }

            return res;
        }

        private string radicalTypeVerbe(string verbe, int typevrb)
        {
            string res = string.Empty;
            if (typevrb == 0 || typevrb == 1)
            {
                res = verbe.Substring(0, verbe.Length - 2);
            }
            else if (typevrb == 2)
            {
                res = verbe.Substring(3, verbe.Length - 5);
            }
            else if (typevrb == 3)
            {
                res = verbe.Substring(2, verbe.Length - 4);
            }

            return res;
        }

        public frmDepart()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDepart_Load(object sender, EventArgs e)
        {
            cboVerbes.Items.AddRange(verbes);
            grbChoixTemps.Hide();
            grbVerbeConjug.Hide();
        }

        private void cboVerbes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbChoixTemps.Show();
        }

        private void rdbPresent_Click(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            // 0 : present / 1 : futur / 2 : imparfait / 3 : passé simple
            int indiceTemps = Convert.ToInt32(rdb.Tag);
            string verbe = cboVerbes.Text;

            int typverbe = TypeVerbe(verbe);

            string radical = radicalTypeVerbe(verbe, typverbe);

            string[] pronomsVerbe = new string[6];
            for (int i = 0; i < 6; i++)
            {
                pronomsVerbe[i] = pronoms[typverbe, i];
            }

            string[] terminaisonsVerbe = new string[6];
            for (int i = 0; i < 6; i++)
            {
                terminaisonsVerbe[i] = terminaisons[indiceTemps, i];
            }

            AfficheResultats(pronomsVerbe, radical, terminaisonsVerbe);
        }

        private void btnNouvVerbe_Click(object sender, EventArgs e)
        {

        }
    }
}
