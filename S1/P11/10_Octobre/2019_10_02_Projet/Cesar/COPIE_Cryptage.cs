// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// Cryptage.cs : fichier de la fonction 'Cryptage_chaine()'
// Kellian GOFFIC

using System;

class Cryptage_Copie
{
    // cryptage_chaine : fonc : string : garde les charactères alphabétiques d'une chaine et la crypte en fonction d'un décalage
    // Paramètres : 
    //              Xchaine :   string : chaine de charactères a crypter
    //              Xdecalage :    int : numéro correspondant au décalage effectué dans 'alphabet'
    // Local :  
    //              alphabet :             string : [a-z] + [a-z] (pour le décalage)
    //              alphabet_double :      string : [a-z] + [A-Z] (pour accepter minuscules et majuscules)
    //              chaine_traite :        string : 'chaine' de départ constituées uniquement de charactères alphabétiques en minuscules
    //              chaine_cryptee :       string : 'chaine_traite' à laquelle on applique un décalage sur chacun de ses charactères
    //              longueur_chaine :         int : longueur -1 de 'chaine' (pour les boucles)
    //              longueur_alphabetdouble : int : longueur -1 de 'alphabet' (pour les boucles)
    //              longueur_chainetraite :   int : longueur -1 de 'chaine_traite' (pour les boucles)
    // Retour : 
    //              chaine_cryptee : string
    public static string Cryptage_chaine(string Xchaine, int Xdecalage)
    {
        // Declaration des variables
        string alphabet;
        string alphabet_double;
        string chaine_traitee;
        string chaine_cryptee;
        int longueur_chaine;
        int longueur_chainetraitee;
        int longueur_alphabetdouble;

        // Initialisation des variables
        alphabet = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
        alphabet_double = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        longueur_alphabetdouble = 51;
        longueur_chaine = (Xchaine.Length) - 1;
        chaine_traitee = "";
        chaine_cryptee = "";

        // Boucle pour tester tous les charactères de 'chaine'
        for (int i = 0; i <= longueur_chaine; i++)
        {
            // Boucle pour tester tous les charactères de 'alphabet' pour un charactère de 'chaine'
            for (int y = 0; y <= longueur_alphabetdouble; y++)
            {
                if (Xchaine[i] == alphabet_double[y])
                {
                    // On ajoute uniquement les charactères valides (présents dans 'alphabet') réduits en minuscules
                    chaine_traitee = chaine_traitee + ( (Xchaine[i].ToString()).ToLower() );
                }
                else { /* Rien */ }
            }
        }
        // On obtient notre chaine sans charactères interdits

        longueur_chainetraitee = (chaine_traitee.Length) - 1;

        // Boucle pour tester tous les charactères de 'chaine_traitee'
        for (int i = 0; i <= longueur_chainetraitee; i++)
        {
            // Boucle pour tester "tous" les charactères de 'alphabet' pour un charactère de 'chaine_traitee'
            for (int y = 0; y <= 25; y++)
            {
                if (chaine_traitee[i] == alphabet[y])
                {
                    // On ajoute dans 'chaine_cryptee' (vide au départ) le charactères de x 'decalage' après le charactère selectionné 
                    chaine_cryptee = chaine_cryptee + alphabet[y + Xdecalage];
                }
                else { /* Rien */ }
            }
        }

        return chaine_cryptee;
    }
}