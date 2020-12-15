using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace table_gaulois
{
    class Program
    {
        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Write("Chargement des fichiers");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".\n\n\n");

            Dictionary<int, List<string>> dicoGaulois = RemplirTableFromFile("gaulois.txt");
            Dictionary<int, List<string>> dicoVillage = RemplirTableFromFile("village.txt");

            Console.WriteLine("Fichiers chargés !\n\n\n");

            string reponse = "";
            while (!(reponse == "4"))
            {
                Console.WriteLine("===============Tableau de commandes===============");
                Console.WriteLine("\t(1) Afficher un tableau\n");
                Console.WriteLine("\t(2) Chercher des infos\n");
                Console.WriteLine("\t(3) Afficher les gaulois d'un village\n");
                Console.WriteLine("\t(4) Quitter");
                Console.Write(">> ");
                reponse = Console.ReadLine();

                if (reponse == "1")
                {
                    Menu1(dicoGaulois, dicoVillage);
                }
                else if (reponse == "2")
                {
                    Menu2(dicoGaulois, dicoVillage);
                }
                else if (reponse == "3")
                {
                    Menu3(dicoGaulois, dicoVillage);
                }
                else
                {
                    //Rien
                }
            }
        }

        public static void Menu1(Dictionary<int, List<string>> Xgaulois, Dictionary<int, List<string>> Xvillages)
        {
            Console.WriteLine("Quel tableau ? (1) Gaulois ; (2) Village ?");
            Console.Write(">> ");
            string reponse = Console.ReadLine();
            if(reponse == "1")
            {
                Console.WriteLine(TableToString(Xgaulois));
            }
            else if (reponse == "2")
            {
                Console.WriteLine(TableToString(Xvillages));
            }
            else
            {
                Console.WriteLine("Mauvais choix, retour au menu.");
            }
        }

        public static void Menu2(Dictionary<int, List<string>> Xgaulois, Dictionary<int, List<string>> Xvillages)
        {
            Console.WriteLine("Quel tableau ? (1) Gaulois ; (2) Village ?");
            Console.Write(">> ");
            string dico = Console.ReadLine();
            Console.WriteLine("Quel clé ?");
            Console.Write(">> ");
            int clé = int.Parse(Console.ReadLine());
            if (dico == "1")
            {
                DicoCherchInfos(Xgaulois, clé);
            }
            else if (dico == "2")
            {
                DicoCherchInfos(Xvillages, clé);
            }
            else
            {
                Console.WriteLine("Mauvais choix, retour au menu.");
            }
        }

        public static void Menu3(Dictionary<int, List<string>> Xgaulois, Dictionary<int, List<string>> Xvillages)
        {
            Console.WriteLine("Quel village ?");
            Console.Write(">> ");
            string village = Console.ReadLine();
            AfficheGauloisFromVillage(Xgaulois, village);
        }

        //==============================================================================================

            public static void AfficheGauloisFromVillage(Dictionary<int, List<string>> Xgaulois, string XnbVillage)
        {
            foreach(KeyValuePair<int, List<string>> pair in Xgaulois)
            {
                if ( pair.Value[(pair.Value.Count-1)] == XnbVillage)
                {
                    Console.Write("< " + pair.Key + "\t[ ");
                    foreach (string element in pair.Value)
                    {
                        Console.Write("\t" + element);
                    }
                    Console.WriteLine("\t]>");
                }
                else
                {
                    //Rien
                }
            }
        }


        /*  DicoCherchInfos :   proc    :   affiche les éléments correspondant à une clé d'un tableau
         *                                  si la clé n'existe pas affiche un message d'erreur
         *  PARAMETRES :
         *      Xdico   :   Dictionary<int, List<string>>   :   dictionaire source
         *      Xclé    :   int     :   valeur de la clé désirée
         *  LOCAL :
         *      liElements  :   List<string>    :   liste contenant les éléments rattachés à la clé Xcle
         */
        public static void DicoCherchInfos(Dictionary<int, List<string>> Xdico, int Xcle)
        {
            if(!Xdico.ContainsKey(Xcle))
            {
                Console.WriteLine(">> Clé non présente dans le dictionaire.");
            }
            else
            {
                List<string> liElements = new List<string>();
                liElements = Xdico[Xcle];
                Console.Write("< " + Xcle + "\t[ ");
                foreach (string element in liElements)
                {
                    Console.Write("\t" + element);
                }
                Console.WriteLine("\t]>");
            }
        }

        //==============================================================================================

        /*  RemplirTableFromFile    :   fonc    :   Dictionary<int, List<string>>   :   transforme un fichier en un dictionaire
         *  PARAMETRES :
         *      Xfile   :   string  :   nom/lien du fichier
         *  LOCAL :
         *      srcFile     :   StreamReader    :   fichier à traiter
         *      resTable    :   Dictionary<int, List<string>>   :   tableau résultat
         *  RETOUR :
         *      resTable    :   Dictionary<int, List<string>>   :   "
         */
        public static Dictionary<int, List<string>> RemplirTableFromFile(string Xfile)
        {
            StreamReader srcFile = new StreamReader(Xfile);
            Dictionary<int, List<string>> resTable = TableFromStreamreader(srcFile);
            return resTable;
        }

        /*  TableToString    :   fonc    :   string  :   transforme un dictionaire en une chaine de charactères
         *  PARAMETRES :
         *      XdicoIntListString  :   Dictionary<int, List<string>>   :   dictionaire à traiter
         *  LOCAL :
         *      res :   string  :   chaine de charactères representant le dictionaire
         *  RETOUR :
         *      res :   string  :   chaine de charactères representant le dictionaire
         */
        public static string TableToString(Dictionary<int, List<string>> XdicoIntListString)
        {
            string res = string.Empty;
            foreach (KeyValuePair<int, List<string>> p in XdicoIntListString)
            {
                res = res + "< " + p.Key;
                res = res + "\t[ ";
                foreach (string i in p.Value)
                {
                    res = res + "\t" + i + ",";
                }
                res += "]>\n";
            }
            return res;
        }

        /*  TableFromStreamreader   :   fonc    :   Dictionary<int, List<string>>   :   créé un dictionaire à partir d'un fichier
         *  PARAMETRES :
         *      Xsrc    :   StreamReader    :   fichier source
         *  LOCAL :
         *      ligne           :   string              :   contient la ligne courante du fichier
         *      liLignes        :   List<List<string>>  :   liste de liste de chaine de charactères,
         *                                                  chaque chaine correspond à un élément d'une
         *                                                  ligne, chaque ligne étant représentée par les
         *                                                  sous listes.
         *      res             :   Dictionary<int, List<string>>   :   Dictionaire contenant les valeurs des lignes et la clé correspondante
         *      ligneElements   :   List<string>        :   liste des éléments de la ligne courante du fichier
         *      liValues        :   List<string>        :   liste des éléments de la ligne courante sans la clé
         *  RETOUR :
         *      res :   Dictionary<int, List<string>>   :   Dictionaire contenant les valeurs des lignes et la clé correspondante
         */
        public static Dictionary<int, List<string>> TableFromStreamreader( StreamReader Xsrc)
        {
            string ligne = string.Empty;
            List<List<string>> liLignes = new List<List<string>>();
            Dictionary<int, List<string>> res = new Dictionary<int, List<string>>();

            while ((ligne = Xsrc.ReadLine()) != null)
            {
                List<string> ligneElements = DecouperBis(ligne);
                liLignes.Add(ligneElements);
            }

            for(int i = 0; i<liLignes.Count; i++)
            {
                List<string> liValues = new List<string>();
                for(int y = 1; y<liLignes[i].Count; y++)
                {
                    liValues.Add(liLignes[i][y]);
                }
                res.Add(int.Parse(liLignes[i][0]), liValues);
            }

            return res;
        }

        /*  DecouperBis :   fonc    :   List<string>    :   découpe une chaine de charactères à partir de ';'
         *                                                  range les éléments dans une liste
         *  PARAMETRES :
         *      Xstring :   string  :   chaine de charactères à traiter
         *  LOCAL :
         *      delimiterChar   :   char    :   variable contenant le charactère délimitant les découpes
         *      res :   List<string>    :   liste des éléments extraits de la chaine de charactères
         *      mots    :   string[]    :   tableau contenant les éléments resultats de la fonction .Split()
         *  RETOUR :
         *      res :   List<string>    :   liste des éléments extraits de la chaine de charactères
         */
        public static List<string> DecouperBis(string Xstring)
        {
            char delimiterChar = ';';
            List<string> res = new List<string>();

            string[] mots = Xstring.Split(delimiterChar);
            foreach (string m in mots)
            {
                res.Add(m);
            }
            return res;
        }


    }
}
