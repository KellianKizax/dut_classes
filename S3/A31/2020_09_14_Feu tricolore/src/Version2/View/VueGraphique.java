package Version2.View;
import Version2.Modele.Feu;
import Version2.Observer.Obsver;

import javax.swing.*;
import java.awt.*;

public class VueGraphique extends Obsver {

    private final Feu f;

    public VueGraphique(Feu feu){

        f = feu;

        JPanel panel = new JPanel();

        if(f.getCouleur().equals("")){
            setBackground(Color.GRAY);
        }
        else {
            switch (f.getCouleur()){
                case "Rouge1" : setBackground(Color.RED); break;
                case "Orange1" :
                case "Orange2" : setBackground(Color.ORANGE); break;
                case "Vert1" : setBackground(Color.GREEN); break;
            }
        }
        System.out.println(f.getCouleur());

        JButton bouton_demarrer = new JButton("Toggle Start/Stop");
        bouton_demarrer.addActionListener(actionEvent -> f.arreterDemarrer());

        JButton bouton_couleur = new JButton("Switch Color");
        bouton_couleur.addActionListener(actionEvent -> f.changer());

        JButton bouton_strat = new JButton("Switch n Temps");
        bouton_strat.addActionListener(actionEvent -> f.toggle_strat());

        panel.add(bouton_demarrer,0);
        panel.add(bouton_couleur,1);
        panel.add(bouton_strat,2);

        setTitle("Version2.Modele.Feu Text");
        setLocation(700,100);
        setSize(500,480);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
        setContentPane(panel);
    }

    @Override
    public void updat() {
        switch (f.getCouleur()) {
            case "": getContentPane().setBackground(Color.GRAY); break;
            case "Rouge1": getContentPane().setBackground(Color.RED); break;
            case "Orange1":
            case "Orange2": getContentPane().setBackground(Color.ORANGE); break;
            case "Vert1": getContentPane().setBackground(Color.GREEN); break;
        }
    }
}