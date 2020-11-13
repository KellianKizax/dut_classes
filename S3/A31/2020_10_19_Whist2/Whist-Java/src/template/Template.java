package template;

import whist.controleur.WhistControleur;
import whist.model.Partie;

import javax.swing.*;
import java.awt.*;

/**
 * Classe Template permettant de créer une partie de Whist ou de Belote
 */
public abstract class Template {

    /**
     * Classe MyIcon permettant d'afficher une image au centre entre les différentes fenêtres des joueurs
     */
    static class MyIcon extends Window {
        public MyIcon() {
            super(null);
            Icon marius = new ImageIcon( getClass().getClassLoader().getResource("Marius.jpg") );
            add(new JLabel(marius));
            pack();
            Point p = GraphicsEnvironment.getLocalGraphicsEnvironment().getCenterPoint();
            p.translate(-marius.getIconWidth() / 2, -marius.getIconHeight() / 2);
            setLocation(p);
            setVisible(true);
        }
    };

    /**
     * Constructeur de la classe Template
     */
    public Template(){}

    /**
     * Créé une partie avec 4 noms donnés en paramètre.
     *
     * La classe Partie devrait être une classe abstraite, complétée par 2 classes : BelotePartie et WhistPartie.
     *
     * @param nomsDesJoueurs tableau des 4 noms des joueurs.
     * @return La partie créée.
     */
    abstract protected Partie CreatePartie(String[] nomsDesJoueurs);

    /**
     * Créé le controleur en fonction du jeu souhaité.
     *
     * Ici la classe WhistControleur devrait être remplacée par une classe Controleur,
     * elle-meme completee par 2 classes : WhistControleur et BeloteControleur.
     *
     * @param partie La partie précédemment créée.
     * @return Le controleur créé.
     */
    abstract protected WhistControleur CreateControleur(Partie partie);

    /**
     * Créé les vues des différents joueurs.
     *
     * @param controleur Le controleur précédemment créé.
     * @param partie La partie précédemment créé.
     */
    abstract protected void CreateView(WhistControleur controleur, Partie partie);
}
