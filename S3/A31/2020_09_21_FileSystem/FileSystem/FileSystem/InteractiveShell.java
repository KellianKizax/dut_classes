package filesystem;

import java.io.Console;
import java.util.List;

import jdk.jshell.JShell;
import jdk.jshell.SnippetEvent;

public class InteractiveShell {
	
	public static void main(String[] args) {
		
		Console console = System.console();
			
		try (JShell jsh = JShell.create()) {
			// imports (a completer)
			jsh.eval("import filesystem.Terminal;");
			jsh.eval("import filesystem.Fabrique;");
			jsh.eval("import filesystem.Services;");
			jsh.eval("import filesystem.Directory;");
			jsh.eval("import filesystem.File;");
			jsh.eval("import filesystem.Path;");
			jsh.eval("import filesystem.Root;");
			
			// Creation de la racine du systeme de fichiers
			jsh.eval( "Directory root = Root.getInstance();");
			
			// Creation d'un terminal
			jsh.eval( "Terminal t = new Terminal(root);" );
			
			// Creation d'une vue ?
			
			// Boucle infinie d'evaluations
			do {
				System.out.print("> ");
				

				String input = console.readLine();
				if (input == null) {
					break; // Termine sur CTRL + D
				}
				
				/* On transforme l'input de la facon suivante :
				 * ls -> ls()
				 * rm file -> rm("file")
				 */
				String[] arg = input.split("\\s"); // whitespace character
				
				input = "t." + arg[0] + '(';
				if( arg.length == 2)
					input += '"' + arg[1] + '"';
				if(arg.length == 3)
					input += '"' + arg[1]+'"' + ", \"" + arg[2] + '"';
				input += ')';
				// Evaluation de la commande
				List<SnippetEvent> events = jsh.eval(input);
				
				for (SnippetEvent e : events) {
					if (e.value() != null) {
						System.out.print(e.value());
						
					} else
						System.err.println(e);
					System.out.flush();
					
				}
				
				// Mise a jour de la vue ?
				
				
			} while (true);
			
		} // Fin try-with-resource
		
		System.out.println();

	}
}