package whist.decorator;

import whist.controleur.WhistControleur;
import whist.model.Joueur;
import whist.vue.VueJoueur;

public abstract class DistribuerCartes extends VueJoueur {

    /**
     * Construit une vue pour le joueur dont le modèle est passé en paramètre.
     *
     * @param controleur le contrôleur de cette vue dans le modèle MVC
     * @param joueur     la référence de l'instance de Joueur liée à cette vue
     */
    public DistribuerCartes(WhistControleur controleur, Joueur joueur) {
        super(controleur, joueur);
    }

    abstract public void Decorer();
    abstract public void Supprimer();
    abstract public VueJoueur GetVue();
    abstract public void SetVue(VueJoueur vue);
}