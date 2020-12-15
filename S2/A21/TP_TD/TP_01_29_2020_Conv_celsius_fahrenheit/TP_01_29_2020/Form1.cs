using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_01_29_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReinit_Click(object sender, EventArgs e)
        {
            txbCelsius.Text = String.Empty;
            txbFarhenheit.Text = String.Empty;
            rdbCelsiusFarhenheit.Checked = false;
            rdbFarhenheitCelsius.Checked = false;
        }

        private void rdbCelsiusFarhenheit_CheckedChanged(object sender, EventArgs e)
        {
            if ( rdbCelsiusFarhenheit.Checked && txbCelsius.Text != String.Empty)
            {
                double tempF = 32 + (9/5) * double.Parse(txbCelsius.Text);
                txbFarhenheit.Text = tempF.ToString();
            }
        }

        private void rdbFarhenheitCelsius_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFarhenheitCelsius.Checked && txbFarhenheit.Text != String.Empty)
            {
                double tempC = 32 + (9 / 5) * double.Parse(txbFarhenheit.Text);
                txbCelsius.Text = tempC.ToString();
            }
        }

        private void txbCelsius_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
            }
            else if (e.KeyChar == (char)(Keys.Back))
            {
                
            }
            else if (e.KeyChar == '-' && !txbCelsius.Text.Contains("-") && txbCelsius.SelectionStart == 0)
            {

            }
            else if (e.KeyChar == ',' && !txbCelsius.Text.Contains(","))
            {

            }
            else if ( e.KeyChar == (char)(Keys.Enter) && txbCelsius.Text != String.Empty)
            {
                double tempF = 32 + (9 / 5) * double.Parse(txbCelsius.Text);
                txbFarhenheit.Text = tempF.ToString();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbFarhenheit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
            }
            else if (e.KeyChar == (char)(Keys.Back))
            {

            }
            else if (e.KeyChar == '-' && !txbFarhenheit.Text.Contains("-") && txbFarhenheit.SelectionStart == 0)
            {

            }
            else if (e.KeyChar == ',' && !txbFarhenheit.Text.Contains(","))
            {

            }
            else if (e.KeyChar == (char)(Keys.Enter) && txbFarhenheit.Text != String.Empty)
            {
                double tempC = (double.Parse(txbFarhenheit.Text) - 32) / (9/5) ;
                txbCelsius.Text = tempC.ToString();
            }
            else
            {
                e.Handled = true;
            }
        }

        /*
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        */
    }
}
