package Semaine_14_dec;

import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.junit.jupiter.api.Assertions.assertAll;
import static org.junit.jupiter.api.Assertions.assertEquals;

import Semaine_30_nov.Arbin;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;


import java.util.List;
import java.util.Random;
import java.util.ArrayList;

@DisplayName("ArbinTest5: Test de propriétés d'un grand arbre binaire trié.")
public class ArbinTest5 
{
    static Arbin<Integer> a = ArbinFactory.getInstance();
    static final int n = 10000;
//    int n = 4;
    
    @BeforeAll 
    public static void setUp() 
    {

//    	Random r = new Random(456789911);
        Random r = new Random();
    	r.ints(0, 10*n).distinct().limit(n).
    		forEach(i -> { a = placer(a, i); });
        // for (int i = 0; i < n; i++)
        // {
        //     a = Arbin.placer(a, r.nextInt(10*n));
        // }
        System.out.println("Nb Noeuds: " + n);
        System.out.println("Profondeur: " + a.profondeur());
        System.out.println("Nb Feuilles: " + a.nbFeuilles());
        System.out.println(a.afficherPrefixe());
    }
    
    static <T extends Comparable<T>> Arbin<T> placer(Arbin<T> a, T val)
    {
        Arbin<T> res;
        if (a.estVide())
            res = a.initArbin(val);
        else
        {
            Arbin<T> g = a.ag();
            Arbin<T> d = a.ad();
            if (val.compareTo(a.racine()) <= 0)
              g = placer(a.ag(), val);
            else
              d = placer(a.ad(), val);
            res = a.initArbin(a.racine(), g, d);
        }
        return res;
    }

    
    @Test
    @DisplayName("La propriété estVide() est valide.")
    public void testEstVide()
    {
        assertEquals(n == 0, a.estVide());
    }
    
    @Test
    @DisplayName("La taille est valide.")
    public void testTaille()
    {
        assertEquals(n, a.taille());
    }

	
    @Test
    @DisplayName("La profondeur est valide.")
    public void testProfondeur()
    {
        assertEquals(n != 0,  
                a.profondeur() == 1 + Math.max(a.ag().profondeur(), a.ad().profondeur())
        		);
    }
	
    @Test
    @DisplayName("Le nombre de feuilles est valide.")
    public void testNbFeuilles()
    {
        assertEquals(n != 0,  
                a.nbFeuilles() == a.ag().nbFeuilles() + a.ad().nbFeuilles()
        		);
    }
    
    @Test
    @DisplayName("Le nombre de noeuds est valide.")
    public void testNbNoeudsR()
    {
        assertEquals(n != 0,  
                a.taille() == 1 + a.ag().taille() + a.ad().taille()
        		);
    }
	
    @Test
    @DisplayName("La propriété estFiliforme() est valide.")
    public void testEstFiliforme()
    {
        assertEquals(n == 1, a.estFiliforme());
    }
		
    @Test
    @DisplayName("La propriété estComplet() est valide.")
    public void testEstComplet()
    {
        int p = a.profondeur();
        int p2 = 1 << p;
        assertEquals(n == (p2-1), a.estComplet());
    }
	
	
    @Test
    @DisplayName("La propriété estParfait() est valide.")
    public void testEstParfait()
    {
        int prg = a.ag().profondeur();
        int prd = a.ad().profondeur();
        assertEquals(
                (prg == prd + 1 && a.ag().estParfait() && a.ad().estComplet())
                || (prg == prd && a.ag().estComplet() && a.ad().estParfait()),
                a.estParfait());
    }	

    
    @Test
    @DisplayName("Le parcours infixé (GRD) est valide.")
    public void testGRD()
    {
    	int old_i = Integer.MIN_VALUE;
        for (int i : a.parcoursInfixe())
        {
            assertTrue(i >= old_i, " i = " + i + " old_i = " + old_i);
            old_i = i;
        }
    }
    
    @Test
    @DisplayName("afficherPrefixe-saisirPrefixe est cohérent.")
    public void testAfficherPrefixe()
    {
        String s = a.afficherPrefixe();
        Arbin<String> as = a.saisirPrefixe(s);        
        assertEquals(s, as.afficherPrefixe(), "afficherPrefixe");
    }

    public static Arbin<Integer> toInt(Arbin<String> a)
    {
        Arbin<Integer> res;
        if (a.estVide())
            res = a.initArbin();
        else
            res = a.initArbin(Integer.valueOf(a.racine()), toInt(a.ag()), toInt(a.ad()));
        return res;        
    }
    
    @Test
    @DisplayName("égalité après afficherPrefixe-saisirPrefixe.")
    public void testAfficherPrefixeEgal()
    {
        String s = a.afficherPrefixe();
        Arbin<String> as = a.saisirPrefixe(s);
        Arbin<Integer> asi = toInt(as);
        assertEquals(a, asi, "égalité");
    }

    @Test 
    @DisplayName("La création de l'arbre avec les listes préfixées et infixées est valide.")
    public void testCreerArbinPreInf()
    {
        List<Integer> pre = new ArrayList<Integer>();
        a.parcoursPrefixe().forEach(i -> pre.add(i));
        List<Integer> inf = new ArrayList<Integer>();
        a.parcoursInfixe().forEach(i -> inf.add(i));
        Arbin<Integer> as = a.creerArbinPreInf(pre, inf);
        assertAll(
                () -> assertTrue(a.equals(as)),
                () -> assertEquals(a.afficherPrefixe(), as.afficherPrefixe()));
    }	
}