#! /bin/sh

# replace_spaces_dir.sh [dir]
# renomme tous les fichiers contenu dans <dir> qui possèdent un " " dans leur nom

[ $# -ge 2 ] && { echo $(basename $0) [dir] 1>&2; exit 1; }
[ $# -eq 1 ] && { [ -d $1 ] && { dir="$1/*";} || { echo "$(basename $0): Le dossier $1 n'existe pas"; exit 1; } } || dir="./*";

count=0

for files in $dir
do
	if [ -f "$files" ] ; then
		if [ $(echo "$files" | grep " " | wc -l) -eq 1 ] ; then
			nvnom="./$(echo $files | tr -s " " "_")"
			mv "$files" "$nvnom"
			echo "$files -> $nvnom"
			count=$(($count+1))
		fi
	fi	
done
echo Nombre de fichiers modifiés : $count
