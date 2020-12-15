#!/bin/sh

# le programme examine successivement chacune des machines hotes données en paramètre
# pour savoir si elle est active ou non

while [ $# -ne 0 ] ; do
	ping -w 2 $1 >/dev/null 2>/dev/null;
	case $? in
		0) echo "$1: vivant(e)" ;;
		1) echo "$1: defaillant(e)" ;;
		2) echo "$1: inconnu(e)" ;;
		*) echo "oups" ;;
	esac
	shift;
done
