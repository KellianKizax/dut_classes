all: main

m11Eval.o: m11Eval.h m11Eval.c
	gcc -Wall -c m11Eval.c

main: m11Eval.o main.c
	gcc -o main -Wall m11Eval.o main.c

