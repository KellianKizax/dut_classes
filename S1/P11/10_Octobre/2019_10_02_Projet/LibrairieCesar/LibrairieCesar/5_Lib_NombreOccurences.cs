// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// 5_Lib_NombreOccurences.cs : fichier de la fonction 'Nb_occurences()'
// Kellian GOFFIC

using System;

namespace LibrairieCesar
{
    public class NombreOccurences
    {
        // Nb_occurences : fonc : calcul le nombre d'occurences d'un caractère dans la chaine
        // Paramètres : 
        //              chaine : string : chaine de caractères
        //              c : char : caractère dont-il faut compter le nombre d'occurences dans 'chaine'
        // Local :
        //          occurences : int : nombre d'occurences de 'c'
        //          longueur_chaine : int : longueur de 'chaine'
        // Retour :
        //          occurences : int : nombre d'occurences de 'c'
        public static int Nb_occurences(string Xchaine, char Xc)
        {
            // Déclaration des variables
            int occurences;
            int longueur_chaine;

            // Initialisation des variables
            longueur_chaine = (Xchaine.Length) - 1;
            occurences = 0;

            // Boucle pour tester chaque lettre de 'chaine'
            for (int i = 0; i <= longueur_chaine; i++)
            {
                // si la lettre = 'c', alors occurences +1
                if (Xchaine[i] == Xc)
                {
                    occurences = occurences + 1;
                }
                else { /* Rien */ }
            }

            return occurences;
        }
    }
}
