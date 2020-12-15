using System;

namespace tableau
{
    class Program
    {
        static void Main()
        {
            int nVal;
            int nMin;
            int nMax;
            int[] tab;

            /*Console.WriteLine(">> Entrez le nombre de valeurs du tableau, les bornes min puis max :");
            nVal = int.Parse(Console.ReadLine());
            nMin = int.Parse(Console.ReadLine());
            nMax = int.Parse(Console.ReadLine());

            tab = Randomtab(nMin, nMax, nVal);

            Affichagetab(tab);
            Console.WriteLine();
            Console.WriteLine("Tri croissant ? (true or false)");
            Triabulletab(tab, bool.Parse(Console.ReadLine()));
            Affichagetab(tab);
            Console.WriteLine();
            Console.WriteLine("La moyenne est de : " + Moyennetab(tab));
            
            //-----------------------------------------------------------------------------------------

            Console.WriteLine(">> Entrez le nombre de valeurs du tableau, les bornes min puis max :");
            nVal = int.Parse(Console.ReadLine());
            nMin = int.Parse(Console.ReadLine());
            nMax = int.Parse(Console.ReadLine());

            tab = Randomtabincomplete(nMin, nMax, nVal);
            Affichagetab(tab);
            Console.WriteLine();

            Console.Write(">> Entrez un nombre à inserer : ");
            int x = int.Parse(Console.ReadLine());

            Triabulletabincomplete(tab, true, nVal);
            Affichagetab(tab);

            Console.WriteLine();

            Insertiontab(tab, nVal, x);
            Affichagetab(tab);
            */

            //-----------------------------------------------------------------------------------------------

            Console.WriteLine(">> Entrez le nombre de valeurs du tableau, les bornes min puis max :");
            nVal = int.Parse(Console.ReadLine());
            nMin = int.Parse(Console.ReadLine());
            nMax = int.Parse(Console.ReadLine());

            tab = Randomtab(nMin, nMax, nVal);
            Affichagetab(tab);

            Console.WriteLine();

            Triabulletab(tab, true);
            Affichagetab(tab);

            Console.WriteLine();

            int indice, longueur;
            MonotonieCroissante(tab, out indice, out longueur);

            Console.WriteLine("La monotonie la plus grande dans le tableau commence à l'indice : " + indice + " et a une longueur de " + longueur);

        }// =================================================================================================

        /* Affichagetab :   proc    :   affiche un tableau à une dimension
         * PARAMETRES :
         *      Xtab    :   int[]   :   tableau d'entiers
         */
        public static void Affichagetab(int[] Xtab)
        {
            Console.Write("  ");
            for (int i = 0; i < Xtab.Length; i++)
            {
                Console.Write(Xtab[i] + "  ");
            }
        }

        /* Randomtab    :   fonc    :   créé un tableau d'entiers à une dimension par des valeurs comprises dans un intervalle donné
         * PARAMETRES :
         *      Xmin    :   int     :   borne minimum de l'intervalle
         *      Xmax    :   int     :   borne maximum de l'intervalle
         *      XnVal   :   int     :   nombre de valeurs dans le tableau
         * LOCAL :
         *      rd  :   random  :   random compris entre les bornes Xmin - Xmax
         *      tab :   int[]   :   tableau d'entiers à une dimension
         * RETOUR :
         *      tab :   int[]
         */
        public static int[] Randomtab(int Xmin, int Xmax, int XnVal)
        {
            Random rd = new Random();
            int[] tab = new int[XnVal];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = rd.Next(Xmin, Xmax + 1);
            }
            return tab;
        }
        public static int[] Randomtabincomplete(int Xmin, int Xmax, int XnVal)
        {
            Random rd = new Random();
            int[] tab = new int[XnVal+5];
            for (int i = 0; i < tab.Length-5; i++)
            {
                tab[i] = rd.Next(Xmin, Xmax + 1);
            }
            return tab;
        }

        /* Moyennetab   :   fonc    :   double  :   calcule la moyenne des valeurs d'un tableau à une dimension
         * PARAMETRES :
         *      Xtab    :   int[]   :   tableau d'entiers à une dimension
         * LOCAL :
         *      moyenne :   double  :   moyenne des valeurs de Xtab
         * RETOUR :
         *      moyenne :   double
         */
        public static double Moyennetab(int[] Xtab)
        {
            double moyenne = 0;
            for (int i = 0; i < Xtab.Length; i++)
            {
                moyenne = moyenne + Xtab[i];
            }
            moyenne = moyenne / Xtab.Length;

            return moyenne;
        }

