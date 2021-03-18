
#include "arithm.h"

/***************************************
------------     Crible    -------------
****************************************
* écrit dans prime_tab les nombres premiers plus petits que N
* où N est positif représentable sur 32 bits
*/

uint32_t crible(uint32_t N, uint32_t* prime_tab){

    char* Tab = calloc( N+1, 1);
    uint32_t k=2;

    while ( k*k <= N)
    { 
        for (size_t i = k; k*i <= N; i++)
        {
            Tab[ k*i ]=1;
        }
        k++;
        while(Tab[k]) k++;     
    }
    uint32_t nb_prime=0;
    for (size_t i = 2; i < N+1; i++)
    {
        if ( !Tab[i] )
        {
            prime_tab[nb_prime] = i;
            nb_prime++;
        }        
    }
    free(Tab);
    return nb_prime;
}

/***************************************
------------ Euclide-Bézout-------------
****************************************
* a,b et le pgcd sont des entiers postifs représentables sur 32 bits
* u et v sont en revanche des entiers signés (donc sur 64 bits, pour avoir la 
* place du bit de signe)
* la variable tmp doit être signée aussi pour un résultat cohérent
*/

EB bezout(uint32_t a, uint32_t b){
    
    uint32_t r_0=a, r_1=b;
    int64_t u_0=1, u_1=0;
    int64_t v_0=0, v_1=1;
    uint32_t q,r;
    int64_t tmp;
    while (r_1>0) {
        q=r_0 / r_1;
        r=r_0 % r_1;
        r_0=r_1;
        r_1=r;
        tmp=u_0;
        u_0=u_1;
        u_1=tmp-q*u_1;
        tmp=v_0;
        v_0=v_1;
        v_1=tmp-q*v_1;
    }
    EB coeff_bezout={a, b, u_0, v_0, r_0};
    return coeff_bezout;
}

/***************************************
----------- Inverse modulaire-----------
****************************************
* on gère les modules représentables sur un uint32_t
* et on renvoie le plus petit représentant strictement positif de l'inverse
* et 0 si l'argument n'est pas inversible
*/
uint32_t modular_inv(uint32_t a, uint32_t n){

    EB coeff_bezout = bezout( a, n);

    if (coeff_bezout.gcd != 1)
    {
        return 0;
    }

    int64_t inverse=coeff_bezout.u;
    
    while (inverse<0)
    {
        inverse+=n;
    }

    return inverse;
}

/***************************************
------- Exponentiation rapide  ---------
****************************************
* ça doit supporter l'exponentiation de a^k mod n, avec n un uint32_t
* les résultats sont donnés par le plus petit représentant positif
*/

uint32_t fast_exp(uint32_t a,  uint32_t k, uint32_t n){
    uint32_t bin_exp=k;
    uint64_t exp=1;
    uint64_t puissance=(a % n);

    while (bin_exp) {
        //printf("exp : %llx\n",exp);
        if ( bin_exp&1 ) {
            exp=((exp*puissance) % n);
        }
        puissance=(puissance*puissance) % n;
        bin_exp=(bin_exp)>>1;
    }
    return exp % n;
}

/***************************************
----------    Théo chinois  ------------
****************************************
* calcul du reste chinois x [ab] pour le système x=s [a] et x=t [b]
* (au moyen d'Euclide étendu)
* le produit ab (module final) est un entier positif représentable sur 32 bits
* si ab n'est pas représentable sur 32 bits, ou si a et b ne sont pas premiers
* entre eux on renvoie -1 d'où l'usage d'un int64_t
*/
int64_t chinese_remainder(uint32_t s, uint32_t t, uint32_t a, uint32_t b ){

    int64_t ab = (int64_t) a*b;
    if (ab>>32)
    {
        return -1;
    }
    EB resEB=bezout(a, b); 
    if (resEB.gcd != 1)
    {
        return -1;
    }
    int64_t res =  ((int64_t) s) * resEB.b*resEB.v + t*resEB.a*resEB.u ;
    printf("res brut %lld\n", res);

    while (res<0)
    {
        res+= a*b;
    }
    printf("res normalisé %lld\n", res);
    return res;   
}

/***************************************
----------   Miller - Rabin  -----------
****************************************/
/*
* Test de Miller-Rabin pour l'entier n tel que n - 1 = m * 2^s, avec m impair,
*  et le témoin a
* renvoie 1 ou 0 selon que a est un témoin de Miller-Rabin pour n, ou non
*/
char MR_witness(uint32_t n, uint32_t m, int s, uint32_t a){
  uint32_t b=fast_exp(a,m,n);
    if (b==1) {
        //printf("test a^m = 1\n");
        return 1;
    }
    int i;
    for (i=0; i < s; i++) {
        if (b==(n-1)) {
            //printf("test a^(2^ell m) = 1, avec ell= %d\n", i);
            return 1;
        } else {
            b=b*b %n;
        }
    }
    return 0;
}

uint32_t MR_prime(int k, float epsilon){

    //calcul de 2^(k-1)
    uint32_t puiss2=1;
    int i;
    for (i=0; i<k-1; i++) {
        puiss2*=2;
    }
    uint32_t premier=0;
    //calcul du nombre l de témoins nécessaires pour garantir epsilon
    int l=1, pow=4;
    while ( pow < 1/epsilon ) {
        l++;
        pow*=pow;
    }
    int nb_temoins=0;
    // boucle tant qu'on n'a pas trouvé premier
    while (nb_temoins<l) {
        nb_temoins=0;
        //tirage au sort du candidat, qui doit être impair
        premier=floor(puiss2*(1+ ((float) rand()/RAND_MAX )));
        if (!(premier%2)) {
            premier++;
        }
        //écriture n-1=2^j*m avec m impair
        int j=1;
        uint32_t m= (premier-1) / 2;
        while ( !(m % 2) ) {
            j++;
            m=m/2;
        }
        //tirage au sort du témoin
        uint32_t a= rand() % premier;
        //boucle de tests
        while (MR_witness(premier,m,j,a)) {
            nb_temoins++;
            a++;
        }
    }
    return premier;
} 


/*****************************************************
----------   Plus petit élément primitif   -----------
******************************************************/

uint32_t primitive_root(uint32_t p){

    uint32_t candidate = 2;
    uint32_t primitive_root=0;
    while( !primitive_root && candidate < p-1){
        uint32_t power=candidate;
        uint32_t exponent = 1;
        while ( power != 1 && exponent < p)
        {
            power = (power*candidate) %p;
            exponent++;
        }
        if (exponent == p-1)
        {
            primitive_root = candidate;
        }
        candidate++;
    };
    return primitive_root;
}

/************************************************
----------     Logarithme discret     -----------
*************************************************/

uint32_t discrete_log(uint32_t a, uint32_t g,uint32_t p){

    uint32_t power= g;
    uint32_t log = 1;
    
    while (power != a && log < p)
    {
        power = (power*g) % p;
        log++;
    }
    return log==p? 0: log;
}



