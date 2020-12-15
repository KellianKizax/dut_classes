#!/bin/sh

#cherche un fichier dans un dossier et recursivement dans toute l'arborescence en dessous de lui

case $# in
	1) dir=. ; file=$1 ;;
	2) [ -d "$1" ] || { echo "$0: $1: Aucun repertoire de ce type !" ; exit 1; }
		dir=$1 ; file=$2 ;;
	*) echo "Usage: $0 [dir] file" ; exit 1 ;;
esac
count=$(find $dir -type f -name "$file" | tee liste.txt | wc -l)

if [ $count -eq 0 ] ; then
	echo "fichier $file introuvable !"
else
	cat liste.txt # on affiche les chemins (en partant de dir) des fichiers
fi
rm liste.txt
