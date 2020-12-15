package Semaine_14_dec;

import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertEquals;

import Semaine_30_nov.Arbin;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;


@DisplayName("ArbinTest4: Test de propriétés de grands arbres générés aléatoirement.")
public class ArbinTest4 
{
    private static Random rand;

    private static Arbin<Integer> aVide = ArbinR.getInstance();

    @BeforeEach
    public void setUp() 
    {
        aVide = ArbinFactory.getInstance();
//        rand = new Random(456789911);
        rand = new Random();
    }

    @Test
    @DisplayName("Arbres filiformes")
    public void testFiliforme()
    {
        int n = 1000;
        Arbin<Integer> a = aVide;
        for (int i = 0; i <= n; i++)
        {
            assertTrue(a.estFiliforme());
            assertEquals(i, a.taille());
            assertEquals(Math.min(i, 1), a.nbFeuilles());
            assertEquals(i, a.profondeur());
            assertTrue(a.estVide() || a.ag().estVide() || a.ad().estVide());
            assertEquals(i < 2, a.estHomogene());
            assertEquals(i < 2, a.estComplet());
            assertEquals(i <= 2, a.estEquilibre());
            assertEquals((i < 2) || (i == 2 && a.ad().estVide()),
                    a.estParfait(), "estParfait");
            
            int rac = rand.nextInt(10*n);
            if (rand.nextBoolean())
                a = a.initArbin(rac, a, aVide);
            else
                a = a.initArbin(rac, aVide, a);
        }
    }
    
    private static <T> Arbin<T> insererAleatHomogene(Arbin<T> a, int pos, T v1, T v2)
    {
        Arbin<T> res;
        
        if (a.estVide())
            throw new IllegalArgumentException();
        
        if (a.ag().estVide() && a.ad().estVide())
        {
            res = a.initArbin(a.racine(), a.initArbin(v1), a.initArbin(v2));
        }
        else if (pos == 0)
        {
            if (rand.nextBoolean()) 
                res = a.initArbin(v1, a, a.initArbin(v2));
            else
                res = a.initArbin(v1, a.initArbin(v2), a);
        }
        else if (pos %2 == 0)
            res = a.initArbin(a.racine(), insererAleatHomogene(a.ag(), pos / 2, v1, v2), a.ad());
        else 
            res = a.initArbin(a.racine(), a.ag(), insererAleatHomogene(a.ad(), pos / 2, v1, v2));
        return res;
    }


    @Test
    @DisplayName("Arbres homogènes")
    public void testHomogene()
    {
        int n = 1000;
        Arbin<Integer> a = aVide.initArbin(rand.nextInt(10*n));

        for (int i = 1; i <= n; i+= 2)
        {
            assertTrue(a.estHomogene());
            assertEquals(i == 1, a.estFiliforme());
            assertEquals(i, a.taille());
            assertEquals(i/2 + 1, a.nbFeuilles());
            assertEquals(1+Math.max(a.ag().profondeur(),a.ad().profondeur()),
                a.profondeur());
            assertEquals(i > 1, !a.ag().estVide() && !a.ad().estVide());

            int v1 = rand.nextInt(10*n);
            int v2 = rand.nextInt(10*n);
            a = insererAleatHomogene(a, rand.nextInt(i), v1, v2);
        }
    }

    private static <T> Arbin<T> insererAleatEquilibre(Arbin<T> a, T v)
    {
        Arbin<T> g;
        Arbin<T> d;
        T rac;
        
        if (a.estVide())
        {
            g = a.initArbin();
            d = a.initArbin();
            rac = v;
        }
        else
        {
            rac = a.racine();
            int desequilibre = a.ag().profondeur() - a.ad().profondeur();
            if (desequilibre == 0)
            {
                desequilibre = rand.nextBoolean() ? -1 : 1;
            }
            if (desequilibre == -1)
            {
                g = insererAleatEquilibre(a.ag(), v);
                d = a.ad();
            }
            else
            {
                g = a.ag();
                d = insererAleatEquilibre(a.ad(), v);
            }
        }
        return a.initArbin(rac, g, d);
    }