        /* Occurencestab    :   fonc    :   int :   compte le nombre d'occurences d'une valeur dans un tableau d'entier
         * PARAMETRES :
         *      Xtab    :   int[]   :   tableau d'entiers à une dimension
         *      Xval    :   int     :   valeur dont on compte le nombre d'occurences
         * LOCAL :
         *      occurences  :   int :   nombre d'occurences de Xval
         * RETOUR :
         *      occurences  :   int
         */
        public static int Occurencestab(int[] Xtab, int Xval)
        {
            int occurences = 0;
            for (int i = 0; i < Xtab.Length; i++)
            {
                if (Xtab[i] == Xval)
                {
                    occurences = occurences++;
                }
                else { /* Rien */}
            }
            return occurences;
        }

        /* IndicePremApparitionTab  :   proc    :   affiche l'indice de la première apparition de Xval
         * PARAMETRES :
         *      Xtab    :   int[]   :   tableau d'entiers à une dimension
         *      Xval    :   int     :   valeur dont on cherche la première apparition
         * LOCAL :
         *      indice  :   int :   contient l'indice i de la première apparition de Xval, si Xval n'est pas dans le tableau, vaut -1
         */
        public static void IndicePremApparitionTab(int[] Xtab, int Xval)
        {
            int indice = -1;
            for (int i = 0; i < Xtab.Length; i++)
            {
                if (indice == -1) // alors Xval n'est pas encore apparue
                {
                    if (Xtab[i] == Xval)
                    {
                        indice = i;
                    }
                }
            }//fin du for

            Console.WriteLine(indice);
        }

        /* Triabulletab :   proc    : tri un tableau à une dimension par la méthode du tri a bulle
         * PARAMETRES :
         *      Xtab        :   int[]   : tableau d'entiers à une dimension
         *      Xcroissant  :   bool    : true si on veut trier dans l'ordre croissant, false dans l'ordre décroissant
         * LOCAL :
         *      temp    :   int     :   variable pour stocker de manière temporaire une valeur du tableau
         */
        public static void Triabulletab(int[] Xtab, bool Xcroissant)
        {
            int temp;
            for (int y = Xtab.Length - 1; y > 0; y--)
            {
                if (Xcroissant == true)
                {
                    for (int i = 0; i < Xtab.Length - 1; i++)
                    {
                        if (Xtab[i] > Xtab[i + 1])
                        {
                            temp = Xtab[i];
                            Xtab[i] = Xtab[i + 1];
                            Xtab[i + 1] = temp;
                        }
                        else { /* Rien */ }
                    }
                }
                else
                {
                    for (int i = 0 ; i < Xtab.Length - 1; i++)
                    {
                        if (Xtab[i] < Xtab[i + 1])
                        {
                            temp = Xtab[i];
                            Xtab[i] = Xtab[i + 1];
                            Xtab[i + 1] = temp;
                        }
                        else { /* Rien */ }
                    }
                }
            }// fin du for y
        }

        public static void Triabulletabincomplete(int[] Xtab, bool Xcroissant, int XnVal)
        {
            int temp;
            int changement;
            changement = 1;

            while(changement!=0)// plusieurs tours
            {
                changement = 0;
                if (Xcroissant == true)// croissant
                {
                    for (int i = 0; i < XnVal - 1; i++)
                    {
                        if (Xtab[i] > Xtab[i + 1])
                        {
                            temp = Xtab[i];
                            Xtab[i] = Xtab[i + 1];
                            Xtab[i + 1] = temp;
                            changement++;
                        }
                        else { /* Rien */ }
                    }
                }
                else // decroissant
                {
                    for (int i = 0; i < XnVal - 1; i++)
                    {
                        if (Xtab[i] < Xtab[i + 1])
                        {
                            temp = Xtab[i];
                            Xtab[i] = Xtab[i + 1];
                            Xtab[i + 1] = temp;
                            changement++;
                        }
                        else { /* Rien */ }
                    }
                }
            }// fin du for y
        }

