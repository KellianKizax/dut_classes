#!/bin/sh
nom=$(whoami)
heure=$(date +%H)
echo "It's "$heure" (o'clock)."
if [ 0 -le $heure ] && [ $heure -le 5 ]
then echo "You should sleep, $nom !"
elif [ 6 -le $heure ] && [ $heure -le 11 ]
then echo "Good morning, $nom !"
elif [ 12 -le $heure ] && [ $heure -le 17 ]
then echo "Good afternoon, $nom !"
elif [ 18 -le $heure ]
then echo "Good evening, $nom !"
fi