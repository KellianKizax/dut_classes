package Version1.Modele;

import Version1.Observer.Obsvable;

import java.util.ArrayList;
import java.util.Arrays;

public class Feu extends Obsvable {

    private boolean en_marche;
    private String couleur;
    final ArrayList<String> couleurs = new ArrayList<String>(Arrays.asList("Rouge", "Vert", "Orange"));

    public Feu(boolean fonctionnement){
        if(fonctionnement){
            en_marche = true;
            couleur = "Rouge";
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
            couleur = "Rouge";
        }
        notif();
    }

    public void changer(){
        if(en_marche){
            couleur = couleurs.get((couleurs.indexOf(couleur)+1)%3);
            notif();
        }
    }

    public boolean getEtat(){
        return en_marche;
    }

    public String getCouleur() {
        return couleur;
    }
}
