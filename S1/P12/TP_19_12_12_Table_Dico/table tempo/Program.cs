using System;
using System.Collections.Generic;
using System.IO;

namespace table
{
    class Program
    {
        static void Main()
        {
            StreamReader source = new StreamReader("tempo.txt");
            string ligne;

            Dictionary<string, List<int>> tableOccurence = new Dictionary<string, List<int>>();
            List<List<string>> l = new List<List<string>>();

            while ((ligne = source.ReadLine()) != null)
            {
                List<string> lmots = DecouperBis(ligne);
                l.Add(lmots);
            }

            ConstruitTableOccurenceMot(l, tableOccurence);

            //affichage de la table
            Console.WriteLine(ToString(tableOccurence));
        }

        public static List<string> DecouperBis(string pS)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';', '\t', '\n', '\r', '\''};
            List<string> res = new List<string>();

            string[] mots = pS.Split(delimiterChars);
            foreach (string m in mots)
            {
                res.Add(m);
            }
            return res;
        }

        public static void ConstruitTableOccurenceMot(List<List<string>> pLig, Dictionary<string, List<int>> pTocc)
        {
            int nol = 1;

            while (nol <= pLig.Count)
            {
                Console.WriteLine();
                foreach (string mot in pLig[nol - 1])
                {
                    if (!pTocc.ContainsKey(mot))
                    {
                        List<int> lc = new List<int>();
                        lc.Add(nol);
                        pTocc.Add(mot, lc);
                    }
                    else
                    {
                        pTocc[mot].Add(nol);
                    } 
                }
                nol = nol + 1;
            }
        }

        public static string ToString(Dictionary<string, List<int>> t)
        {
            string s = string.Empty;
            foreach (KeyValuePair<string, List<int>> p in t)
            {
                s = s + "[ " + string.Format("{0,-10}", p.Key) + ",";
                s = s + "\t[";
                foreach (int i in p.Value)
                {
                    s = s + i + " ";
                }
                s += "]]\n";
            }
            return "<" + s + ">";
        }
    }
}
