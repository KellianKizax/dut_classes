// Cesar_GOFFICK_G2.cs : Programme de cryptage/décryptage de messages chiffrés par décalage, code César.

//  L.80     Affichage_menu()
//  L.100    Menu_cryptage()
//  L.129    Menu_decryptagebrute()
//  L.149    Menu_decryptagefreq()
//  L.166    Menu_quitter()
//  L.178    Menu_erreur()
//  L.201    Cryptage_chaine(string, int)
//  L.267    Decryptage_chaine(string, int)
//  L.312    Decryptage_analysefrequentielle(string)
//  L.382    Decryptage_brute(string)
//  L.443    Nb_occurences(string, char)
//  L.482    Lettres_maximum_nb_occurences(string)

// Kellian GOFFIC g2

using System;

namespace Cesar
{
    class Mainprog
    {
        static void Main()
        {
            // Déclaration des variables
            // choix_menu : string : 1-2-3-4-autre
            string choix_menu;

            // Initialisation des variables
            choix_menu = "0";

            // Affichage du menu
            Console.WriteLine("||>> Bienvenu dans le programme César !");
            Console.WriteLine("|| 'Je préfère être le premier homme ici que le second dans Rome.' -Jules César");
            Console.WriteLine("||");

            while (choix_menu != "4")
            {
                Affichage_menu();

                // Choix de l'action par l'utilisateur
                choix_menu = Console.ReadLine();
                
                if (choix_menu == "1") // Cryptage
                {
                    // Appel de la procédure
                    Menu_cryptage();
                }

                else if (choix_menu == "2") // Decryptage brute
                {
                    // Appel de la procédure
                    Menu_decryptagebrute();
                }

                else if (choix_menu == "3") // Decryptage Analyse Frequentielle
                {
                    // Appel de la procédure
                    Menu_decryptagefreq();
                }

                else if (choix_menu == "4") // Quitter
                {
                    // Appel de la procédure
                    Menu_quitter();
                }

                else // Out of range
                {
                    // Appel de la procédure
                    Menu_erreur();
                }
            }
        }// Fin du Main


        // Affichage_menu : proc : affiche le menu
        public static void Affichage_menu()
        {
            Console.WriteLine("||==================== Code César ====================||");
            Console.WriteLine("|| Sélectionnez le numéro de l'action souhaitée.      ||");
            Console.WriteLine("||                                                    ||");
            Console.WriteLine("|| 1- Cryptage d'un message                           ||");
            Console.WriteLine("|| 2- Décryptage brute d'un message                   ||");
            Console.WriteLine("|| 3- Décryptage analyse fréquentielle                ||");
            Console.WriteLine("|| 4- Quitter                                         ||");
            Console.WriteLine("||                                                    ||");
            Console.WriteLine("||==================== Code César ====================||");
            Console.WriteLine("||");
            Console.Write("|| ");
        }
		
		
		// Menu_cryptage : proc : affiche le menu pour la section cryptage
        // Local :
        //          chaine_acrypter : string : chaine entrée par l'utilisateur à crypter
        //          decalage :           int : decalage entré parl'utilisateur
        public static void Menu_cryptage()
        {
            string chaine_acrypter;
            int decalage;

            Console.WriteLine("||>> Cryptage");
            Console.WriteLine("||");
            Console.Write("|| Chaine à crypter ? : ");
            chaine_acrypter = Console.ReadLine();

            Console.Write("|| Après un décalage de ? : ");
            decalage = int.Parse(Console.ReadLine());
            // Pour eviter un décalage trop important
            decalage = decalage % 26;
            if ( decalage < 0)
            {
                decalage = 26 + decalage;
            }
            else { /* Rien */ }
            
            Console.WriteLine("|| Chaine cryptée : " + Cryptage_chaine(chaine_acrypter, decalage));
            Console.WriteLine("||");
            Console.WriteLine("|| 'Pas de vin, pas de soldats.' -Jules César");
            Console.WriteLine("||");

            // Reinitialisation entrées utilisateur
            chaine_acrypter = "";
            decalage = 0;
        }// fin proc


