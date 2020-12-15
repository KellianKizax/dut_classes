#!/bin/sh

# negatif.sh	extension du fichier	repertoire
# transforme toutes les images dont leur nom se termine par l'extension donnée en param 1 directement sous le repertoire
#					donné en param 2

case $# in
	1) echo "Usage : negatif.sh  'extension du fichier'  'repertoire'" ; exit 1 ;;
	2) [ -d "$2" ] || { echo "$0 : $2 : Aucun repertoire de ce nom !" ; exit 1; }
		extension=$1 ; repertoire=$2 ;;
	*) echo "Usage : negatif.sh  'extension du fichier'  'repertoire'" ; exit 1 ;;
esac


count=$(find $repertoire -type f -name "*$extension" | tee liste.txt | wc -l ; )


if [ $count -eq 0 ] ; then
	echo "$extension : Aucun fichier de ce type" ;
else
	while read line ;
	do
		case $(file -b "$line" | cut -d" " -f2) in
			"image") mogrify -negate "$line"; echo "image retouchée : $line" ;;
			*);;
		esac
	done < liste.txt
fi
rm liste.txt
