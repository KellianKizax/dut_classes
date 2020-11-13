package filesystem;

import java.util.Objects;

public class Fabrique {

    // variable globale contenant l'unique instance de Fabrique
    private static Fabrique _fabrique = null;



    // Constructeur
    private Fabrique() {}

    // méthode pour le singleton
    public static Fabrique getInstance(){
        if ( _fabrique == null )
            _fabrique = new Fabrique();
        return _fabrique;
    }



    // vérification des paramètres et création d'un directory
    public static Directory createDirectory(String name, Path parent)
        throws IllegalArgumentException
    {
        Directory dir;

        if( !(name.isBlank() || name.isEmpty()) )
        {
            if(parent == null)
                throw new IllegalArgumentException("Parent cant be null");
            else
                dir = new Directory(name,parent);
        }
        else
            throw new IllegalArgumentException("Name cant be blank or empty");

        return dir;
    }

    // vérification des paramètres et création d'un fichier
    public static File createFile(String name, Path parent, String object)
        throws IllegalArgumentException
    {
        File fi;

        if( !(name.isBlank() || name.isEmpty()) )
        {
            if(parent == null)
            {
                throw new IllegalArgumentException("Parent cant be null");
            }
            else {
                fi = new File(name, parent, Objects.requireNonNullElse(object, ""));
            }
        }
        else
            throw new IllegalArgumentException("Name cant be blank or empty");

        return fi;
    }
}