import Controler.Controleur;
import whist.whistmodel.*;

public class Main {
    public static void main(String[] args){

        Partie p = new Partie("A","B","C","D");
        Controleur controleur = new Controleur(p);

        controleur.AfficherJoueurs();


    }
}
