#include <err.h>
#include <limits.h>
#include <math.h>
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

extern char *__progname;

static void usage(void);

#define BENCHMARK

int main(int argc, char *argv[])
{
	uint64_t bound, i, k, N, nb;
    double time_bench;

	#ifdef BENCHMARK
	clock_t start;
	#endif

	bool *composite;

	if (argc != 2)
		usage();
	
    N = atoll(argv[1]);
    k = 2;
	bound = sqrt(N);

	if ((composite = calloc(N + 1, sizeof(bool))) == NULL)
		err(EXIT_FAILURE, "calloc");
	
    #ifdef BENCHMARK
	start = clock();
	#endif
	
    while (k <= bound) {
		for (i = 2 * k; i <= N; i += k)
			composite[i] = true;
		while (composite[++k]);
	}

	#ifdef BENCHMARK
    time_bench = (double)(clock() - start) / CLOCKS_PER_SEC;
	#endif

	setbuf(stdout, NULL);
	
    printf("Liste des premiers plus petits que %lu :", N);

	nb = 0;
	for (i = 2; i <= N; ++i)
		if (!composite[i]) {
			printf(" %lu", i);
			++nb;
		}

	printf("\nNombre de premiers plus petits que %lu : %lu\n", N, nb);

	printf("Perfs : %lf sec\n", time_bench);


	free(composite);
	return EXIT_SUCCESS;
}

static void
usage(void)
{
	fprintf(stderr, "usage: %s N\n", __progname);
	exit(EXIT_FAILURE);
}
