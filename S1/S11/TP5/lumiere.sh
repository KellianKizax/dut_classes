#!/bin/sh
# lumiere.sh

NB=21		# le nbre de bougies 
ID=$(whoami)  # ID=`whoami`
echo "Eteignez la lumiere! $ID souffle les bougies !"

while [ $NB -gt 0 ]	 # tant que NB est > 0
	# while test $NB -gt 0
do
    echo "Encore $NB bougie(s) !"
    sleep 2
    NB=$(( $NB - 1 )) # decremente NB
    # NB=`expr $NB - 1`	
done
echo "Plus de bougies ! Rallumez !"

