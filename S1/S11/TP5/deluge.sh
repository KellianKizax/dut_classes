#!/bin/sh
# deluge.sh

NB=40
echo "Ici Noe ! J'attends la fin du deluge"

while [ $NB -gt 0 ]  # tant que NB > 0
	# while test $NB -gt 0
do
	echo "Fin du deluge dans $NB jour(s)"
	sleep 1
	NB=$(( $NB - 1 ))   # NB=`expr $NB - 1`
done

echo "Tiens, il s'est arrete de pleuvoir"
