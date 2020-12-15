#!/bin/sh
# users.sh 
# +++++++++++++++++++++++++++++++++++++++++++++++++
# Utilisation de <read> pour lire ds un fichier (ou sortie d'un TUBE)
# liste des COMPTES utilisateurs et UID (User Id) correspondant
# +++++++++++++++++++++++++++++++++++++++++++++++++


OIFS=$IFS   # sauvegarde valeur de IFS initiale
IFS=:       # pour definir ":" comme separateur de champ.

# ++++++++++++++++++++++++++
# technique 1

while read compte motpasse uid reste ; do
      # compte = 1er champ et UID = 3ieme champ 
  echo "$compte a comme id: $uid"
done < users   # Redirection entree (de read)

# ++++++++++++++++++++++++++
# technique 2: communication via tube

echo "Tapez sur Return ! (pas sur votre femme ou mari)"
read bidon # juste pour faire une pause ...

cat users | while read compte motpasse uid reste
            do  echo "$compte a comme id: $uid"
            done

IFS=$OIFS  # Restaure l'$IFS original. (plus prudent !)
exit 0


# NB si on ne modifie pas la variable IFS
cat users | cut -d ':' -f1,3 | tr ':' ' '  | 
            while read compte uid
            do  echo "$compte a comme id: $uid"
            done
