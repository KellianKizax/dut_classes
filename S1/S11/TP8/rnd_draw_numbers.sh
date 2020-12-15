#! /bin/sh
# rnd_draw_numbers.sh low high howmany
# ce programme restitue <howmany> nombres "au hasard" dans l'intervalle high..low

# function
shuffle () {
	# local low high howmany
	low=$1
	high=$2
	howmany=$3
	echo $(shuf -i $1-$2 -n $3)
}

# main
[ $# -ne 3 ] && { echo Usage: $(basename $0) low high howmany 1>&2; exit 1; }
[ $2 -ge $1 ] || { echo "$(basename $0): bad interval $1-$2" 1>&2; exit 1; }
number=$(shuffle $1 $2 $3)
echo $number
