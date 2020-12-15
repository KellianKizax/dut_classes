// asso_sportive.cs : calcul le prix d'adhésion en fonction du nombre d'enfants
// Kellian GOFFIC

using System;

class asso_sportive
{
    static void Main()
   {
        // Declaration des variables :
        // nbenfants    : int   : nombres d'enfants à inscrire
        // prixBase     : double: prix brut
        // prix         : double: prix avec les reductions
        // animateur    : string: est un animateur Oui ou Non (O/N)
        // membre       : string: est un animateur Oui ou Non (O/N)
        // reduction    : double: redection applicable (1,20/1,30)
        int nbenfants;
        double prixBase;
        double prix;
        string animateur;
        string membre;
        double reduction;


        // Initialisation par l'utilisateur
        Console.WriteLine("Quel est le nombre d'enfants à inscrire ?");
        nbenfants = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Etes vous animateur dans le club ? (O/N)");
        animateur = Console.ReadLine();
        
        Console.WriteLine("Etes vous membre du bureau ? (O/N)");
        membre = Console.ReadLine();

        if (membre == "O")
       {
           if (animateur == "O")
          {
              reduction = 0.70;
          } 
           else
          {
              reduction = 0.80;
          } 
       } 
        else
       {
           if (animateur == "O")
          {
              reduction = 0.70;
          } 
           else
          {
              reduction = 1;
          } 
       } 
        
        // Appel de la fonction de calcul du prix cotisationDeBase
        prixBase = cotisationDeBase(nbenfants);
        
        // Calcul du prix final
        prix = prixBase * reduction;
        
        // Affichage du resultat
        Console.WriteLine("Le prix à payer est de "+prix+"€");
       

    } 


    //Calcul_Prix : fonc : int : calcul le prix en fonction du nombre d'enfants >= 3
    //parametres :
    //      Xenfants : int : Nombre d'enfants
    //Retour/Local :
    //      prix : int : prix à payer
    public static int cotisationDeBase(int Xnbenfants)
   {
       int prix;
       
       if (Xnbenfants==1)
      {
          prix=100;
      } 
       else if (Xnbenfants==2)
      {
          prix=100+85;
      } 
      else if (Xnbenfants>=3)
     {
         prix=100+85+ 60*(Xnbenfants - 2);
     } 
      else
     {
         prix=0;
     } 
       return prix;
    } 
}
