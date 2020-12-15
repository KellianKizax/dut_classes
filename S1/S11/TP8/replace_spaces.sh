#!/bin/sh

# renomme les fichiers ordinaires avec un " " dans leur nom en le remplacant par un "_"

# NE MARCHE PAS CAUSE DU GREP

ls 1>liste.txt
count=0

while read line
do
	nom=$line
	echo "$nom" 1>nom.txt
	if [ -f "$nom" ] && [ $(echo "$nom" | grep " " | wc -l) -eq 1 ] ; then
		nvnom=$(echo "$nom" | tr ' ' '_')
		mv "$nom" "$nvnom"
		count=$(($count+1))
		echo "$nom -> $nvnom"
	fi
	rm nom.txt
done<liste.txt
echo "Nombre de fichiers renommés : $count"
rm liste.txt
