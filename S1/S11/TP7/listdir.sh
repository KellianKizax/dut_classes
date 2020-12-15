#!/bin/sh

#Lister les repertoires subordonnés au répertoire donné en paramètre

DIR=$1

for i in $DIR/*; do
	[ -d $i ] && basename $i
done