    @Test
    @DisplayName("Arbres équilibrés")
    public void testEquilibre()
    {
        int n = 1000;
        Arbin<Integer> a = aVide;

        for (int i = 0; i <= n; i++)
        {
            assertTrue(a.estEquilibre());
            assertEquals(i <= 2, a.estFiliforme());
            assertEquals(i, a.taille());
            assertTrue(a.estVide() ||
                    a.profondeur() == 1 + Math.max(a.ag().profondeur(), a.ad().profondeur()));
            assertEquals(i > 2, !a.estVide() && !a.ag().estVide() && !a.ad().estVide());
            
            a = insererAleatEquilibre(a, rand.nextInt(10*n));
        }
    }
    
    private static <T> List<Integer> lister(int pos)
    {
        List<Integer> res;
        if (pos == 1)
        {
            res = new ArrayList<>();
            res.add(1);
        }
        else
        {
            res = lister(pos/2);
            res.add(pos%2);
        }
        return res;
    }
    
    private static <T> Arbin<T> creer(Arbin<T> a, List<Integer> lPos, T v)
    {
        Arbin<T> res;
        if (lPos.isEmpty() && !a.estVide())
            throw new IllegalArgumentException();
        if (!lPos.isEmpty() && a.estVide())
            throw new IllegalArgumentException();
        

        if (a.estVide())
            res = a.initArbin(v);
        else 
        {
            int direction = lPos.get(0);
            if (direction == 0)
            {           
                res = a.initArbin(a.racine(), creer(a.ag(), lPos.subList(1, lPos.size()), v), a.ad());
            }
            else 
                res = a.initArbin(a.racine(), a.ag(), creer(a.ad(), lPos.subList(1, lPos.size()), v));
        }
        return res;
    }

    
    private static <T> Arbin<T> creer(Arbin<T> a, int pos, T v)
    {
        Arbin<T> res;
        if (pos == 1 && !a.estVide())
            throw new IllegalArgumentException();
        if (pos != 1 && a.estVide())
            throw new IllegalArgumentException();
        

        if (a.estVide())
            res = a.initArbin(v);
        else 
        {
            List<Integer> ch = lister(pos);
            res = creer(a, ch.subList(1, ch.size()), v);
        }
        return res;
    }



    @Test
    @DisplayName("Arbres complets ou parfaits")
    public void testCompletParfait()
    {
        int n = 1000;
        Arbin<Integer> a = aVide;
        int largeur = 1;
        int profondeur = 1;
        for (int i = 1; i <= n; i++)
        {
            a = creer(a, i, rand.nextInt(10*n));

            assertEquals(i, a.taille());
            assertEquals((i+1)/2, a.nbFeuilles(), a.toString());
            assertTrue(a.estParfait(), a.toString());
            assertTrue(a.ag().estParfait());
            assertTrue(a.ad().estParfait());    		
            assertTrue(a.estEquilibre());
            assertEquals(i <= 2, a.estFiliforme());

            int prg = a.ag().profondeur();
            int prd = a.ad().profondeur();
            assertEquals(profondeur, a.profondeur());
            assertEquals(profondeur-1, prg);

            if (i == 2 * largeur - 1)
            {
                //System.out.println(a);
                assertTrue(prd == prg);
                assertTrue(a.ag().estComplet());
                assertTrue(a.ad().estComplet());
                assertTrue(a.estComplet());
                largeur *= 2;
                profondeur++;
            }
            else
            {
                assertFalse(a.estComplet());
                assertTrue(prd == prg || prd == prg-1);
                
                assertTrue(prg != prd ||  
                        a.ag().estComplet());
                assertTrue(prg != prd + 1 || 
                        a.ad().estComplet());
            }

        }
    }
    /**/
}
