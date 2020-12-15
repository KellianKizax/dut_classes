package Anciens;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;

public class Main_TDTP1 {

    /**
     * Recursive method that return the greatest common divisor between two number.
     *
     * @param a First number
     * @param b Second number
     * @return Greatest common divisor of 'a' and 'b'
     */
    public static int pgcd( int a, int b ) {
        int res;

        if ( b==0 )
            res = a;
        else
            res = pgcd( b, a%b );

        return res;
    }

    /**
     * Recursive method that return the factorial of a number.
     * @param n Number
     * @return Factorial of 'n'
     */
    public static long Fact( long n ) {
        long res;

        if ( n == 0 )
            res = 1;
        else
            res = Fact( n-1 ) * n;

        return res;
    }

    /**
     * Recursive method for the exponential
     * @param n .
     * @param p .
     * @return .
     */
    public static BigInteger Expo( int n, int p ) {
        BigInteger res;

        if ( p == 0 )
            res = BigInteger.ONE;
        else if (n < 0)
            res = BigInteger.ONE.divide(Expo(n, -p));
        else if (p % 2 == 0) // p est pair
            res = Expo( n, p/2 ).multiply( Expo( n, p/2 ) );
        else
            res = BigInteger.valueOf(n).multiply( Expo( n, p-1 ) );

        return res;
    }

    /**
     * Write an integer into binary
     * @param n Integer number
     * @return Int 'n' into binary
     */
    public static String intToBinary( int n ) {
        String res = "";

        if( n == 0 || n == 1 )
            res += n;
        else
            res = intToBinary( n/2 ) + ( n % 2 );

        return res;
    }

    public static String Mirror( String s ) {
        String res;
        int len = s.length();

        if ( len == 0 )
            res = "";
        else
            res = s.charAt( len - 1) + Mirror( s.substring( 0, len - 1 ) );

        return res;
    }

    /**
     * Recursive method that return the indice of an item in a sorted array in ascending order
     * @param sorted_array int array
     * @param x int to find
     * @param ind_min indice min of the search in the array
     * @param ind_max indice max of the search in the array
     * @return indice of 'x' in 'tab_trie'
     */
    public static int findDicho( int[] sorted_array, int x, int ind_min, int ind_max ) {
        int res;
        int len = ind_max - ind_min + 1;

        if ( sorted_array[0] == x )
            res = 0;
        else
            if ( sorted_array[len/2] == x )
                res = len/2;
            else if ( sorted_array[len/2] > x )
                res = findDicho( sorted_array, x, ind_min, len/2 );
            else
                res = findDicho( sorted_array, x, len/2, ind_max );

        return res;
    }

    /**
     * Merge two ArrayList of Integers sorted in ascending order
     * @param list_a First list of Integers
     * @param list_b Second list of Integers
     * @param start_indice_a Starting indice for 'list_a'
     * @param start_indice_b Starting indice for 'list_b'
     * @return Arraylist of Integers with all the items of 'list_a' and 'list_b' sorted in ascending order
     */
    public static ArrayList<Integer> ArrayListIntegerMerger( ArrayList<Integer> list_a, ArrayList<Integer> list_b, int start_indice_a, int start_indice_b ) {
        ArrayList<Integer> res = new ArrayList<Integer>();

        if ( !( start_indice_a >= list_a.size() && start_indice_b >= list_b.size() ) ) {
            int a = list_a.get(start_indice_a);
            int b = list_b.get(start_indice_b);

            if ( a < b ) {
                start_indice_a++;
                res.add(a);
                res.addAll( ArrayListIntegerMerger( list_a, list_b, start_indice_a, start_indice_b ) );
            }
            else if ( a > b ) {
                start_indice_b++;
                res.add(b);
                res.addAll( ArrayListIntegerMerger( list_a, list_b, start_indice_a, start_indice_b ) );
            }
            else {
                start_indice_a++;
                res.add(a);
                start_indice_b++;
                res.add(b);
                res.addAll( ArrayListIntegerMerger( list_a, list_b, start_indice_a, start_indice_b ) );
            }
        }

        return res;
    }

    private static ArrayList<String> subsequencesAfter( String partialSubsequence, String word )
    {
        ArrayList<String> res = new ArrayList<String>();
        if ( word.isEmpty() )
        {
            res.add(partialSubsequence);
        }
        else
        {
            res.addAll( subsequencesAfter( partialSubsequence, word.substring(1) ) );

            partialSubsequence += word.charAt(0);
            res.addAll( subsequencesAfter( partialSubsequence, word.substring(1) ) );
        }

        return res;
    }

    /**
     * Return an arraylist which contain all the sub sequences possible in the parameter 'word'
     * @param word a string
     * @return all subsequences from 'word'
     */
    public static ArrayList<String> subsequences(String word)
    {
        return subsequencesAfter( "", word );
    }

    /* subsequences( "abc" )
    *  \ - subsequencesAfter( "", "abc" )
    *    \ - subsequencesAfter( "", "bc" )                                             \ - subsequencesAfter( "a", "bc")
    *      \ - sA( "", "c" )                      \ - sA( "b", "c")                      \ - sA("a","c")                    \ - sA("ab","c")
    *        \ - sA( "", "" ) \ - sA( "c", "" )     \ - sA( "b", "") \ - sA("bc", "")      \ - sA("a", "") \ - sA("ac","")    \ - sA("ab", "") \ - sA("abc", "")
    * return         ""               "c"                     "b"             "bc"                 "a"            "ac"             "ab"                    "abc"
    *
    * return {"","c","b","bc","a","ac","ab","abc"}
    */

    // ===================================================================================================================================================

    public static void main( String[] args ){

        // pgcd
        System.out.println( pgcd( 57, 95 ) );

        // Fact
        System.out.println( Fact( 4 ) );

        // Expo
        System.out.println( Expo( 2, 2 ) );

        // intToBinary
        System.out.println( intToBinary( 7 ) );

        // Mirror
        System.out.println( Mirror( "Mirroir" ) );

        // findDicho
        System.out.println( findDicho( new int[] {0,1,2,3,4,5,6} , 3, 0, 6 ) );

        // ArrayListMerger
        ArrayList<Integer> list1 = new ArrayList<>();
        ArrayList<Integer> list2 = new ArrayList<>();
        list1.add(0); list1.add(1); list1.add(2); list1.add(3);
        list2.add(0); list2.add(1); list2.add(2); list2.add(3);

        System.out.println( ArrayListIntegerMerger( list1, list2, 0, 0 ) );

        // subsequences
        System.out.println( subsequences("abc"));

    }
}
