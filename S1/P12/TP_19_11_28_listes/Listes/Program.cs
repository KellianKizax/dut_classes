using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            AffichageList(TriDistribution(CreaRndList(154, 1204, 11732)));

        }

        //=====================================================================================================================

        // Tri par distribution à partir de bases
        public static List<int> TriDistribution(List<int> Xlist)
        {
            int maxList = ListMax(Xlist);
            int longNbMax = (maxList.ToString()).Length - 1;
            // Creation et initialisation d'un tableau de listes
            List<int>[] tabTri = new List<int>[10];
            for (int i = 0; i < 10; i++)
            {
                tabTri[i] = new List<int>();
            }
            //tabTri[xTAB][yLIST] = ... ;


            //Boucle pour traiter toutes les bases
            for (int i = 0; i <= longNbMax; i++)
            {
                //Boucle pour placer les nombres dans la bonne liste en fonction de leur base
                foreach (int item in Xlist)
                {
                    int indice = ExtraireChiffreDeNombre(item, i);
                    tabTri[indice].Add(item);
                }
                Xlist.Clear();

                //Boucle pour re-entrer les nombres dans la liste dans le nouvel ordre, puis clean des listes du tableau
                for (int y = 0; y < 10; y++)
                {
                    foreach (int item in tabTri[y])
                    {
                        Xlist.Add(item);
                    }
                    tabTri[y].Clear();
                }
            }
            return Xlist;
        }

        public static int ExtraireChiffreDeNombre(int Xnbr, int Xindice)
        {
            Xnbr = (int)(Xnbr / Math.Pow(10, Xindice)) % 10;
            return Xnbr;
        }



        //=====================================================================================================================

        public static int ListMax(List<int> Xlist)
        {
            int max = Xlist[0];
            foreach( int item in Xlist)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        /*  AffichageList   :   proc    :   affiche le contenu d'une liste
         *  PARAMETRES :
         *      Xlist   :   List<int>   :   liste d'entiers
         */
        public static void AffichageList(List<int> Xlist)
        {
            foreach(int val in Xlist)
            {
                Console.WriteLine(">> "+val);
            }
        }

        /*  CreaRndList   :   proc    :   complete le contenu d'une liste d'entiers aleatoirement
         *  PARAMETRES :
         *      Xnb     :   int         :   nombre de valeurs
         *      Xmin    :   int         :   valeur minimum
         *      Xmax    :   int         :   valeur maximum
         *  LOCAL :
         *      rnd     :   random      :   Random
         */
        public static List<int> CreaRndList(int Xnb, int Xmin, int Xmax)
        {
            List<int> list = new List<int>(Xnb-1);
            Random rnd = new Random();
            for (int i = 0; i< Xnb; i++)
            {
                list.Add(rnd.Next(Xmin, Xmax + 1));
            }
            return list;
        }

        /*  FiboList    :   fonc    :   List<int>   :   retourne les Xnb premières valeurs de la suite de Fibonnaci dans une liste
         *  PARAMETRES :
         *      Xnb         :   int         :   nombre de première valeur de la suite de Fibonnaci à retourner
         *  LOCAL :
         *      FiboList    :   List<int>   :   liste contenant la suite de F
         *      terme       :   int         :   terme courant de la suite de F
         *      termeprec   :   int         :   terme précédent au terme courant de la suite
         *      temp        :   int         :   variable temporaire au calcul du terme suivant de la suite
         *  RETOUR :
         *      FiboList    :   List<int>
         */
        public static List<int> FiboList(int Xnb)
        {
            List<int> FiboList;
            FiboList = new List<int>();
            int terme = 1;
            int termeprec = 0;
            int temp;

            for (int i = 0; i<Xnb; i++)
            {
                temp = terme + termeprec;
                termeprec = terme;
                terme = temp;
                FiboList.Add(terme);
            }
            return FiboList;
        }

        /*  OccurenceList   :   fonc    :   int :   retourne le nombre d'occurences d'une valeur dans une liste d'entiers
         *  PARAMATRES :
         *      Xlist   :   List<int>   :   Liste d'entiers non vide
         *      Xval    :   int         :   valeur dont on calcule le nombre d'occurences
         *  LOCAL :
         *      occurence   :   int     :   nombre d'occurences de Xval dans Xlist
         *  RETOUR :
         *      occurence   :   int
         *      
         */
        public static int OccurenceList(int Xval, List<int> Xlist)
        {
            int occurence = 0;
            foreach(int x in Xlist)
            {
                if (x == Xval)
                {
                    occurence++;
                }
                else { }//Rien
            }
            return occurence;
        }

        /*  IndicePremAppList   :   proc    :   affiche l'indice de premiere apparition dans une liste d'une valeur ou -1 si elle n'est pas presente
         *  PARAMETRES :
         *      Xval    :   int :   valeur dont on cherche l'indice de premiere apparition
         *      Xlist   :   List<int>   :   liste d'entiers non vide
         *  LOCAL :
         *      indice  :   int :   contient l'indice de première apparition de Xval
         */
        public static void IndicePremAppList(int Xval, List<int> Xlist)
        {
            int indice = -1;
            for (int i = 0; i < Xlist.Count && indice == -1; i++)
            {
                if (Xlist[i] == Xval)
                {
                    indice = i;
                }
                else { } //Rien
            }

            Console.WriteLine(">> Première apparition à l'indice " + indice);
        }
    }
}
