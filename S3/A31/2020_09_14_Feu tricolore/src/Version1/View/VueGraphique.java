package Version1.View;
import Version1.Observer.*;
import Version1.Modele.Feu;
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
                case "Rouge" : setBackground(Color.RED);
                case "Orange" : setBackground(Color.ORANGE);
                case "Vert" : setBackground(Color.GREEN);
            }
        }
        System.out.println(f.getCouleur());

        JButton bouton_demarrer = new JButton("Toggle Start/Stop");
        bouton_demarrer.addActionListener(actionEvent -> f.arreterDemarrer());

        JButton bouton_couleur = new JButton("Switch Color");
        bouton_couleur.addActionListener(actionEvent -> f.changer());

        panel.add(bouton_demarrer,0);
        panel.add(bouton_couleur,1);

        setTitle("Version1.Modele.Feu Text");
        setLocation(600,100);
        setSize(400,480);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
        setContentPane(panel);
    }

    @Override
    public void updat() {
        switch (f.getCouleur()) {
            case "":
                getContentPane().setBackground(Color.GRAY);
                break;
            case "Rouge":
                getContentPane().setBackground(Color.RED);
                break;
            case "Orange":
                getContentPane().setBackground(Color.ORANGE);
                break;
            case "Vert":
                getContentPane().setBackground(Color.GREEN);
                break;
        }
    }
}