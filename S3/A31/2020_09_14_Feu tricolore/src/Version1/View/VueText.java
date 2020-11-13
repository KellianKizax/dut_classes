package Version1.View;
import Version1.Observer.*;
import Version1.Modele.Feu;
import javax.swing.*;

public class VueText extends Obsver {

    private Feu f;

    public VueText(Feu feu){

        f = feu;

        JPanel panel = new JPanel();

        JLabel label_couleur;
        if(f.getCouleur() == ""){
            label_couleur = new JLabel("Eteint");
        }
        else {
            label_couleur = new JLabel(f.getCouleur());
        }

        JButton bouton_demarrer = new JButton("Toggle Start/Stop");
        bouton_demarrer.addActionListener(actionEvent -> f.arreterDemarrer());

        JButton bouton_couleur = new JButton("Switch Color");
        bouton_couleur.addActionListener(actionEvent -> f.changer());

        panel.add(label_couleur,0);
        panel.add(bouton_demarrer,1);
        panel.add(bouton_couleur,2);

        setTitle("Version1.Modele.Feu Text");
        setLocation(100,100);
        setSize(400,80);
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
            ((JLabel) getContentPane().getComponent(0)).setText(f.getCouleur());
        }
    }
}