package whist.vue;

import whist.controleur.WhistControleur;
import whist.decorator.DistribuerCartes;
import whist.model.Joueur;
import javax.swing.*;

/**
 * Décorateur de VueJoueur afin de transformer une fenêtre de joueur en fenêtre
 * de distributeur
 */
public class VueDistributeur extends DistribuerCartes {

    private final JButton _boutonDistribuer = new JButton("Distribuer");


    /**
     * Constructeur
     * @param controleur Le controleur du jeu
     * @param joueur Le joueur concerné
     */
    public VueDistributeur(WhistControleur controleur, Joueur joueur){
        super(controleur, joueur);
    }

    /**
     * Décore _VueJoueur en une vue de distributeur
     * La méthode y ajoute un bouton "Distribuer"
     */
    @Override
    public void Decorer(){
        super.getPanel().add(_boutonDistribuer);
        _boutonDistribuer.addActionListener((e) -> super.getControleur().distribuerCartes());
    }

    /**
     * Supprime la décoration de _VueJoueur
     * La méthode y supprime le bouton distribuer
     */
    @Override
    public void Supprimer() {
        super.getPanel().remove(_boutonDistribuer);
    }

    /**
     * Recupere la vue du joueur concernée par le décorateur
     * @return VueJoueur La vue du joueur
     */
    @Override
    public VueJoueur GetVue() {
        return (VueJoueur) this;
    }

    /**
     * Change la vue que le décorateur change
     * @param vue La vue concernée
     */
    @Override
    public void SetVue(VueJoueur vue) {
        //this.Supprimer();
        //....
    }
}
