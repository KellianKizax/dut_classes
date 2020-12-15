#!/bin/sh

while [ -n $# ]  ; do
	ping -w 2 $1 >/dev/null 2>/dev/null ;
	etat=$?
	if [ $etat -eq 0 ] ; then
		echo "$1 : vivant(e)" ;
	elif [ $etat -eq 1 ] ; then
		echo "$1 : defaillante(e)" ;
	elif [ $etat -eq 2 ] ; then
		echo "$1 : inconnu(e)" ;
	fi
	shift;
done
