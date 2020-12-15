#!/bin/sh

#recherche si un utilisateur donné en paramètre est connecté

nom=$(who | grep "$1")

[ -z "$1" ] && { echo "Usage: is_connected.sh user"; } || ( [ -n "$nom" ] && { echo "$1 is connected"; } || { echo "$1 is not connected"; } )
