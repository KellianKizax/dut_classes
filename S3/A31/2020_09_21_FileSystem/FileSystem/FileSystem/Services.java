package filesystem;

import java.io.*;
import java.util.ArrayList;

public class Services {

    // retourne le chemin absolu d'un Path ex: "\root\a\b\c"
    public static String getPath(Path Xp){

        StringBuilder fullPath = new StringBuilder("\\" + Xp.getName());
        Path p = Xp;

        while(p.getParent() != null){
            p = p.getParent();
            fullPath.insert(0, "\\" + p.getName());
        }

        return fullPath.toString();
    }

    // retourne tous les enfants récursifs d'un Chemin donné, y compris lui-même
    public static ArrayList<Path> getAllChildren(Path p)
    {
        ArrayList<Path> list = new ArrayList<>();

        list.add(p);

        int i = 0;
        boolean sortie = false;

        while(!sortie)
        {
            int size = list.size();

            while(i<size)
            {
                if(list.get(i).getChildren() != null)
                    list.addAll(list.get(i).getChildren());

                else
                    sortie = true;

                i++;
            }
        }
        return list;
    }

    // retourne l'enfant dont le nom correspond à celui donné en paramètre parmis tous les enfants récursifs du Path en paramètre
    public static ArrayList<Path> findChildren(Path p, String name){
        ArrayList<Path> allChildren = getAllChildren(p);
        ArrayList<Path> foundChildren = new ArrayList<>();

        for(Path element : allChildren){
            if(element.getName().equals(name))
                foundChildren.add(element);
        }
        return foundChildren;
    }

    // retourne la somme des tailles de tous les enfants recursifs d'un Path
    public static int getDirectorySize(Path p){
        ArrayList<Path> allChildren = getAllChildren(p);
        int size = 0;

        for(Path element : allChildren)
            size += element.getSize();

        return size;
    }

    // serialization d'un Path
    public static void serializePath(Path p){
        try(
            FileOutputStream out = new FileOutputStream("monFichier.serial");
            ObjectOutputStream ser = new ObjectOutputStream(out);
            ){
            ser.writeObject(p);
        }
        catch (IOException e) {
            System.out.println("Error : " + e.getMessage());
        }
    }

    // deseralization d'un Path
    public static Path deseralizePath(String fileName){
        Path result = null;
        try(
                FileInputStream in = new FileInputStream(fileName);
                ObjectInputStream ser = new ObjectInputStream(in);
                ){
            result = (Path) ser.readObject();
        }
        catch (IOException e){
            System.out.println("Eroor : " + e.getMessage());
        }
        catch (ClassNotFoundException e){
            System.out.println("Error : " + e.getMessage());
        }
        return result;
    }
}