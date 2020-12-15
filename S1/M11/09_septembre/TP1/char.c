#include <stdio.h>

int main()
{
    printf("entier : %d \n", 'a');
    printf("char : %c \n", 'a');
    
    char var = '\0';
    char var2 = '1' * 1;
    char var3 = '1' * '1';
    printf("entier : %d %d %d \n", var, var2, var3);
    printf("char : %c %c %c \n", var, var2, var3);

    return 0;
}