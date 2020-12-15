// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// LettresMaxNbOccurences.cs : fichier de la fonction 'Lettres_maimum_nb_occurences()'
// Kellian GOFFIC

using System;

class LettresMaxNbOccurences_Copie
{
    // Lettres_maximum_nb_occurences : fonc : Calcul et Retourne une liste de charactères 'lettres_max' dans l'ordre décroissant, qui apparaissent le plus dans 'chaine'
    // Paramètres :
    //          Xchaine : string : chaine de charactères a partir de laquelle on renvoit les lettres qui apparaissent le plus dedans
    // Local :  
    //          lettres_max :                string : contient les lettres qui apparaissent le plus de fois dans 'chaine' dans l'ordre décroissant
    //          chaine_sanslettresmax :      string : 'chaine' à laquelle on retire les lettres déjà testés
    //          lettre_maxoccurences :       string : contient la lettre avec le nombre d'occurences égal à 'occurences_max'
    //          longueur_chainesanslettresmax : int : longueur de 'chaine_sanslettresmax'
    //          longueur_lettresmax :           int : longueur de 'lettres_max'
    //          longueur_chaine :               int : longueur de 'chaine'
    //          occurences :                    int : nombre d'occurences d'une lettre dans 'chaine_sanslettresmax'
    //          occurences_max :                int : le nombre d'occurences d'une lettre ('lettre_maxoccurences') dans 'chaine_sanslettresmax'
    // Retour : 
    //          lettres_max : string : contient les lettres qui apparaissent le plus de fois dans 'chaine' dans l'ordre décroissant
    public static string Lettres_maximum_nb_occurences(string Xchaine)
    {
        // Déclaration des variables
        string lettres_max;
        string chaine_sanslettresmax;
        string lettre_maxoccurences;
        int longueur_chainesanslettresmax;
        int longueur_lettresmax;
        int longueur_chaine;
        int occurences;
        int occurences_max;
        
        // Initialisation des variables
        occurences_max = 0;
        lettres_max = "";
        lettre_maxoccurences = "";
        chaine_sanslettresmax = Xchaine;
        
        longueur_chaine = (Xchaine.Length) - 1;

        // Tant qu'il reste des charactères dans 'chaine_sanslettresmax'
        while (chaine_sanslettresmax != "")
        {
            // Reinitilisation des variables
            occurences_max = 0;
            lettre_maxoccurences = "";
            longueur_chainesanslettresmax = (chaine_sanslettresmax.Length) - 1;

            // On cherche la lettre qui apparait le plus dans 'chaine_sanslettresmax'
            for (int i = 0; i <= longueur_chainesanslettresmax; i++)
            {
                occurences = LibrairieCesar.NombreOccurences.Nb_occurences(chaine_sanslettresmax, chaine_sanslettresmax[i]);

                if (occurences > occurences_max)
                {
                    occurences_max = occurences;
                    lettre_maxoccurences = (chaine_sanslettresmax[i]).ToString();
                }
                else { /* Rien */ }
            }

            lettres_max = lettres_max + lettre_maxoccurences;
            longueur_lettresmax = (lettres_max.Length) - 1;

            chaine_sanslettresmax = ""; // Afin de la reinitialiser à chaque tour

            // Pour tous les charactères contenus dans 'lettres_max', on les retire de 'chaine', et on ajoute le reste dans chaine_sanslettresmax
            for (int i = 0; i <= longueur_chaine; i++)
            {
                if (lettres_max.Contains(Xchaine[i]) == false)
                {
                    chaine_sanslettresmax = chaine_sanslettresmax + Xchaine[i];
                }
                else { /* Rien */ }
            }
        }

        return lettres_max;
    }
}