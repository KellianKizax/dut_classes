
#ifndef arithm_h
#define arithm_h

#include <stdio.h>
#include <math.h>
#include <time.h>
#include <limits.h>
#include <stdint.h>
#include <stdlib.h>
#include <ctype.h>


typedef  struct coeff_EB {
    uint32_t a;
    uint32_t b;
    int64_t u;
    int64_t v;
    uint32_t gcd;
} EB;

uint32_t crible(uint32_t N, uint32_t* prime_tab);
uint32_t fast_exp(uint32_t a,  uint32_t k, uint32_t n);
EB bezout(uint32_t a, uint32_t b);
uint32_t modular_inv(uint32_t a, uint32_t n);
int64_t chinese_remainder(uint32_t t, uint32_t s, uint32_t a, uint32_t b);

char MR_witness(uint32_t n, uint32_t m, int s, uint32_t a);
uint32_t MR_prime(int k, float epsilon);
uint32_t primitive_root(uint32_t p);
uint32_t discrete_log(uint32_t a, uint32_t g,uint32_t p);



#endif /* arithm_h */
