// impots_zorglub.cs : Verifie si l'habitant est imposable en fonction de l'age et du sexe
// Kellian GOFFIC

using System;

class impots_zorglub
{
    static void Main()
   {
       // Déclaration des variables :
       // age : int : age de l'utilisateur
       // sexe : string : sexe de l'utilisateur
       int age;
       string sexe;

       // Initialisation par l'utilisateur des variables
       Console.WriteLine("Etes vous un homme (H), une femme (F) ou autre (A) ?   (H/F/A)");
       sexe = Console.ReadLine();

       Console.WriteLine("Quel age avez vous ?");
       age = int.Parse(Console.ReadLine());

        // conditions pour l'homme
       if (sexe == "H")
      {
          if (age>20)
         {
             Console.WriteLine("Vous êtes un homme de plus de 20ans, vous êtes imposable.");
         }
          else
         {
             Console.WriteLine("Vous êtes un homme de moins de 20ans, vous n'êtes pas imposable.");
         }
      } 
      
        // conditions pour la femme
       else if (sexe == "F")
       { 
          if (age>=18 && age<35)
         {
             Console.WriteLine("Vous êtes une femme entre 18 et 35ans, vous êtes imposable.");
         }
          else
         {
             Console.WriteLine("Vous êtes une femme qui a moins de 18ans ou plus de 35ans, vous n'êtes pas imposable.");
         } 
       } 
      
        // Autre
       else
      {
          Console.WriteLine("Vous n'êtes ni une femme ni un homme, vous êtes non imposable.");
      }  
   } 
}