        // Menu_decryptagebrute : proc : affiche le menu pour la section decryptage brute
        // Local :
        //          chaine_adecrypter : string : chaine entrée par l'utilisateur à decrypter
        public static void Menu_decryptagebrute()
        {
            string chaine_adecrypter;

            Console.WriteLine("||>> Decryptage brute");
            Console.WriteLine("||");
            Console.Write("|| Chaine à decrypter ? : ");
            chaine_adecrypter = Console.ReadLine();
            // Appel de la procédure
            Decryptage_brute(chaine_adecrypter);

            Console.WriteLine("||");
            // Reinitialisation entrées utilisateur
            chaine_adecrypter = "";
        }//fin proc


        // Menu_decryptagefreq : proc : affiche le menu pour la section decryptage frequentielle
        // Local :
        //          chaine_acrypter : string : chaine entrée par l'utilisateur à decrypter
        public static void Menu_decryptagefreq()
        {
            string chaine_adecrypter;

            Console.WriteLine("||>> Decryptage analyse frequentielle");
            Console.WriteLine("||");
            Console.Write("|| Chaine à decrypter ? : ");
            chaine_adecrypter = Console.ReadLine();
            // Appel de la procédure
            Decryptage_analysefrequentielle(chaine_adecrypter);

            // Reinitialisation entrée utilisateur
            chaine_adecrypter = "";
        }// fin proc


        // Menu_quitter : proc : affiche un message de fin
        public static void Menu_quitter()
        {
            Console.WriteLine("||>> Exit");
            Console.WriteLine("|| Comme dit Jules :");
            Console.WriteLine("|| 'De tous les peuples gaulois, les Belges sont les plus braves.' -Jules César");
            Console.WriteLine("||");
            Console.WriteLine("||");
        }// fin proc
        


        // Menu_erreur : proc : affiche un message d'erreur
        public static void Menu_erreur()
        {
            Console.WriteLine("||>> Erreur");
            Console.WriteLine("|| Votre choix me semble peu valide...");
            Console.WriteLine("|| 'Recommencer, ce n'est pas refaire.' -Jules César");
            Console.WriteLine("||");
        }// fin proc


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
                        chaine_traitee = chaine_traitee + ((Xchaine[i].ToString()).ToLower());
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
        }// fin fonc


        // decryptage_chaine : fonc : string : decrypte la chaine en fonction du décalage donné
        // Paramètres : 
        //              Xchaine : string : chaine de charactères a décrypter
        //              Xdecalage :  int : numéro correspondant au décalage effectué dans 'alphabet'
        // Local :  
        //              longueur_chaine : int : longueur de 'chaine'
        //              alphabet : string : contient 2x l'alphabet (pour le décalage)
        //              chaine_decryptee : string : contient la chaine decryptée
        // Retour : 
        //              chaine_decryptee : string
        public static string Decryptage_chaine(string Xchaine, int Xdecalage)
        {
            // Declaration des variables
            int longueur_chaine;
            string alphabet;
            string chaine_decryptee;

            // Initialisation des variables
            alphabet = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
            longueur_chaine = (Xchaine.Length) - 1;
            chaine_decryptee = "";

            // Boucle pour tester tous les charactères de 'chaine'
            for (int i = 0; i <= longueur_chaine; i++)
            {
                // Boucle pour tester tous les charactères de 'alphabet' pour un charactère de 'chaine'
                // 26<=y<=51 : 26 pour le second 'a' ; 51 le second et dernier 'z' : pour "alphabet[y - decalage]" par la suite (l.41)
                for (int y = 26; y <= 51; y++)
                {
                    if (Xchaine[i] == alphabet[y])
                    {
                        // On ajoute dans 'chaine_decryptee' (vide au départ) le charactères de x 'decalage' après le charactère selectionné 
                        chaine_decryptee = chaine_decryptee + alphabet[y - Xdecalage];
                    }
                    else { /* Rien */ }
                }
            }

            return chaine_decryptee;
        }// fin fonc


