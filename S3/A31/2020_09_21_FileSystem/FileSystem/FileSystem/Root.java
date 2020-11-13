package filesystem;

public class Root extends Directory {

    private static Root _root = null;



    // constructeur hérité de Directory hérité de Path à 1 paramètre
    private Root(String name) {
        super(name);
    }



    // méthode permettant de gérer le singleton
    public static Root getInstance(){
        if ( _root == null ){
            _root = new Root("root");
        }
        return _root;
    }
}