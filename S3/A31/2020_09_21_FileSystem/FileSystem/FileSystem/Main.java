package filesystem;

public class Main {
    public static void main(String[] args){

        // /Racine/
        Root racine = Root.getInstance();

        // /Racine/Documents/
        Directory documents = Fabrique.createDirectory("Documents",racine);
        // /Racine/Images/
        Directory images = Fabrique.createDirectory("Images", racine);

        // /Racine/Documents/Cours/
        Directory cours = Fabrique.createDirectory("Cours", documents);
        // /Racine/Documents/Papiers/
        Directory papiers = Fabrique.createDirectory("Papiers", documents);

        // /Racine/Documents/Cours/notes
        File notes = Fabrique.createFile("notes", cours, "CM A31");
        // /Racine/Documents/Papiers/factures206
        File factures = Fabrique.createFile("factures206", papiers, "20 euros");

        // /Racine/Images/Vacances été/
        Directory vacances = Fabrique.createDirectory("Vacances été", images);

        // /Racine/Images/Vacances été/plage
        File photos = Fabrique.createFile("plage", vacances, "20 aout");


        // GETPATH
        System.out.println(Services.getPath(photos));
        System.out.println();

        // GETALLCHILDREN
        for(Path p : Services.getAllChildren(racine)){
            System.out.print(p.getName() + " - ");
        }
        System.out.println();
        System.out.println();

        //  FINDCHILDREN
        for(Path p : Services.findChildren(racine,"factures206")){
            System.out.print(p.getName() + " - ");
        }
        System.out.println();
        System.out.println();

        System.out.println(Services.getDirectorySize(racine));

        //Services.serializePath(racine);
        //Path oldRacine = Services.deseralizePath("monFichier.serial");
        //System.out.println(oldRacine.getName() + " " + oldRacine.getChildren());
    }
}
