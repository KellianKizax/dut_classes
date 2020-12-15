using System;
using System.Collections.Generic;

namespace K_GOFFIC_Library
{
    public static class Library
    {

        public static int IntExtraireChiffre(int Xnbr, int Xindice)
        {
            Xnbr = (int)(Xnbr / Math.Pow(10, Xindice)) % 10;
            return Xnbr;
        }

        //Factoriel : fonc : int : calcule le factoriel de Xn
        //Parametres :
        //      Xn : int : entier dont on veut calculer le factoriel
        //Local :
        //      factN : int : factoriel de Xn
        //Retour :
        //	    factN : int : factoriel de Xn
        public static int IntFactoriel(int Xn)
        {
            int factN;

            factN = 1;
            for (int i=2; i<=Xn; i++)
            {
                factN = factN * i;
            }
            return factN;
        }


        //EstPremier : fonc : bool : Teste si un nombre est un nombre premier
        //Parametres :
        //      Xnb : double : nombre à tester
        //Local :
        //      res : bool : contient le resultat
        //Retour :
        //	    res : bool : True / False
        public static bool IntEstPremier(int Xnb)
        {
            bool res;

            if (Xnb < 0)
            {
                res = false;
            }
            else if (Xnb <= 3)
            {
                res = true;
            }
            else
            {
                int sqrt_int = (int)Math.Sqrt(Xnb);

                for (int i = 2; i <= sqrt_int; i++)
                {
                    if (Xnb % i == 0)
                    {
                        res = false;
                    }
                }

                res = true;
            }
            return res;
        }

        //=====================================================================================================================

        //StringPlusLongue : fonc : string : retourne la chaine la plus longue, si identiques, retourne la premiere ordre alphabetique
        //Parametres :
        //      Xchaine1 : string : première chaine
        //      Xchaine2 : string : deuxième chaine
        //Local :
        //      long1 : int     : longueur de la chaine 1
        //      long2 : int     : longueur de la chaine 2
        //      res :   string  : stock la chaine la plus longue
        //Retour :
        //	    res :   string  : chaine la plus longue entre chaine 1 et 2
        public static string StringPlusLongue(string Xchaine1, string Xchaine2)
        {
            // Declaration des variables
            int long1;
            int long2;
            string res;

            // Initialisation des variables de longueur
            long1 = Xchaine1.Length;
            long2 = Xchaine2.Length;

            // Test des différences de longueur
            if (long1 < long2)
            {
                res = Xchaine2;
            }
            else if (long1 > long2)
            {
                res = Xchaine1;
            }
            else
            {
                // Test de l'ordre alphabétique si les deux chaines sont de meme longueur
                if (Xchaine1.CompareTo(Xchaine2) > 0)
                {
                    // Xchaine2 en premiere dans l'odre alphabétique
                    res = Xchaine2;
                }
                else if (Xchaine1.CompareTo(Xchaine2) < 0)
                {
                    // Xchaine1 en premiere dans l'odre alphabétique
                    res = Xchaine1;
                }
                else
                {
                    // Xchaine1 et Xchaine2 sont identiques
                    res = Xchaine1;
                }
            }

            return res;
        }


        //StringPlusCourte : fonc : string : retourne la chaine la plus courte, si identiques, retourne la premiere ordre alphabetique
        //Parametres :
        //      Xchaine1 : string : première chaine
        //      Xchaine2 : string : deuxième chaine
        //Local :
        //      long1 : int     : longueur de la chaine 1
        //      long2 : int     : longueur de la chaine 2
        //      res :   string  : stock la chaine la plus courte
        //Retour :
        //	    res :   string  : chaine la plus courte entre chaine 1 et 2
        public static string StringPlusCourte(string Xchaine1, string Xchaine2)
        {
            // Declaration des variables
            int long1;
            int long2;
            string res;

            // Initialisation des variables de longueur
            long1 = Xchaine1.Length;
            long2 = Xchaine2.Length;

            // Test des différences de longueur
            if (long1 < long2)
            {
                res = Xchaine1;
            }
            else if (long1 > long2)
            {
                res = Xchaine2;
            }
            else
            {
                // Test de l'ordre alphabétique si les deux chaines sont de meme longueur
                if (Xchaine1.CompareTo(Xchaine2) > 0)
                {
                    // Xchaine2 en premiere dans l'odre alphabétique
                    res = Xchaine2;
                }
                else if (Xchaine1.CompareTo(Xchaine2) < 0)
                {
                    // Xchaine1 en premiere dans l'odre alphabétique
                    res = Xchaine1;
                }
                else
                {
                    // Xchaine1 et Xchaine2 sont identiques
                    res = Xchaine1;
                }
            }

            return res;
        }

