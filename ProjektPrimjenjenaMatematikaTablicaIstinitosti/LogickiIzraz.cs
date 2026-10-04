using System;                         
using System.Text;      

namespace ProjektPrimjenjenaMatematikaTablicaIstinitosti { 
  
    // 1. umjesto varijabli upiše 0 i 1
    // 2. rješava zagrade od najunutarnjije prema van
    // 3. rješava po prioritetu: ¬, pa ∧, pa ∨, pa →, pa ↔

    public class LogickiIzraz                             
    {
        public string Izraz { get; }           

        public int BrojVarijabli { get; }        

        public int BrojRedaka => 1 << BrojVarijabli;          
        // Broj redaka tablice = 2^n. "1 << n" je jedinica pomaknuta n mjesta ulijevo u binarnom zapisu, tj. 2 na n-tu.


        public LogickiIzraz(string izraz, int brojVarijabli)  
        {

            if (string.IsNullOrWhiteSpace(izraz))
                throw new FormatException("Izraz je prazan.");

            Izraz = izraz.Replace(" ", "");
            BrojVarijabli = brojVarijabli;

            Provjeri();
        }

        private void Provjeri()
        {
            bool ocekujemOperand = true; // true je za slova, false ocekuje znak
            int otvoreneZagrade = 0; // (  povećava, ) smanjuje

            for (int i = 0; i < Izraz.Length; i++)
            {
                char c = Izraz[i];
                int poz = i + 1;

                if (JeVarijabla(c))
                {
                    if (!ocekujemOperand)
                        throw new FormatException($"Nedostaje operator prije '{c}' (pozicija {poz}).");
                    ocekujemOperand = false;  
                }
                else if (c == '¬' || c == '(')
                {
                    if (!ocekujemOperand)           
                        throw new FormatException($"Nedostaje operator prije '{c}' (pozicija {poz}).");
                    if (c == '(') otvoreneZagrade++; // Zapamtimo da je otvorena zagrada
                }
                else if (c == ')')
                {
                    if (ocekujemOperand)  // nađe npr. "()" ili "(A∧)"
                        throw new FormatException($"Nedovrsen izraz prije ')' (pozicija {poz}).");
                    otvoreneZagrade--;
                    if (otvoreneZagrade < 0)
                        throw new FormatException($"Višak zagrade ')' (pozicija {poz}).");
                }
                else if (JeBinarni(c)) // jel znakic
                {
                    if (ocekujemOperand)  // Npr. "∧A" ili "A∨∧B"
                        throw new FormatException($"Operatoru '{c}' nedostaje lijeva strana (pozicija {poz})."); // Javljamo grešku.
                    ocekujemOperand = true;
                }
                else if (c >= 'A' && c <= 'F')
                {
                    throw new FormatException($"Varijabla '{c}' nije dozvoljena za {BrojVarijabli} varijabli (pozicija {poz})."); // Javljamo grešku.
                }
                else
                {
                    throw new FormatException($"Nepoznat znak '{c}' (pozicija {poz}).");
                }
            }

            if (ocekujemOperand) // završava operatorom npr. "A∧" ili "¬".
                throw new FormatException("Izraz nije dovršen (završava operatorom).");

            if (otvoreneZagrade > 0)
                throw new FormatException("Nedostaje zatvorena zagrada ')'.");
        }





        public bool Izracunaj(bool[] vrijednosti)
        {
            string s = UvrstiVrijednosti(vrijednosti); // vrijednost za svaku varijablu
            {

                while (s.Contains('('))  //rjesavamo se zagrada
                {
                    int otvorena = s.LastIndexOf('(');
                    int zatvorena = s.IndexOf(')', otvorena);

                    string unutra = s.Substring(otvorena + 1, zatvorena - otvorena - 1);
                    char rezultat = RijesiBezZagrada(unutra);

                    s = s.Substring(0, otvorena) + rezultat + s.Substring(zatvorena + 1);
                }

                return RijesiBezZagrada(s) == '1';
            }
        }
        private string UvrstiVrijednosti(bool[] vrijednosti)
        {
            char[] znakovi = Izraz.ToCharArray();

            for (int i = 0; i < znakovi.Length; i++)
            {
                if (JeVarijabla(znakovi[i]))
                {
                    int indeks = znakovi[i] - 'A';
                    if (vrijednosti[indeks])
                        znakovi[i] = '1';
                    else
                        znakovi[i] = '0';
                }
            }

            return new string(znakovi);
        }


        private static char RijesiBezZagrada(string s) // static jer ne treba podatke, samo string koji dobije
        {
            // negacija
            while (s.Contains('¬'))
            {
                int i = s.LastIndexOf('¬');
                char vrijednost = s[i + 1];
                char negirano = vrijednost == '1' ? '0' : '1';
                s = s.Substring(0, i) + negirano + s.Substring(i + 2);
            }

            s = RijesiOperator(s, '∧', false);
            s = RijesiOperator(s, '∨', false);

            // implikacija
            s = RijesiOperator(s, '→', true); // true - tražimo zadnju implikaciju

            // ekvivalencija
            s = RijesiOperator(s, '↔', false);

            return s[0];
        }

        private static string RijesiOperator(string s, char op, bool zdesna)
        {
            int i = zdesna ? s.LastIndexOf(op) : s.IndexOf(op); // nađemo prvu (ili zadnju) pojavu operatora
            while (i != -1)
            {
                bool a = s[i - 1] == '1'; // lijevo od operatora je sigurno znamenka (negacije i zagrade su već riješene)
                bool b = s[i + 1] == '1'; // desno isto
                bool r = Primijeni(op, a, b);
                s = s.Substring(0, i - 1) + (r ? '1' : '0') + s.Substring(i + 2); //ta 3 znaka su sad samo 0 ili 1
                i = zdesna ? s.LastIndexOf(op) : s.IndexOf(op);
            }
            return s;
        }

        private static bool Primijeni(char op, bool a, bool b)
        {
            switch (op)
            {
                case '∧': return a && b;
                case '∨': return a || b;
                case '→': return !a || b;
                case '↔': return a == b;
                default: throw new InvalidOperationException($"Nepoznat operator '{op}'.");
            }
        }

        private bool JeVarijabla(char c)
        {
            return c >= 'A' && c < 'A' + BrojVarijabli;
        }

        private static bool JeBinarni(char c)
        {
            return c == '∧' || c == '∨' || c == '→' || c == '↔';
        }


        public bool[] VrijednostiRetka(int redak)
        {
            var v = new bool[BrojVarijabli]; // jedno mjesto za svaku varijablu
            for (int j = 0; j < BrojVarijabli; j++)
                v[j] = ((redak >> (BrojVarijabli - 1 - j)) & 1) == 1; // npr. redak 5 = 101: A=1, B=0, C=1.
            return v;
        }
    }
}
