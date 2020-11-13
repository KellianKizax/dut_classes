package template;

import whist.controleur.WhistControleur;
import whist.vue.VueDistributeur;
import whist.model.Partie;
import whist.vue.VueJoueur;

import java.util.ArrayList;

public class Whist extends Template {

    /**
     * Constructeur
     *
     * Créé un jeu du Whist.
     * @param nomDesJoueurs tableau de 4 noms des joueurs.
     */
    public Whist(String[] nomDesJoueurs){
        Partie p = CreatePartie(nomDesJoueurs);
        WhistControleur ctrl = CreateControleur(p);
        CreateView(ctrl, p);
        ctrl.avancer();
    }

    /**
     * Créé une partie avec 4 noms donnés en paramètre.
     *
     * La classe Partie devrait être une classe abstraite, complétée par 2 classes : BelotePartie et WhistPartie.
     *
     * @param nomsDesJoueurs tableau des 4 noms des joueurs.
     * @return La partie créée.
     */
    @Override
    protected Partie CreatePartie(String[] nomsDesJoueurs) {
        Partie p;
        if(nomsDesJoueurs.length==4){
            p = new Partie(nomsDesJoueurs[0], nomsDesJoueurs[1], nomsDesJoueurs[2], nomsDesJoueurs[3]);
        }
        else {
            throw new IllegalArgumentException("4 noms de joueurs requis.");
        }
        return p;
    }

    /**
     * Créé le controleur en fonction du jeu souhaité.
     *
     * Ici la classe WhistControleur devrait être remplacée par une classe Controleur,
     * elle-meme completee par 2 classes : WhistControleur et BeloteControleur.
     *
     * @param partie La partie précédemment créée.
     * @return Le controleur créé.
     */
    @Override
    protected WhistControleur CreateControleur(Partie partie) {
        return new WhistControleur( partie );
    }

    /**
     * Créé les vues des différents joueurs.
     *
     * @param controleur Le controleur précédemment créé.
     * @param partie La partie précédemment créé.
     */
    @Override
    protected void CreateView(WhistControleur controleur, Partie partie) {
        new MyIcon();
        ArrayList<VueJoueur> ListeVuesJoueurs = new ArrayList<>();

        for( int i = 0; i < partie.getJoueurs().size(); i++ ){
            ListeVuesJoueurs.add( new VueDistributeur( controleur, partie.getJoueur(i) ) );
        }
        ( (VueDistributeur) ListeVuesJoueurs.get(0) ).Decorer();
    }
}
