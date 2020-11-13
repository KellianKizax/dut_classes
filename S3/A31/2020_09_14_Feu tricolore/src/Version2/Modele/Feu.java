package Version2.Modele;

import Version2.Observer.Obsvable;
import Version2.Modele.Strategie.*;

public class Feu extends Obsvable {

    private boolean en_marche;
    private String couleur;
    private int strategie = 3;

    public Feu(boolean fonctionnement){
        if(fonctionnement){
            en_marche = true;
            couleur = "Rouge1";
        }
        else {
            en_marche = false;
            couleur = "";
        }
    }

    public void arreterDemarrer(){
        if(en_marche){
             en_marche = false;
             couleur = "";
        }
        else {
            en_marche = true;
            couleur = "Rouge1";
        }
        notif();
    }

    public void changer(){
        if(en_marche){
            switch(strategie){
                case 3 : couleur = Strategie3.changer(couleur); break;
                case 4 : couleur = Strategie4.changer(couleur); break;
            }
            notif();
        }
    }

    public void toggle_strat(){
        switch(strategie){
            case 3 : strategie = 4; break;
            case 4 : strategie = 3; break;
        }
    }

    public String getCouleur() {
        return couleur;
    }
}