        // Decryptage_analysefrequentielle : proc : decrypte par analyse frequentielle une chaine donnée
        // Paramètres :
        //              Xchaine : string : chaine a decrypter
        // Local :
        //              lettres_ordreoccurences : string : lettres qui apparaissent le plus dans 'chaine' dans l'ordre décroissant
        //              alphabet : string : contient l'alphabet
        //              chaine_decryptee : string : chaine decryptee
        //              longueur_lettresordreoccurences : int : longueur de 'lettres_ordreoccurences'
        //              longueur_alphabet : int : longueur de 'alphabet'
        //              emplacement_lettremax : int : emplacement dans alphabet de la lettre qui apparait le plus
        //              decalage : int : decalage entre "e" et la lettre qui apparait le plus (emplacement de "e" : 4) (decalage = 'emplacement_lettremax' - 4)
        //              reponse : string : reponse de l'utilisateur si le texte est compréhensible
        //              succes : bool : true si 'chaine_decryptee' est compréhensible
        public static void Decryptage_analysefrequentielle(string Xchaine)
        {
            // Déclaration des variables
            string lettres_ordreoccurences;
            string alphabet;
            string chaine_decryptee;
            int longueur_lettresordreoccurences;
            int longueur_alphabet;
            int emplacement_lettremax;
            int decalage;
            string reponse;
            bool succes;

            //Initialisation des variables
            alphabet = "abcdefghijklmnopqrstuvwxyz";
            lettres_ordreoccurences = Lettres_maximum_nb_occurences(Xchaine);
            longueur_alphabet = alphabet.Length;
            longueur_lettresordreoccurences = lettres_ordreoccurences.Length;
            succes = false;

            int i = 0;
            while (i < longueur_lettresordreoccurences && succes == false)
            {

                int y = 0;
                while (y < longueur_alphabet && succes == false)
                {
                    if (lettres_ordreoccurences[i] == alphabet[y])
                    {
                        emplacement_lettremax = y;
                        // emplacement de e : 4
                        decalage = emplacement_lettremax - 4;

                        chaine_decryptee = Decryptage_chaine(Xchaine, decalage);

                        Console.WriteLine("||");
                        Console.WriteLine("|| Lettre apparaissant le plus souvent : " + lettres_ordreoccurences[i]);
                        Console.WriteLine("|| Chaine décryptée : " + chaine_decryptee);

                        Console.Write("|| Le texte est-il compréhensible ? ('o'/'n') : ");
                        reponse = Console.ReadLine().ToLower();

                        if (reponse == "o")
                        {
                            succes = true;
                        }
                        else { /* Rien */ }
                    }
                    else { /* Rien */ }

                    y++;
                }// fin while y

                i++;
            }//fin while i
            Console.WriteLine("||");
            Console.WriteLine("||");
            Console.WriteLine("|| 'Veni, vidi, vici.' -Jules César");
            Console.WriteLine("||");
        }// fin proc


        // decryptage_brute : proc : teste les différents décalages possibles [0-26] et demande si la chaine décryptée est compréhensible
        // Paramètres : 
        //              Xchaine : string : chaine à décrypter
        // Local :      
        //              chaine_decryptee :  string : 'chaine' decryptée
        //              oui_non :           string : contient oui ou non entré par l'utilisateur
        //              decalage :             int : variable contenant les differents décalages testés dans la boucle
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
                chaine_decryptee = Decryptage_chaine(Xchaine, decalage);

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

        }// fin proc


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
        }// fin fonc


        // Lettres_maximum_nb_occurences : fonc : Calcul et Retourne une liste de charactères 'lettres_max' dans l'ordre décroissant, qui apparaissent le plus dans 'chaine'
        // Paramètres :
        //          Xchaine : string : chaine de charactères a partir de laquelle on renvoit les lettres qui apparaissent le plus dedans
        // Local :  
        //          lettres_max :                string : contient les lettres qui apparaissent le plus de fois dans 'chaine' dans l'ordre décroissant
        //          chaine_sanslettresmax :      string : 'chaine' à laquelle on retire les lettres déjà testés
        //          lettre_maxoccurences :       string : contient la lettre avec le nombre d'occurences égal à 'occurences_max'
        //          longueur_chainesanslettresmax : int : longueur de 'chaine_sanslettresmax'
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
                    occurences = Nb_occurences(chaine_sanslettresmax, chaine_sanslettresmax[i]);

                    if (occurences > occurences_max)
                    {
                        occurences_max = occurences;
                        lettre_maxoccurences = (chaine_sanslettresmax[i]).ToString();
                    }
                    else { /* Rien */ }
                }

                lettres_max = lettres_max + lettre_maxoccurences;
                
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
        }// fin fonc
    }
}