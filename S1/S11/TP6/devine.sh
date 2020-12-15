#!/bin/sh

PID=$$
T=1

VAL=$(( $PID % 100 ))

read -p "Quelle valeur ? " NOMBRE
while [ $NOMBRE -ne $VAL ] ; do
    if [ $NOMBRE -lt $VAL ] ; then
        echo "C'est plus grand !"
    else
        echo "C'est plus petit !"
    fi
    T=$(( $T + 1 ))
    read -p "Quelle valeur ? " NOMBRE
done

echo "Bravo ! Vous avez devine $VAL en $T coup(s). Je suis le shell $PID"