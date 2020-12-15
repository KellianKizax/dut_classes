#!/bin/sh
# script liredate.sh

# script de saisie d'une DATE au format jj/mm/aaaa (une seule chaine) avec
# recuperation ds 3 variables 

# redefinition de la variable IFS (Internal Field Separator)
IFS=/

echo -n  "Entrez date au format jj/mm/aaaa: "

read jour mois annee
# nb : pas de verification sur les valeurs saisies !

echo "jour= $jour mois= $mois annee= $annee"

