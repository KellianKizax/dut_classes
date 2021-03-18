all: main

main: main.o tris.o gen_array.o
	gcc -Wall -o main main.o tris.o gen_array.o

main.o:
	gcc -Wall main.c -c

gen_array.o:
	gcc -Wall gen_array.c -c

tris.o: tris.c tris.h
	gcc -Wall tris.c -c

clean:
	rm -f *.o core