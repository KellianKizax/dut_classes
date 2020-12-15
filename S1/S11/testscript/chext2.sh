#! /bin/sh

# auteur : GOFFIC Kellian
# groupe : 2

# chext2.sh dir ext:ext [ext:ext] ...
# change les fichiers d'un repertoire d'une certaine extension en une autre

[ $# -ge 2 ] || { echo "Usage : $(basename $0) dir ext:ext" ; exit 1 ; }
[ -d $1 ] || { echo "$1 Repertoire inexistant" ; exit 1 ; }

dir=$1
shift

while [ $# -gt 0 ]
do
	oldext=$(echo $1 | cut -d':' -f1)
	newext=$(echo $1 | cut -d':' -f2)
	shift


	count=0
	for files in "$dir/*.$oldext" ; do

		namefile=$(echo $files | cut -d' ' -f$(($count+1)))

		newname="$(echo $namefile | cut -d'.' -f1).$newext"
	
		mv $namefile $newname
	
		echo $namefile "=>" $newname
	
		count=$(($count+1))
	done

done
echo "$count fichier(s) .$oldext renomme(s) en .$newext"
