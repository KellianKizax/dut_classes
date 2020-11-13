package Version2.View;
import Version2.Modele.Feu;
import Version2.Observer.Obsver;

import javax.swing.*;

public class VueText extends Obsver {

    private final Feu f;

    public VueText(Feu feu){

        f = feu;

        JPanel panel = new JPanel();

        JLabel label_couleur;
        if(f.getCouleur().equals("")){
            label_couleur = new JLabel("Eteint");
        }
        else {
            label_couleur = new JLabel(f.getCouleur());
        }

        JButton bouton_demarrer = new JButton("Toggle Start/Stop");
        bouton_demarrer.addActionListener(actionEvent -> f.arreterDemarrer());

        JButton bouton_couleur = new JButton("Switch Color");
        bouton_couleur.addActionListener(actionEvent -> f.changer());

        JButton bouton_strat = new JButton("Switch n Temps");
        bouton_strat.addActionListener(actionEvent -> f.toggle_strat());

        panel.add(label_couleur,0);
        panel.add(bouton_demarrer,1);
        panel.add(bouton_couleur,2);
        panel.add(bouton_strat,3);

        setTitle("Version2.Modele.Feu Text");
        setLocation(100,100);
        setSize(500,80);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
        setContentPane(panel);
    }

    @Override
    public void updat() {
        if(f.getCouleur().equals("")){
            ((JLabel) getContentPane().getComponent(0)).setText("Eteint");
        }
        else {
            ((JLabel) getContentPane().getComponent(0)).setText(f.getCouleur().substring(0,f.getCouleur().length()-1));
        }
    }
}