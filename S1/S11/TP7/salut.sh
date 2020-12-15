#!/bin/sh

heure=$( date +%H )

echo "Il est $heure H."
case $heure in
[0-9]) echo "Bonjour, $LOGNAME !" ;;
1[0-9]) echo "Bonne journée, $LOGNAME !" ;;
2[0-3]) echo "Bonne soirée, $LOGNAME !" ;;
*) echo "Il y a un couac !" ;;
esac
