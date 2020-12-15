#!/bin/sh

# Le dossier de départ du projet
B="$(dirname $(realpath $(pwd)/"$0"))"

# Le User
U=$USER

# L'exercice
E="${1:-coloriage}"

DESTHOST=e.blindauer@phoenix

# La clef doit : etre unique, a root dans un path commun
# ou par user avec un chmod 600
# comme on la transporte, on lui applique les droits
KEY="$B/id_rsa.m21"

chmod 600 "$KEY" 2>/dev/null

[ -d "$E" ] || { echo $E n\'est pas un dossier valide; exit 1; }

echo "Lancement pour $U - Soumission de $E"


# Lancement de l'analyse
ssh -i "$KEY" $DESTHOST evalue "$B" "$U" "$E"


