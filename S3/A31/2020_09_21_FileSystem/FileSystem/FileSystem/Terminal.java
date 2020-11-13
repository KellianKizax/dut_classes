package filesystem;

public class Terminal {

    private static Terminal _terminal = null;
    // Directory courant
    private Directory _workingDir;



    // Constructeur
    private Terminal(Directory workingDirectory) {
        _workingDir = workingDirectory;
    }

    // Méthode gérant le singleton de Terminal
    public static Terminal getInstance(Directory workingDirectory){
        if( _terminal == null)
            _terminal = new Terminal(workingDirectory);
        return _terminal;
    }



    // crée un File à l'emplacement courant
    public void touch(String name){
        File fi = Fabrique.createFile(name, _workingDir, null);
    }

    // crée un Directory à l'emplacement courant
    public void mkdir(String name){
        Directory dir = Fabrique.createDirectory(name, _workingDir);
    }

    // Liste les enfants du Directory courant
    public void ls(){
        for(Path child : _workingDir.getChildren()){
            System.out.println(child.getName());
        }
    }

    // affiche le chemin absolu du Directory courant
    public void pwd() {
        System.out.println(Services.getPath(_workingDir));
    }

    // changer de Directory courant
    public void cd(String directoryName) {
        for(Path child : _workingDir.getChildren()){
            if(child.getName().equals(directoryName))
                if(child instanceof Directory)
                    _workingDir = (Directory) child;
        }
    }

    // Suppression d'un File
    public void rm(String fileName){
        for(Path child : _workingDir.getChildren()){
            if(child.getName().equals(fileName))
                if(child instanceof File)
                    child.delete();
        }
    }

    // Suppression d'un Directory
    public void rmdir(String directoryName){
        for(Path child : _workingDir.getChildren()){
            if(child.getName().equals(directoryName))
                if(child instanceof Directory)
                    child.delete();
        }
    }

    // renommer un Path du dossier courant
    public void mv(String oldName, String newName){
        for(Path child : _workingDir.getChildren())
            if(child.getName().equals(oldName))
                child.setName(newName);
    }
}
