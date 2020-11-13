package Controler;
import whist.whistmodel.*;
import View.Vue;

public class Controleur {

    private final Partie p;
    private final Pli pli = new Pli();

    public Controleur(Partie partie_courante){
        p = partie_courante;
    }

    public void AfficherJoueurs(){
        Vue v;
        for(int i = 0; i < 4; i++) {
            Joueur joueurCourant = p.getJoueurs().get(i);
            if(i == 0){
                v = new Vue(this,true, joueurCourant,200,10);
            }
            else{
                v = new Vue(this,false,joueurCourant,200,200*i);
            }
        }

    }

    public void DistribuerCartes(){
        p.distribuerCartes();
    }

    public Partie getPartie(){
        return p;
    }

    public Pli getPli(){
        return pli;
    }
}
