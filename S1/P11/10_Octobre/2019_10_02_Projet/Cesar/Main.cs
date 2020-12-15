// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// Main.cs : fichier principal du programme
// Librairie :
//      Cryptage.cs : fichier de la fonction 'Cryptage_chaine()'
//      Decryptage.cs : fichier de la fonction Decryptage_chaine()' et de la procedure 'Decryptage_analysefrequentielle()'
//      DecryptageBrute.cs : fichier de la procédure 'Decryptage_brute()'
//      NombreOccurences.cs : fichier de la fonction 'Nb_occurences()'
//      LettresMaxNbOccurences.cs : fichier de la fonction 'Lettres_maimum_nb_occurences()'
// Kellian GOFFIC

using System;
using LibrairieCesar;

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
            decalage = decalage % 25;
            
            Console.WriteLine("|| Chaine cryptée : " + LibrairieCesar.Cryptage.Cryptage_chaine(chaine_acrypter, decalage));
            Console.WriteLine("||");
            Console.WriteLine("|| 'Pas de vin, pas de soldats.' -Jules César");
            Console.WriteLine("||");

            // Reinitialisation entrées utilisateur
            chaine_acrypter = "";
            decalage = 0;
        }


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
            LibrairieCesar.DecryptageBrute.Decryptage_brute(chaine_adecrypter);

            Console.WriteLine("||");
            // Reinitialisation entrées utilisateur
            chaine_adecrypter = "";
        }


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
            LibrairieCesar.Decryptage.Decryptage_analysefrequentielle(chaine_adecrypter);

            // Reinitialisation entrée utilisateur
            chaine_adecrypter = "";
        }


        // Menu_quitter : proc : affiche un message de fin
        public static void Menu_quitter()
        {
            Console.WriteLine("||>> Exit");
            Console.WriteLine("|| Comme dit Jules :");
            Console.WriteLine("|| 'De tous les peuples gaulois, les Belges sont les plus braves.' -Jules César");
            Console.WriteLine("||");
            Console.WriteLine("||");
        }
        


        // Menu_erreur : proc : affiche un message d'erreur
        public static void Menu_erreur()
        {
            Console.WriteLine("||>> Erreur");
            Console.WriteLine("|| Votre choix me semble peu valide...");
            Console.WriteLine("|| 'Recommencer, ce n'est pas refaire.' -Jules César");
            Console.WriteLine("||");
        }
    }
}
