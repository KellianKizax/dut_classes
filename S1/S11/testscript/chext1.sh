#! /bin/sh

# auteur : GOFFIC Kellian
# groupe : 2

# chext1.sh ext:ext
# change les fichiers du repertoire courant d'une certaine extension en une autre, toutes deux données en paramètre.

[ $# -eq 1 ] || { echo "Usage : $(basename $0) ext:ext" ; exit 1 ; }

oldext=$(echo $1 | cut -d':' -f1)
newext=$(echo $1 | cut -d':' -f2)


count=0
for files in "*.$oldext" ; do

	namefile=$(echo $files | cut -d' ' -f$(($count+1)))

	newname="$(echo $namefile | cut -d'.' -f1).$newext"
	
	mv $namefile $newname
	
	echo $namefile "=>" $newname
	
	count=$(($count+1))
done

echo "$count fichier(s) .$oldext renomme(s) en .$newext"
