using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjektPrimjenjenaMatematikaTablicaIstinitosti
{
    public partial class Form2 : Form
    {
        private int brojVarijabli;
        private LogickiIzraz? izraz;                              // Zadnji ispravno upisan izraz (null dok ga nema).
        
        public Form2(int broj)
        {
            InitializeComponent();
            brojVarijabli = broj;
            btnA.Enabled = brojVarijabli >= 1;
            btnB.Enabled = brojVarijabli >= 2;
            btnC.Enabled = brojVarijabli >= 3;
            btnD.Enabled = brojVarijabli >= 4;
            btnE.Enabled = brojVarijabli >= 5;
            btnF.Enabled = brojVarijabli >= 6;


        }

        private void btnA_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'A';
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'B';
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'C';
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'D';
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'E';
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += 'F';
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lblIzraz.Text.Length > 0) {
                lblIzraz.Text = lblIzraz.Text.Substring(0, lblIzraz.Text.Length - 1);
            }
            
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblIzraz.Text = "";
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '∨';
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '∧';
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '¬';
        }

        private void btnImpl_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '→';
        }

        private void btnEkv_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '↔';
        }

        private void btnLeftBrackert_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += '(';
        }

        private void btnRightBracket_Click(object sender, EventArgs e)
        {
            lblIzraz.Text += ')';
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            string upisano = lblIzraz.Text;                       // String koji je korisnik upisao preko gumba.

            try
            {
                izraz = new LogickiIzraz(upisano, brojVarijabli); // Provjeri izraz i spremi ga za kasnije (ispis tablice).

                // using je ovdje kako bi se prosla tablica istinitosti izbrisala iz memorije (Ovo nije AI, ovo fakat znam Sruk ako ovaj using maknes ubit cu te)

                using(var tablicaIstinitosti = new TablicaIstinitosti(izraz.Izraz, brojVarijabli))
                {
                    for (int i = 0; i < (1 << brojVarijabli); i++)
                    {
                        bool[] redak = izraz.VrijednostiRetka(i);
                        bool rezultat = izraz.Izracunaj(redak);
                        tablicaIstinitosti.PopuniRedak(i, redak, rezultat);
                    }
                    tablicaIstinitosti.ShowDialog(this);
                }
            }
            catch (FormatException ex)
            {
                izraz = null;                                     // Neispravan izraz se ne pamti.
                MessageBox.Show(ex.Message, "Neispravan izraz");  // Korisniku kažemo što ne valja.
            }
        }
    }
}
