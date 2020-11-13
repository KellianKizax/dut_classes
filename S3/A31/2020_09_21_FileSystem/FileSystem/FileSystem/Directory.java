package filesystem;

public class Directory extends Path {

    // Constructeur hérité de Path à 2 paramètres
    Directory(String name, Path parent) {
        super(name, parent);
    }

    // Constructeur hérité de Path à 1 paramètre
    Directory(String name) { super(name); }

    // On override les deux méthodes suivantes afin de ne pas pouvoir faire d'actions sur l'objet d'un repertoire
    @Override
    public String getObjet() {
        return null;
    }

    @Override
    public void setObject(String object) {}
}