        //StringAlphabetique : fonc : string : retourne la premiere chaine dans l'ordre alphabetique
        //Parametres :
        //      Xchaine1 :  string : première chaine
        //      Xchaine2 :  string : deuxième chaine
        //Local :
        //      res : string : stock la premiere chaine dans l'odre alphabetique
        //Retour :
        //	    res : string : "
        public static string StringAlphabetique(string Xchaine1, string Xchaine2)
        {
            // Declaration des variables
            string res;

            // test de l'ordre alphabetique
            if (Xchaine1.CompareTo(Xchaine2) > 0)
            {
                res = Xchaine2;
            }
            else if (Xchaine1.CompareTo(Xchaine2) < 0)
            {
                res = Xchaine1;
            }
            else
            {
                // les chaines sont identiques
                res = Xchaine1;
            }

            return res;
        }


        //StringAlphabetiqueInverse : fonc : string : retourne la derniere chaine dans l'ordre alphabetique
        //Parametres :
        //      Xchaine1 : string : première chaine
        //      Xchaine2 : string : deuxième chaine
        //Local :
        //      res : string : stock la derniere chaine dans l'odre alphabetique
        //Retour :
        //	    res : string : "
        public static string StringAlphabetiqueInverse(string Xchaine1, string Xchaine2)
        {
            // Declaration des variables
            string res;

            // test de l'ordre alphabetique
            if (Xchaine1.CompareTo(Xchaine2) > 0)
            {
                res = Xchaine1;
            }
            else if (Xchaine1.CompareTo(Xchaine2) < 0)
            {
                res = Xchaine2;
            }
            else
            {
                // les chaines sont identiques
                res = Xchaine1;
            }

            return res;
        }


        //StringNbOccurence : fonc : int : retourne le nombre d'occurences d'un caractere dans une chaine
        //Parametres :
        //      Xchaine :   string  : chaine de caracteres
        //      Xchar :     char    : caractere que l'on compte
        //Local :
        //      longueur : int : longueur de la chaine
        //      nbOcc : int : compte le nombre d'occurences
        //Retour :
        //	    nbOcc : int : "
        public static int StringNbOccurence(string Xchaine, char Xchar)
        {
            // Declaration des varaibles
            int nbOcc;
            int longueur;

            // Initialisation des variables
            nbOcc = 0;
            longueur = Xchaine.Length;

            // Test de l'egalite entre un caractere de la chaine et le caractere Xchar
            for (int i = 0; i < longueur; i++)
            {
                if (Xchar == Xchaine[i])
                {
                    nbOcc = nbOcc + 1;
                }
                else
                {
                    // Rien
                }
            }

            return nbOcc;
        }


        //StringSupprChar : fonc : string : retourne une chaine dont on a retirer toutes les occurences d'un caractere
        //Parametres :
        //      Xchaine :   string  : chaine de caractere
        //      Xchar :     char    : caractere a supprimer
        //Local :
        //      longueur :          int : longueur de la chaine Xchaine
        //      chaineResultat : string : contient la chaine de caractere finale
        //Retour :
        //      chaineResultat : string : "
        public static string StringSupprChar(string Xchaine, char Xchar)
        {
            // Declaration des variables
            int longueur;
            string chaineResultat;

            // Initialisation des variables
            longueur = Xchaine.Length;
            chaineResultat = "";

            // Boucle afin de chercher et extraire les caracteres differents de Xchar et les ajouter a chaineResultat
            for (int i = 0; i < longueur; i++)
            {
                if (Xchar == Xchaine[i])
                {
                    // Rien
                }
                else
                {
                    chaineResultat = chaineResultat + Xchaine[i];
                }
            }

            return chaineResultat;
        }

        //=====================================================================================================================

        /*  ListCreaRnd   :   proc    :   complete le contenu d'une liste d'entiers aleatoirement
         *  PARAMETRES :
         *      Xnb     :   int         :   nombre de valeurs
         *      Xmin    :   int         :   valeur minimum
         *      Xmax    :   int         :   valeur maximum
         *  LOCAL :
         *      rnd     :   random      :   Random
         */
        public static List<int> ListCreaRnd(int Xnb, int Xmin, int Xmax)
        {
            List<int> list = new List<int>(Xnb - 1);
            Random rnd = new Random();
            for (int i = 0; i < Xnb; i++)
            {
                list.Add(rnd.Next(Xmin, Xmax + 1));
            }
            return list;
        }

        // Tri par distribution à partir de bases
        public static List<int> ListTriDistribution(List<int> Xlist)
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
                    int indice = IntExtraireChiffre(item, i);
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

        public static int ListMax(List<int> Xlist)
        {
            int max = Xlist[0];
            foreach (int item in Xlist)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }





    }
}