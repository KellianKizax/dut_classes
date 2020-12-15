// testage.cs : teste l'age si il est majeur ou non (0<age<130)
// Kellian GOFFIC

using System;

class testage
{
    static void Main()
   {
        //Déclaration de la variable :
        //age : int : age de l'utilisateur
        int age ;

        //initialisation de la variable par l'utilisateur
        Console.Write("Votre age=?");
        age = int.Parse(Console.ReadLine());

        //On vérifie 0<age<130
        if (age>0 && age<130)
        {
            //On vérifie que l'utilisateur est majeur
            if (age>=18)
            {
                Console.WriteLine("Vous êtes majeur !");
            } 
            //Sinon il est mineur
            else
            {
                Console.WriteLine("Vous n'êtes pas majeur...");
            } 
        } 
 
        //Si age n'est pas dans l'intervalle, alors il n'est pas valide
        else
        {
            Console.WriteLine("Vous n'êtes pas humain 0_o");
        } 
   } 
}