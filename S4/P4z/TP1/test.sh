#!/bin/bash

# author: Thibault CLAUSS , Kellian GOFFIC          12/02/2021
# usage: ./test.sh <taille tableau> <nb répétitions>


# Script de test des performances
# pour chaque tri (insertion, fusion, rapide),
#   - pour un tableau non trié, trié dans l'ordre décroissant,
#   - partiellement trié pour différentes proportions de tri
#   - pour des tailles de tableaux différentes

# ./main <tab size> <random|sorted|reverse-sort> <percent sorted> <insertion|merge|quick>
# /usr/bin/time -f "%U User , %S Systeme , %E Elapsed , %M Memory"


# Vérification des paramètres
if [ $# != 4 ]
then
    echo "Usage: " $0 " <nb répétitions> <taille min> <taille max> <increment>"
    exit 1
fi

NB_REPEATS=$1
TAB_MIN=$2
TAB_MAX=$3
INCREMENT=$4

SORT_TYPES=( "insertion" "merge" "quick" )
TAB_TYPES=( "random" "partlysorted" "reversed" )

# Pour les tableaux partiellement triés
#PERCENTS_SORTED=( "0.10" "0.25" "0.50" "0.75" "0.90" )
PERCENTS_SORTED=( "0.50" )

echo -ne "SortType\tTabSize\tTabType\tPercentSort\tSortTime\tUserTime\tSystemTime\tMemory\n" > res.csv

for sort_type in "${SORT_TYPES[@]}"
do
    for tab_size in `seq $TAB_MIN $INCREMENT $TAB_MAX`
    do
        for tab_type in "${TAB_TYPES[@]}"
        do

            if [ $tab_type == "partlysorted" ]
            then
                for percent in "${PERCENTS_SORTED[@]}"
                do
                    for i in `seq $NB_REPEATS`
                    do
                        echo -ne "$sort_type\t$tab_size\t$tab_type\t$percent\t" >> res.csv
                        /usr/bin/time -aores.csv -f "%U\t%S\t%M" ./main $tab_size $tab_type $percent $sort_type >> res.csv
                    done
                done

            else
                for i in `seq $NB_REPEATS`
                do
                    echo -ne "$sort_type\t$tab_size\t$tab_type\tNULL\t" >> res.csv
                    /usr/bin/time -aores.csv -f "%U\t%S\t%M" ./main $tab_size $tab_type $sort_type >> res.csv
                done

            fi

        done
    done
done

exit 0
