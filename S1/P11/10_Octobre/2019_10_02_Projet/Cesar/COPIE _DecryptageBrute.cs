// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// DecryptageBrute.cs : fichier de la procédure 'Decryptage_brute()'
// Kellian GOFFIC

using System;

class DecryptageBrute_Copie
{
    // decryptage_brute : proc : teste les différents décalages possibles [0-26] et demande si la chaine décryptée est compréhensible
    // Paramètres : 
    //              Xchaine : string : chaine à décrypter
    // Local :      
    //              chaine_decryptee :  string : 'chaine' decryptée
    //              oui_non :           string : contient oui ou non entré par l'utilisateur
    //              test :                 int : condition de la boucle d'entrée controlée
    //              decalage_trouve       bool : condition de la boucle de décryptage
    public static void Decryptage_brute(string Xchaine)
    {
        // Déclaration des variables
        string chaine_decryptee;
        string oui_non;
        int decalage;
        int test;
        bool decalage_trouve;

        // Initialisation des variables
        decalage_trouve = false;
        decalage = 1;
        Console.WriteLine("|| Chaine cryptée : " + Xchaine);

        // Boucle qui teste un décalage different a chaque "tour" jusqu'a ce que tous les décalages soient testés ou le décalage trouvé
        while (decalage <= 26 && decalage_trouve == false)
        {
            chaine_decryptee = LibrairieCesar.Decryptage.Decryptage_chaine(Xchaine, decalage);

            Console.WriteLine("|| Décalage de " + decalage);
            Console.WriteLine("|| Chaine décryptée : " + chaine_decryptee);
            Console.Write("|| Le texte est-il compréhensible ? (oui/non) : ");

            oui_non = Console.ReadLine();

            test = 0;
            while (test != 1)
            {
                if (oui_non == "oui")
                {
                    decalage_trouve = true;
                    test = 1;
                }
                else if (oui_non == "non")
                {
                    test = 1;
                }
                else
                {
                    Console.WriteLine("|| Réponse non valide");
                    Console.Write("|| Le texte est-il compréhensible ? ");
                    oui_non = Console.ReadLine();
                    test = 0;
                }
            }
            decalage++;

        }
        
    }
}