        /* Rangvalsup   :   fonc  :   int :   retourne l'indice où : Xtab[i-1] < Xx < Xtab[i]
         * PARAMETRES :
         *      Xtab    :   int[]   : tableau d'entiers à une dimension
         *      XnVal   :   int     : nombre de valeurs entrées dans le tableau
         *      Xx      :   int     :   valeurs dont on cherche l'emplacement idéal (ordre croissant)
         * LOCAL :
         *      indice  :   int :   position idéale de Xx dans Xtab dans l'ordre croissant
         * RETOUR :
         *      indice  :   int
         */
        public static int Rangvalsup(int[] Xtab, int XnVal, int Xx)
        {
            int indice = -1;
            for (int i = 0; i < XnVal; i++)
            {
                if (Xtab[i] < Xx)
                {
                    indice = i+1;
                }
                else { /* Rien */ }
            }

            if (indice == -1)
            {
                indice = 0;
            }
            else { /* Rien */ }

            return indice;
        }

        /* Inserttab :  proc    :   insert une valeur Xx au bon endroit dans un tableau incomplet de XnVal valeurs
         * PARAMETRES :
         *  Xtab :      int[]   :   tableau
         *  XnVal :     int     :   nombre de valeurs présentes dans le tableau
         *  Xx  :       int     :   nombre à inserer dans Xtab
         * LOCAL :
         *  indice  :   int :   position où il faut placer Xx dans Xtab
         */
        public static void Insertiontab(int[] Xtab, int XnVal, int Xx)
        {
            int indice = Rangvalsup(Xtab, XnVal, Xx);

            for (int i = XnVal; i >= indice; i--)
            {
                Xtab[i] = Xtab[i - 1];
            }
            Xtab[indice] = Xx;
        }

        /* Dichotomique :   fonc    :   int :   recherche dichotomique d'une valeur dans un tableau, renvoi la position
         * PARAMETRES :
         *  Xtab    :   int[]   :   tableau
         *  Xinf    :   int     :   indice plancher de la recherche
         *  Xsup    :   int     :   indice plafond de la recherche
         *  Xval    :   int     :   valeur que l'on recherche
         * LOCAL :
         *  i   :       int     :   indice courant
         *  res :       int     :   valeur de l'indice de position de Xval (-1 si Xval absent)
         * RETOUR :
         *  res :       int     :       "
         */
        public static int Dichotomique(int[] Xtab, int Xinf, int Xsup, int Xval)
        {
            int i;
            int res = -1;
            while(Xinf <= Xsup && res == -1)
            {
                i = (Xinf + Xsup) / 2;
                Xinf = (Xval > Xtab[i]) ? i - 1 : Xinf;
                Xsup = (Xval < Xtab[i]) ? i + 1 : Xsup;
                res = (Xval == Xtab[i]) ? i : res;
            }
            return res;
        }

        /* MonotonieCroissante  :   proc    :   recherche la plus longue monotonie croissante dans un tableau et en retourne l'indice de départ et la longueur
         * PARAMETRES :
         *  Xtab        :   int[]   :   tableau
         *  Xindice     :   int out :   indice de départ de la monotonie
         *  Xlongueur   :   int out :   longueur de la monotonie
         * LOCAL :
         *  i               :   int :   indice courant
         *  depart          :   int :   indice de depart courant de la monotonie
         *  depart_max      :   int :   indice de depart de la plus longue monotonie
         *  longueur        :   int :   longueur courante de la monotonie
         *  longueur_max    :   int :   longueur de la monotonie la plus longue
         */
        public static void MonotonieCroissante(int[] Xtab, out int Xindice, out int Xlongueur)
        {
            int i;
            int depart = -1;
            int depart_max = -1;
            int longueur = 0;
            int longueur_max = 0;

            for(i=0; i<Xtab.Length - 1; i++)
            {
                if (Xtab[i] <= Xtab[i + 1])
                {
                    longueur++;

                    if (depart == -1)
                    {
                        depart = i;
                    }
                    else { /* rien */ }

                    if (longueur > longueur_max)
                    {
                        longueur_max = longueur;
                        depart_max = depart;
                    }
                    else { /* rien */ }
                }
                else
                {
                    longueur = 0;
                    depart = -1;
                }
            }

            if (longueur_max == 0)
            {
                Xindice = 0;
                Xlongueur = 0;
            }
            else
            {
                Xlongueur = longueur_max + 1;
                Xindice = depart_max;
            }
        }

    }
}
