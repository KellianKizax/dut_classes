#ifndef __TPM11__

#define __TPM11__

void conversion(unsigned long n, unsigned int b);
void comptage(unsigned int b);

void encodage_non_signe(unsigned long n, unsigned int nb_octets);
void encodage_signe(long n, unsigned int nb_octets);



#endif