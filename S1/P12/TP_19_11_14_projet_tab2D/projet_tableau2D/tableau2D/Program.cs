using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace tableau2D
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("hello");
            int[,] tabImage = TabFromFile("lena.bmp");
            affiche_image(tabImage);
            saveImage(tabImage, "original.bmp");        
            Console.WriteLine("ok : ");
            Console.ReadLine();

            ============================================
            int col, li, min, max;
            int[,] tab;

            Console.WriteLine("Entrez le nombre de colonnes, de lignes, la valeur min puis max : ");

            col = int.Parse(Console.ReadLine());
            li = int.Parse(Console.ReadLine());
            min = int.Parse(Console.ReadLine());
            max = int.Parse(Console.ReadLine());
            tab = CreaRndTab2D(col, li, min, max);

            AfficheTab2D(tab);
            

            InitRayeTab2D(tab);
            AfficheTab2D(tab);
            
            InitDiagTab2D(tab);
            AfficheTab2D(tab);
            ===============================================
            

            affiche_image(TabFromFile("lena.bmp"));
            */

            /*
            Console.WriteLine(" Minimum : " + MinTab2D(TabFromFile("lena.bmp")));
            Console.WriteLine(" Maximum : " + MaxTab2D(TabFromFile("lena.bmp")));
            Console.WriteLine(" Moyenne : " + MoyTab2D(TabFromFile("lena.bmp")) );

            AfficheTab1D(histo1DTab2D(TabFromFile("lena.bmp")));
            affiche_histo(histo1DTab2D(TabFromFile("lena.bmp")));

            affiche_image(Binarise(TabFromFile("lena.bmp"), 128));
            */

            /*
            affiche_image(Normalise(TabFromFile("lena.bmp"), 65, 190));
            affiche_histo(histo1DTab2D(Normalise(TabFromFile("lena.bmp"), 65, 190)));
            */

            /*
            affiche_image(Assombrit(TabFromFile("lena.bmp")));
            Console.WriteLine(" Minimum : " + MinTab2D(Assombrit(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Maximum : " + MaxTab2D(Assombrit(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Moyenne : " + MoyTab2D(Assombrit(TabFromFile("lena.bmp"))));
            affiche_histo(histo1DTab2D(Assombrit(TabFromFile("lena.bmp"))));
            */

            Console.WriteLine(" Minimum : " + MinTab2D(Assombrit(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Maximum : " + MaxTab2D(Assombrit(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Moyenne : " + MoyTab2D(Assombrit(TabFromFile("lena.bmp"))));

            Console.WriteLine(" Minimum : " + MinTab2D(Recentre(Assombrit(TabFromFile("lena.bmp")), 128)));
            Console.WriteLine(" Maximum : " + MaxTab2D(Recentre(Assombrit(TabFromFile("lena.bmp")), 128)));
            Console.WriteLine(" Moyenne : " + MoyTab2D(Recentre(Assombrit(TabFromFile("lena.bmp")), 128)));

            Console.WriteLine(" Minimum : " + MinTab2D(Recadre(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Maximum : " + MaxTab2D(Recadre(TabFromFile("lena.bmp"))));
            Console.WriteLine(" Moyenne : " + MoyTab2D(Recadre(TabFromFile("lena.bmp"))));

            Console.WriteLine("Fin du programme, Appuyez sur une touche pour quitter.");
            Console.ReadLine();
        }

        //============================================================================

        public static int[,] Recadre(int[,] Xtab)
        {
            int[,] tabBin = Recentre(Xtab, 128);
            double min = MinTab2D(tabBin);
            double max = MaxTab2D(tabBin);
            double nominateur;
            double denominateur;
            double division;

            for (int i = 0; i < tabBin.GetLength(0); i++)
            {
                for (int j = 0; j < tabBin.GetLength(1); j++)
                {
                    nominateur = tabBin[i, j] - min;
                    denominateur = max - min;
                    division = (nominateur) / denominateur;
                    tabBin[i,j] = (int)(255*division);
                }
            }

            return tabBin;
        }

        public static int[,] Recentre(int[,] Xtab, int XmoyenneRecentre)
        {
            int[,] tabBin = CreaRndTab2D(Xtab.GetLength(1), Xtab.GetLength(0), 0, 0);
            int differenceMoyenne = XmoyenneRecentre - MoyTab2D(Xtab);

            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    if ( (Xtab[i,j] + differenceMoyenne) < 0)
                    {
                        tabBin[i, j] = 0;
                    }
                    else if ((Xtab[i, j] + differenceMoyenne) > 255)
                    {
                        tabBin[i, j] = 255;
                    }
                    else
                    {
                        tabBin[i, j] = Xtab[i, j] + differenceMoyenne;
                    }
                }
        
            }
            return tabBin;
        }

        /* Assombrit :   fonc    :   int[,]  :   divise toutes les valeurs de niveau de gris par deux
        * 
        * PARAMETRES :
        *  Xtab    :   int[,]  :   tableau 2D
        *  
        * LOCAL :
        *  tabBin  :   int[,]  :   tableau assombrit
        * 
        * RETOUR :
        *  tabBin  :   int[,]  :   tableau assombrit
        */
        public static int[,] Assombrit(int[,] Xtab)
        {
            int[,] tabBin = CreaRndTab2D(Xtab.GetLength(1), Xtab.GetLength(0), 0, 0);

            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    tabBin[i, j] = Xtab[i, j] / 2;
                }
            }

            return tabBin;
        }

        /* Normalise :   fonc    :   int[,]  :   remplace les valeurs en dessous d'un seuil plancher par le seuil et au dessus d'un seuil plafond par lui meme
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  XseuilPlancher  :   int     :   seuil (0-255)
         *  XseuilPlafond   :   int     :   seuil (0-255)
         *  
         * LOCAL :
         *  tabBin  :   int[,]  :   tableau normalisé
         * 
         * RETOUR :
         *  tabBin  :   int[,]  :   tableau normalisé
         */
        public static int[,] Normalise(int[,] Xtab, int XseuilPlancher, int XseuilPlafond)
        {
            int[,] tabBin = CreaRndTab2D(Xtab.GetLength(1), Xtab.GetLength(0), 0, 0);

            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    if (Xtab[i, j] < XseuilPlancher)
                    {
                        tabBin[i, j] = XseuilPlancher;
                    }
                    else if (Xtab[i,j] > XseuilPlafond)
                    {
                        tabBin[i, j] = XseuilPlafond;
                    }
                    else
                    {
                        tabBin[i, j] = Xtab[i, j];
                    }
                }
            }

            return tabBin;
        }

        /* Binarise :   fonc    :   int[,]  :   remplace les valeurs en dessous d'un seuil par 0 et au dessus par 255
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  Xseuil  :   int     :   seuil (0-255)
         *  
         * LOCAL :
         *  tabBin  :   int[,]  :   tableau binarisé
         * 
         * RETOUR :
         *  tabBin  :   int[,]  :   tableau binarisé
         */
        public static int[,] Binarise(int[,] Xtab, int Xseuil)
        {
            int[,] tabBin = CreaRndTab2D(Xtab.GetLength(1), Xtab.GetLength(0), 0, 0);

            for (int i = 0; i<Xtab.GetLength(0); i++)
            {
                for (int j = 0; j<Xtab.GetLength(1); j++)
                {
                    if (Xtab[i,j]< Xseuil)
                    {
                        tabBin[i, j] = 0;
                    }
                    else
                    {
                        tabBin[i, j] = 255;
                    }
                }
            }

            return tabBin;
        }

        /* histo1DTab2D :   fonc    :   int[]   :   retourne un tableau 1D de 256 cases, avec le nombre d'occurences pour chaque valeur contenu dans un tableau 2D
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  
         * LOCAL :
         *  compteur    :   int     :   nombre d'occurences de la valeur courante
         *  tab         :   int[]   :   tableau 1D contenant le nombre d'occurences de chaque valeur du tableau 2D
         * 
         * RETOUR :
         *  tab :   int[]
         */
        public static int[] histo1DTab2D(int[,] Xtab)
        {
            int[] tab = new int[256];

            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    tab[Xtab[i, j]]++;
                }
            }
            
            return tab;
        }

        /* MoyTab2D :   fonc    :   int :   return la valeur moyenne d'un tableau 2D
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  
         * LOCAL :
         *  moyenne :   int     :   valeur moyenne courante
         * 
         * RETOUR :
         *  moyenne :   int     :   valeur moyenne du tableau
         */
        public static int MoyTab2D(int[,] Xtab)
        {
            int moyenne = 0;
            for (int i = 0; i<Xtab.GetLength(0); i++)
            {
                for (int j = 0; j<Xtab.GetLength(1); j++)
                {
                    moyenne = moyenne + Xtab[i, j];
                }
            }
            moyenne = moyenne / ((Xtab.GetLength(0) - 1) * (Xtab.GetLength(1) - 1));

            return moyenne;
        }

        /* MinTab2D :   fonc    :   int :   return la valeur min d'un tableau 2D
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  
         * LOCAL :
         *  min     :   int     :   valeur min courante
         * 
         * RETOUR :
         *  min     :   int     :   valeur min du tableau
         */
        public static int MinTab2D(int[,] Xtab)
        {
            int min = Xtab[0,0];
            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    if (Xtab[i, j] < min)
                    {
                        min = Xtab[i, j];
                    }
                    else { /* Rien */ }
                }
            }

            return min;
        }

        /* MaxTab2D :   fonc    :   int :   return la valeur max d'un tableau 2D
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]  :   tableau 2D
         *  
         * LOCAL :
         *  max     :   int     :   valeur max courante
         * 
         * RETOUR :
         *  max     :   int     :   valeur max du tableau
         */
        public static int MaxTab2D(int[,] Xtab)
        {
            int max = Xtab[0, 0];
            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    if (Xtab[i, j] > max)
                    {
                        max = Xtab[i, j];
                    }
                    else { /* Rien */ }
                }
            }

            return max;
        }

        /* AfficheTab2D :   proc    :   affiche un tableau 2D donné en param
         * 
         * PARAMETRES :
         *  Xtab    :   int[,]   :   tableau 2D
         *  
         * LOCAL :
         * 
         * RETOUR :
         */

        public static void AfficheTab1D(int[] Xtab)
        {
            for (int i = 0; i<Xtab.Length; i++)
            {
                Console.Write(Xtab[i] + " ");
            }
            Console.WriteLine("");
        }
        public static void AfficheTab2D(int[,] Xtab)
        {
            for (int i = -1; i<Xtab.GetLength(0); i++)
            {
                Console.Write(i + "\t[\t");
                for (int j = 0; i==-1 && j<Xtab.GetLength(1); j++)
                {
                    Console.Write(j + "\t");
                }
                for (int j = 0; i!=-1 && j<Xtab.GetLength(1); j++)
                {
                    Console.Write(Xtab[i,j] + "\t");
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }

        /* CreaRndTab2D :   fonc    :   créé un tableau 2D
         * 
         * PARAMETRES :
         *  Xcolonnes   :   int :   nombre de colonnes
         *  Xlignes     :   int :   nombre de lignes
         *  Xmin        :   int :   valeur min
         *  Xmax        :   int :   valeur max
         *  
         * LOCAL :
         *  tab         :   int[,]  :   tableau 2D
         *  rd          :   random  :   
         *  
         * RETOUR :
         *  tab         :   int[,]  :   tableau 2D
         */
        public static int[,] CreaRndTab2D(int Xcolonnes, int Xlignes, int Xmin, int Xmax)
        {
            int[,] tab = new int[Xlignes, Xcolonnes];
            Random rd = new Random();

            for (int i = 0; i<Xlignes; i++)
            {
                for (int j = 0; j<Xcolonnes; j++)
                {
                    tab[i, j] = rd.Next(Xmin, Xmax + 1);
                }
            }

            return tab;
        }

        public static void InitRayeTab2D(int[,] Xtab)
        {
            for (int i = 0; i<Xtab.GetLength(0); i++)
            {
                for (int j = 0; j<Xtab.GetLength(1); j++)
                {
                    if ( i%2 == 1)
                    {
                        Xtab[i, j] = 1;
                    }
                    else
                    {
                        Xtab[i, j] = 0;
                    }
                }
            }
        }

        public static void InitDiagTab2D(int[,] Xtab)
        {
            for (int i = 0; i < Xtab.GetLength(0); i++)
            {
                for (int j = 0; j < Xtab.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Xtab[i, j] = 1;
                    }
                    else if (j == Xtab.GetLength(1) - 1 - i)
                    {
                        Xtab[i, j] = 1;
                    }
                    else
                    {
                        Xtab[i, j] = 0;
                    }
                }
            }
        }

        public static int[,] ClonageTab2D(int[,] Xtab)
        {
            int[,] tabClone = new int[Xtab.GetLength(0) - 1, Xtab.GetLength(1) - 1];

            for (int i = 0; i<Xtab.GetLength(0); i++)
            {
                for (int j = 0; j<Xtab.GetLength(1); j++)
                {
                    tabClone[i, j] = Xtab[i, j];
                }
            }

            return tabClone;
        }

        //============================================================================

        public static int[,] TabFromFile(string file)
        {
            Bitmap img = new Bitmap(file);
            int[,] tabImage = ImageToInt(img);
            return tabImage;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static int[,] ImageToInt(Bitmap img)
        {
            int largeur = img.Width;
            int hauteur = img.Height;
            int[,] tab = new int[hauteur, largeur];
            for (int lig = 0; lig < hauteur; lig++)
            {
                for (int col = 0; col < largeur; col++)
                {
                    Color c = img.GetPixel(lig, col);

                    tab[lig, col] = (int)c.R;
                }
            }
            return tab;
        }

        public static void IntToImage(int[,] tab, Bitmap img)
        {

            int largeur = tab.GetLength(1);
            int hauteur = tab.GetLength(0);
            for (int lig = 0; lig < hauteur; lig++)
            {
                for (int col = 0; col < largeur; col++)
                {
                    Color c = Color.FromArgb(255, tab[lig, col], tab[lig, col], tab[lig, col]);
                    img.SetPixel(lig, col, c);
                }
            }

        }

        public static void saveImage(int[,] tab, string file)
        {
            Bitmap img = new Bitmap(tab.GetLength(1), tab.GetLength(0));

            IntToImage(tab, img);
            img.Save(file);
            Console.WriteLine("Saugarde dans le fichier : " + file);
        }

        public static void affiche_image(int[,] tab)
        {
            Bitmap img = new Bitmap(tab.GetLength(1), tab.GetLength(0));

            IntToImage(tab, img);
            Form f = new Form();
            f.BackgroundImage = img;
            f.Width = img.Width;
            f.Height = img.Height;
            //PictureBox pc = new PictureBox();
            //pc.Image = (Image)img;
            //f.Controls.Add(pc);
            f.Show();

        }
        public static void affiche_histo(int[] tab)
        {
            int max1 = max1D(tab);
            int histHeight = 128;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    float pct = tab[i] / ((float)max1);   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }
            // Bitmap img = new Bitmap(tab.GetLength(1), tab.GetLength(0));

            //IntToImage(tab, img);
            Form f = new Form();
            f.BackgroundImage = img;
            f.Width = img.Width;
            f.Height = img.Height;
            //PictureBox pc = new PictureBox();
            //pc.Image = (Image)img;
            //f.Controls.Add(pc);
            f.Show();

        }

        public static int max1D(int[] tab)
        {
            int maxi = tab[0];
            int hauteur = tab.Length;
            for (int lig = 0; lig < hauteur; lig++)
            {
                if (maxi < tab[lig])
                {
                    maxi = tab[lig];
                }
            }
            return maxi;
        }
    }
}
