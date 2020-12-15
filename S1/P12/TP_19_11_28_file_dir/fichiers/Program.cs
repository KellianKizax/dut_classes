using System;
using System.IO;
using System.Collections.Generic;

namespace fichiers
{
    class Program
    {
        static void Main()
        {
            Dir();
            Catn("test");
            Console.ReadLine();
        }
        //=========================================================================================
        public static void Catn(string Xfile)
        {
            if (File.Exists("./"+Xfile))
            {
                StreamReader file = new StreamReader("./" + Xfile);
                int count = 0;
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(count + "\t" + line);
                    count++;
                }
            }
            else
            {
                Console.WriteLine(">> Le fichier n'existe pas");
            }
        }

        //======================
        public static void Dir()
        {
            Console.WriteLine(">> Dossier courant de travail :");
            Console.WriteLine(Directory.GetCurrentDirectory());

            if (!Directory.Exists("./test"))
            {
                Directory.CreateDirectory("./test");
            }
            else
            {
                Directory.Delete("./test", true);
            }

            Console.WriteLine();

            Console.WriteLine(">> Dossiers commencant par 'd' :");
            List<string> liste = new List<string>(Directory.EnumerateDirectories("./", "d*"));
            if (liste.Count == 0)
            {
                Console.WriteLine("Aucun dossiers de ce nom");
            }
            else
            {
                AfficheList(liste);
            }

            Console.WriteLine();

            Console.WriteLine(">> Fichiers commencant par 't' :");
            liste = new List<string>(Directory.EnumerateFiles("./", "*"));
            if (liste.Count == 0)
            {
                Console.WriteLine("Aucun fichiers de ce nom");
            }
            else
            {
                AfficheList(liste);
            }
            Console.WriteLine();
        }
        //=========================================================================================
        public static void AfficheList(List<string> Xlist)
        {
            foreach(string cont in Xlist)
            {
                Console.WriteLine(cont);
            }
        }
    }
}
