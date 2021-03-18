package a31_projet_puissance_4.connect4.views.fiveinarow;

import a31_projet_puissance_4.connect4.controllers.fiveinarow.FiveInController;
import a31_projet_puissance_4.connect4.models.Disc;
import a31_projet_puissance_4.connect4.views.View;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.util.Objects;

public class FiveInView extends View {
    public FiveInView(FiveInController ctrl) {
        super(ctrl, "Puissance 4 5-in-a-row");

        // Paramétrage de la fenêtre
        setDefaultLookAndFeelDecorated(true);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        int nbRows = 6;
        int nbColumns = 9;
        int nbCases = nbRows * nbColumns;
        int discSize = 60;


        // Création du panel et selection du layout
        JPanel panel = new JPanel();
        panel.setLayout( new GridLayout( nbRows+1, nbColumns ) );


        // Créations des boutons de sélection de colonne
        for ( int i = 0; i < nbColumns; i++ ) {

            // Création de l'objet ImageIcon à partir de l'image
            ImageIcon downArrow = new ImageIcon( Objects.requireNonNull( getClass().getClassLoader().getResource("a31_projet_puissance_4/resources/down_arrow.jpg") ) );
            // Transformation de l'ImageIcon en Image
            Image img = downArrow.getImage();
            // Redimensionnement de l'image à la taille du bouton
            img = img.getScaledInstance( discSize, discSize, Image.SCALE_SMOOTH );
            downArrow = new ImageIcon(img);


            JButton btn = new JButton();
            btn.setName( Integer.toString(i) );
            btn.setIcon(downArrow);
            btn.setPreferredSize( new Dimension(discSize, discSize) );
            btn.addActionListener(this::eventPlayDisc);
            panel.add(btn);
        }


        // Création des emplacements de jetons
        // et ajout au panel.
        //for (int i = nbCases-1 ; i >= 0 ; i--) {
        for ( int i = 0; i < nbCases; i++) {

            int noRow, noColumn;
            if ( (i+1) % nbColumns == 0 ) {
                noColumn = 8;
                noRow = nbRows- ((i+1) / nbColumns);
            }
            else {
                noColumn = i % nbColumns;
                noRow = nbRows- (((i+1) / nbColumns) + 1);
            }

            // Création de l'objet ImageIcon à partir de l'image d'une cellule vide
            ImageIcon emptyCell = new ImageIcon( Objects.requireNonNull( getClass().getClassLoader().getResource("a31_projet_puissance_4/resources/empty_cell.jpg") ) );
            // Transformation de ImageIcon en Image
            Image img = emptyCell.getImage();
            // Redimensionnement de l'image à la taille du label
            img = img.getScaledInstance( discSize, discSize, Image.SCALE_SMOOTH );
            emptyCell = new ImageIcon(img);


            JLabel lbl = new JLabel(noColumn+","+noRow);
            lbl.setIcon( emptyCell );
            lbl.setPreferredSize( new Dimension(discSize, discSize) );
            lbl.setName(noColumn+","+noRow);

            panel.add(lbl);
        }


        this.setContentPane(panel);
        this.pack();
        this.setVisible(true);

        this.update();
    }

    @Override
    protected void eventPlayDisc(ActionEvent event) {
        if( event.getSource() instanceof JButton ) {
            JButton jb = (JButton) event.getSource();
            int noColunm = Integer.parseInt( jb.getName() );
            super._controller.getStrategy().setCurrentPosition( noColunm );
            super._controller.getStrategy().setCurrentDisc( "StandardDisc" );
            super._controller.getStrategy().forward();
        }
    }

    @Override
    public void update() {
        for ( Component co : this.getContentPane().getComponents() ) {
            if ( co instanceof JLabel ) {
                JLabel jl = (JLabel) co;

                String coord = jl.getName();
                System.out.println(coord);

                int noColumn = Integer.parseInt( coord.split(",")[0] );
                int noRow = Integer.parseInt( coord.split(",")[1] );

                Disc[][] grid = this._controller.getStrategy().getDiscsGrid();


                if ( grid[noColumn][noRow] != null ) {
                    Disc d = grid[noColumn][noRow];
                    if ( d.getOwner().getId() == 0 ) {
                        // Création de l'objet ImageIcon à partir de l'image d'une cellule vide
                        ImageIcon redCell = new ImageIcon( Objects.requireNonNull( getClass().getClassLoader().getResource("a31_projet_puissance_4/resources/red_cell.jpg") ) );
                        // Transformation de ImageIcon en Image
                        Image img = redCell.getImage();
                        // Redimensionnement de l'image à la taille du label
                        img = img.getScaledInstance( 60, 60, Image.SCALE_SMOOTH );
                        redCell = new ImageIcon(img);

                        jl.setIcon(redCell);
                    }
                    else if ( d.getOwner().getId() == 1 ) {
                        // Création de l'objet ImageIcon à partir de l'image d'une cellule vide
                        ImageIcon yellowCell = new ImageIcon( Objects.requireNonNull( getClass().getClassLoader().getResource("a31_projet_puissance_4/resources/yellow_cell.jpg") ) );
                        // Transformation de ImageIcon en Image
                        Image img = yellowCell.getImage();
                        // Redimensionnement de l'image à la taille du label
                        img = img.getScaledInstance( 60, 60, Image.SCALE_SMOOTH );
                        yellowCell = new ImageIcon(img);

                        jl.setIcon(yellowCell);
                    }
                }

            }
        }
    }
}
