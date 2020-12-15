#!/bin/sh

# calculer.sh [ -p precision ] formule
# si option -p en 1er argument (optionnel), alors la precision de calcul
#			est en 2eme position (et la formule en position 3)
# sinon : on donne seulement la formule (espaces autorisés); dans ce cas, la precision est de 2

if [ "$1" = "-p" ] ; then
	precision=$2
	shift 2
else
	precision=2
fi
bc -q -l <<end
scale=$precision
$@
end
