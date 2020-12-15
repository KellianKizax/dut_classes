// César : Programme de cryptage/décryptage de messages chiffrés par décalage, le code César.
// 2_Lib_Decryptage.cs : fichier de la fonction Decryptage_chaine()'
// Kellian GOFFIC

using System;

namespace LibrairieCesar
{
    public class Decryptage
    {
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
        }


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
        //              reponse : char : reponse de l'utilisateur si le texte est compréhensible
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
            char reponse;
            bool succes;

            //Initialisation des variables
            alphabet = "abcdefghijklmnopqrstuvwxyz"; 
            lettres_ordreoccurences = LibrairieCesar.LettresMaxNbOccurences.Lettres_maximum_nb_occurences(Xchaine);
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
                        reponse = char.ToLower(char.Parse(Console.ReadLine()));

                        if (reponse == 'o')
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
        }//fin proc
    }
}
