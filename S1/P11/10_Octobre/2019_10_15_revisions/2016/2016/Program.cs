using System;

namespace _2016
{
    class Program
    {
        static void Main()
        {
            int nombre;
            Console.Write("Entrez un nombre de termes de la suite de Conway à afficher : ");
            nombre = int.Parse(Console.ReadLine());
            generer(nombre);
        }

        // toChar : fonc : retourne en char un entier [0-9]
        // Paramètres :
        //      pDigit :    int     : entier entre [0-9]
        // Retour :
        //      car :       char    : char de pDigit
        public static char toChar(int pDigit)
        {
            // Déclaration de la variable
            char car;

            // Initialisation de la variable
            car = ' ';

            if (pDigit >= 0 && pDigit <= 9)
            {
                car = char.Parse(pDigit.ToString());
            }
            else { /* Rien */ }
            return car;
        }

        // nbApparition : fonc : retourne le nombre d'apparitions d'affilées d'un char
        // Paramètres :
        //      pTerme :    string  : terme en cours de traitement
        //      pPos :      int     : position du charactère courant dans pTerme
        // Local :
        //      repeat :    int     : nombre d'apparitions d'affilées du char courant
        //      i :         int     : indice de la position du charactère courant dans pTerme
        public static int nbApparition(string pTerme, int pPos)
        {
            // Déclaration des variables
            int repeat;
            int i;

            // Initialisation dse variables
            repeat = 0;
            i = pPos;

            while (i < pTerme.Length && pTerme[pPos] == pTerme[i])
            {
                repeat++;
                i++;
            }
            return repeat;
        }

        // suivant : fonc : renvoit le terme suivant de la suite de Conway
        // Paramètres :
        //      pTerme : string : terme actuel de la suite de Conway
        // Local :
        //      i :                 int     : indice de la position du charactère courant dans pTerme
        //      nbapparition :      int     : nombre d'apparitions du charactère courant
        //      nbappchar :         char    : 'nbapparition' en char
        //      termesuivant :      string  : terme suivant de la suite de Conway
        // Retour :
        //      termesuivant :      string  : terme suivant de la suite de Conway
        public static string suivant(string pTerme)
        {
            // Déclaration des variables
            int i;
            int nbapparition;
            char nbappchar;
            string termesuivant;

            // Initialisation des variables
            i = 0;
            nbapparition = 0;
            termesuivant = "";

            while (i < pTerme.Length)
            {
                nbapparition = nbApparition(pTerme, i);
                nbappchar = toChar(nbapparition);
                termesuivant = termesuivant + nbappchar + pTerme[i];
                i = i + nbapparition;
            }
            return termesuivant;
        }

        // generer : proc : affiche les premiers termes de la suite de Conway
        // Paramètres :
        //      pNb : int : nombre des premiers termes de la suite de Conway à afficher
        // Local :
        //      terme : string : contient le terme suivant de la suite de Conway
        public static void generer(int pNb)
        {
            // Déclaration de la variable
            string terme;

            // Initialisation de la variable
            terme = "1";

            for (int i = 0; i <= pNb; i++)
            {
                Console.WriteLine(terme);
                terme = suivant(terme);
            }
        }
    }
}
