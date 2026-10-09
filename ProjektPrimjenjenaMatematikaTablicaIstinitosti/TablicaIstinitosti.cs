using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPrimjenjenaMatematikaTablicaIstinitosti
{
	public class TablicaIstinitosti : Form
	{
		private DataGridView? gridView;
        private char[] varijable = { 'A', 'B', 'C', 'D', 'E', 'F' };
        private int _brojVarijabli;
        private int _brojRedaka;
        private int _brojStupaca;
        private int _indeksRezultata;

		public TablicaIstinitosti(string naslov, int brojVarijabli)
		{
            _brojVarijabli = brojVarijabli;
            _brojRedaka = 1 << _brojVarijabli; // 2^n kombinacija
            _brojStupaca = brojVarijabli + 1;
            _indeksRezultata = _brojStupaca - 1;
            InicijalizirajDijelove(naslov);
            NacrtajTablicuIstinitosti();
		}



		private void InicijalizirajDijelove(string naslov)
		{
            this.Text = naslov;
            this.Size = new Size(640, 480);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            // Svi podatci koji su nam potrebni za tablicu
            gridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                ColumnCount = _brojStupaca,
                ColumnHeadersVisible = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };

            // Poravnanje tekst po sredini
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Postavljanje fonta i pozadinske boje
            gridView.Columns[_indeksRezultata].DefaultCellStyle.Font = new Font(gridView.Font, FontStyle.Bold);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font(gridView.Font, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 165, 201, 235);
            gridView.EnableHeadersVisualStyles = false; // Ovo je potrebno kako bi system čitao vrijednost iz gornje linije umjesto korištenja user defaulta

            // Uklanjanje automatskog selectiona
            gridView.DefaultCellStyle.SelectionBackColor = SystemColors.Window;
            gridView.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText; 
            gridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = gridView.ColumnHeadersDefaultCellStyle.BackColor;
            gridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = gridView.ColumnHeadersDefaultCellStyle.ForeColor;

            //Dodajemo tablicu u prozor
            this.Controls.Add(gridView);
        }

        private void NacrtajTablicuIstinitosti()
        {
            // Dodavanje imena stupaca
			for (int i = 0; i < _brojVarijabli; i++) 
			{
                gridView.Columns[i].Name = Convert.ToString(varijable[i]);
			}
            gridView.Columns[_indeksRezultata].Name = "Rezultat";
        }


        public void PopuniRedak(int brojRedka, bool[] redak, bool rjesenje)
        {
            if(brojRedka > _brojRedaka) return;

            string[] cijeliRedak = new string[_brojStupaca];

            for (int i = 0; i < _brojVarijabli; i++) 
            {
                cijeliRedak[i] = redak[i] ? "1" : "0";
            }

            cijeliRedak[_indeksRezultata] = rjesenje ? "1" : "0";

            gridView.Rows.Add(cijeliRedak);
        }
    }
}
