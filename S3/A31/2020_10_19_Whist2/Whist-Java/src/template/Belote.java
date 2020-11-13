/*package template;

import java.util.ArrayList;



pour pouvoir créer un jeu du whist et de belote, il faudrait créer des classes
abstraites communes comme les controleurs, modèles, vues, décorateurs,
et les compléter avec des classes spécialisées pour chaque jeu quand cela est nécessaire.

Cela permettrait de réutiliser le plus de code possible tout en utilisant le patron
template en ne mentionnant que les classes abstraites dans les paramètres et retour
des méthodes de la classe Template.





public class Belote extends Template {

    public Belote(String[] nomDesJoueurs){
        Partie p = CreatePartie(nomDesJoueurs);
        BeloteControleur ctrl = CreateControleur(p);
        CreateView(ctrl, p);
        ctrl.avancer();
    }

    @Override
    protected Partie CreatePartie(String[] nomsDesJoueurs) {
        Partie p;
        if(nomsDesJoueurs.length==4){
            p = new Partie(nomsDesJoueurs[0], nomsDesJoueurs[2], nomsDesJoueurs[3], nomsDesJoueurs[4]);
        }
        else {
            throw new IllegalArgumentException("4 noms de joueurs requis.");
        }
        return p;
    }

    @Override
    protected BeloteControleur CreateControleur(Partie partie) {
        return new BeloteControleur( partie );
    }

    @Override
    protected void CreateView(BeloteControleur controleur, Partie partie) {
        new MyIcon();
        ArrayList<VueJoueur> ListeVuesJoueurs = new ArrayList<>();

        for( int i = 0; i < partie.getJoueurs().size(); i++ ){
            ListeVuesJoueurs.add( new VueDistributeur( controleur, partie.getJoueur(i) ) );
        }
        ( (VueDistributeur) ListeVuesJoueurs.get(0) ).Decorer();
    }
}
*/