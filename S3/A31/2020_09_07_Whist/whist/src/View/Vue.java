package View;
import Controler.Controleur;
import whist.whistmodel.*;
import javax.swing.*;
import java.awt.*;

public class Vue extends JFrame
{
    Controleur c;
    Panel panel;
    Joueur j;

    public Vue(Controleur controleur, boolean donneur, Joueur joueur, int x, int y)
    {
        c = controleur;
        panel = new Panel(this, donneur, c);
        j = joueur;

        // LISTE DES CARTES DU JOUEUR
        if(!j.getCartes().isEmpty()) {
            panel.remove(1);
            JList liste_cartes = new JList(j.getCartes().toArray());
            panel.add(new JScrollPane(liste_cartes), panel.gbc);

            // CARTES DU PLI
            JList liste_cartes_pli = new JList();
            panel.add(new JScrollPane(liste_cartes_pli), panel.gbc);
        }


        setTitle(j.getNom());
        setLocation(x, y);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setVisible(true);
        setContentPane(panel);
        pack();
    }

    public void Mise_a_jour(){
/*
        for(int i = 2; i < panel.getComponentCount(); i++){
            try {
                System.out.println(panel.getComponentCount());
                panel.remove(i);
            }
            catch (ArrayIndexOutOfBoundsException erreur) {
                // Rien
            }
        }
*/
        // LISTE DES CARTES DU JOUEUR
        if(!j.getCartes().isEmpty()) {
            JList liste_cartes = new JList(j.getCartes().toArray());
            panel.add(new JScrollPane(liste_cartes), panel.gbc, 3);

        }

        // CARTES DU PLI
        JList liste_cartes_pli = new JList();
        panel.add(new JScrollPane(liste_cartes_pli), panel.gbc, 4);


        // ATOUT
        try {
            JLabel lbl_atout = new JLabel(c.getPartie().getAtout().toString());
            panel.topRow.add(lbl_atout);
        }
        catch(NullPointerException erreur) {
            // Rien
        }

        pack();
    }
}

class Panel extends JPanel {

    JPanel topRow = new JPanel(new GridLayout(1,5));
    GridBagConstraints gbc = new GridBagConstraints();


    public Panel(Vue v, boolean donneur, Controleur c) {
        setLayout(new GridBagLayout());

        // BOUTONS DISTRIBUER ; LANCER PARTIE ; METTRE A JOUR
        if(donneur) {
            // bouton distribuer
            JButton bouton_distrib = new JButton("Distribuer cartes");
            bouton_distrib.addActionListener(actionEvent -> c.DistribuerCartes());

            // bouton lancer partie
            JButton bouton_lancer = new JButton("Demarrer");

            topRow.add(bouton_distrib);
            topRow.add(bouton_lancer);
        }

        // BOUTON METTRE A JOUR
        JButton bouton_maj = new JButton("Mettre à jour");
        bouton_maj.addActionListener(actionEvent -> v.Mise_a_jour());
        topRow.add(bouton_maj);

        // LABELS ATOUT
        JLabel lbl_atouttxt = new JLabel(" Atout : ");
        topRow.add(lbl_atouttxt);
        try {
            JLabel lbl_atout = new JLabel(c.getPartie().getAtout().toString());
            topRow.add(lbl_atout);
        }
        catch(NullPointerException erreur) {
            // Rien
        }

        gbc.weightx = 1;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.gridx = 0;
        gbc.gridy = 0;

        add(topRow, gbc, 0);
        gbc.gridy = 2;
        add(new JPanel(new GridLayout(1,1)),1);
        gbc.gridy = 1;
        gbc.weighty = 1;
        gbc.fill = GridBagConstraints.BOTH;
        add(new JScrollPane(new JList()), gbc, 2);

    }
}
