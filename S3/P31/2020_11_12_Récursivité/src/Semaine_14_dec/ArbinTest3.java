package Semaine_14_dec;

import static org.junit.jupiter.api.Assertions.assertEquals;

import Semaine_30_nov.Arbin;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;

import java.util.Arrays;

@DisplayName("ArbinTest3: Test de l'arbre binaire '10,5,2,,,7,4,,,,20,15,,,25,,'")
public class ArbinTest3 
{	
    Arbin<String> a = ArbinFactory.getInstance();
    String s;
   
    @BeforeEach
    public void setUp() 
    {
        a = a.initArbin("10",
                a.initArbin("5",
                    a.initArbin("2"),
                    a.initArbin("7",
                        a.initArbin("4"),
                        a.initArbin()
                    )
                ),
                a.initArbin("20",
                    a.initArbin("15"),
                    a.initArbin("25")
                )
            );
        s = "10,5,2,,,7,4,,,,20,15,,,25,,";
    }
    
    @Test
    @DisplayName("Le résultat de afficherPrefixe est valide.")
    public void testAfficherPrefixe()
    {
        assertEquals(s, a.afficherPrefixe());
    }

    @Test
    @DisplayName("Le résultat de saisirPrefixe est valide.")
    public void testSaisirPrefixe()
    {
        Arbin<String> as = a.saisirPrefixe(s);
        assertEquals(s, as.afficherPrefixe());
    }
		
    @Test
    @DisplayName("Le résultat de creerArbinPreInf est valide.")
    public void testCreerInfPre()
    {
        String sPre = "10,5,2,7,4,20,15,25";
        String sInf = "2,5,4,7,10,15,20,25";
        String[] tsPre = sPre.split(",", -1);
        String[] tsInf = sInf.split(",", -1);
        String s = a.creerArbinPreInf(
                Arrays.asList(tsPre), 
                Arrays.asList(tsInf))
                .afficherPrefixe();
        assertEquals(sPre, s.substring(0, s.length()-2)
                            .replace(" ", "")
                            .replaceAll(",+", ","));
    }
	

}