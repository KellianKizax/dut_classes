#! /bin/sh
# rnd_draw_a_number.sh low high
# ce programme restitue un nombre "au hasard" dans l'intervalle high..low

#function
shuffle () {
	# local low high
	low=$1
	high=$2
	return $(shuf -i $low-$high -n 1)
}

#main
[ $# -ne 2 ] && { echo Usage : $(basename $0) low high 1>&2; exit 1; }
# nb : on ne verifie pas que les bornes $1 et $2 sont des nombres ; par contre, on controle que $1 <= $2
[ $2 -ge $1 ] || { echo "$(basename $0): bad interval" 1>&2; exit 1; }

shuffle $1 $2
number=$?
echo $number
