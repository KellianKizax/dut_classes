#include "RSA.h"
#include "arithm.h"

uint32_t cypher(uint32_t block, public_key key){
    // c = m^e mod n
    return fast_exp(block, key.e, key.module);
}


uint32_t decypher(uint32_t block, RSA_key key){
    // m = c^d mod n
    return fast_exp(block, key.d, key.pub_key.module);
}

RSA_key gen_key(int k_p, int k_q, float eps){
    RSA_key key;
    uint32_t prod;

    do {
		key.p = MR_prime(k_p, eps);
		key.q = MR_prime(k_q, eps);
		key.pub_key.module = key.p * key.q;
	} while (key.pub_key.module >> (k_p + k_q - 1) != 1);

	prod = (key.p - 1) * (key.q - 1);
	key.pub_key.e = 3;

	while ( !(key.d = modular_inv(key.pub_key.e, prod) ) )
		key.pub_key.e += 2;

    return key;
}
/*
RSA_key gen_key(int k_p, int k_q, float eps){
    RSA_key key;

    int p, q, n;
    int pq_trouve = 0;
    while (pq_trouve == 0){

        p = MR_prime(k_p, eps);
        q = MR_prime(k_q, eps);
        n = p * q;

        if (n >> (k_p + k_q - 1) == 1){
            pq_trouve = 1;
        }
    }
    
    int phi = (p - 1) * (q - 1);
    int trouve = 0;
    int e = phi;

    while(trouve == 0){
        e--;
        if(bezout(e,phi).gcd == 1){
            trouve = 1;
        }
    }
    uint32_t d = modular_inv(e,phi);

    key.d = d;
    key.p = p;
    key.q = q;
    key.pub_key.module = n;
    key.pub_key.e = e;

    return key;
}*/

uint8_t* file_to_bytes(char* file_name, size_t* nb_bytes){
    int fd;
	uint8_t *res;

	if (((fd = open(file_name, O_RDONLY)) == -1 ||
	    (*nb_bytes = lseek(fd, 0, SEEK_END)) == (off_t)-1 ||
	    lseek(fd, 0, SEEK_SET) == (off_t)-1 ||
	    (res = malloc(*nb_bytes)) == NULL ||
	    read(fd, res, *nb_bytes) < *nb_bytes) ||
	    close(fd) == -1)
		res = NULL;

	return res;
}

uint32_t* bytes_to_blocks(uint8_t* bytes_seq, size_t nb_bytes, size_t* nb_blocks){
    size_t i;
	uint32_t *blocks_seq;

	*nb_blocks = (nb_bytes >> 2) + (nb_bytes & 3 ? 1 : 0);
	blocks_seq = calloc(*nb_blocks, sizeof(uint32_t));
	if (blocks_seq != NULL)
		for (i = 0; i < nb_bytes; ++i)
			blocks_seq[i >> 2] |=
			    bytes_seq[i] << ((3 - (i & 3)) << 3);

	return blocks_seq;
}

uint32_t* cypher_file(char* file_name, size_t* nb_blocks, public_key key){
    size_t i, nb_bytes;
	uint32_t* blocks_seq;
	uint8_t* bytes_seq;

	bytes_seq = file_to_bytes(file_name, &nb_bytes);
	blocks_seq = bytes_to_blocks(bytes_seq, nb_bytes, nb_blocks);
	free(bytes_seq);
	for (i = 0; i < *nb_blocks; ++i)
		blocks_seq[i] = cypher(blocks_seq[i], key);

	return blocks_seq;
}

void blocks_to_file(char* file_name, uint32_t* blocks_seq, size_t nb_blocks){
    uint8_t *bytes_seq;

	bytes_seq = blocks_to_bytes(blocks_seq, nb_blocks);
	bytes_to_file(file_name, bytes_seq, nb_blocks >> 2);
	free(bytes_seq);
}

uint8_t* blocks_to_bytes(uint32_t* blocks_seq, size_t nb_blocks){
    size_t i, j, k = 0;
	uint8_t *bytes_seq;

	bytes_seq = malloc(nb_blocks * sizeof(uint32_t));
	for (i = 0; i < nb_blocks; ++i)
		for (j = 0; j < 4; ++j)
			bytes_seq[k++] = blocks_seq[i] >> ((3 - j) << 3);

	return bytes_seq;
}

void bytes_to_file(char* file_name, uint8_t* bytes_seq, size_t nb_bytes){
    int fd;

	fd = open(file_name, O_CREAT | O_WRONLY | O_TRUNC);
	write(fd, bytes_seq, nb_bytes);
	close(fd);
}

uint8_t* decypher_file(char* file_name, RSA_key key, size_t* nb_bytes){
    size_t i, nb_blocks;
	uint32_t *blocks_seq;
	uint8_t *bytes_seq;

	bytes_seq = file_to_bytes(file_name, nb_bytes);
	blocks_seq = bytes_to_blocks(bytes_seq, *nb_bytes, &nb_blocks);
	free(bytes_seq);
	for (i = 0; i < nb_blocks; ++i)
		blocks_seq[i] = decypher(blocks_seq[i], key);
	bytes_seq = blocks_to_bytes(blocks_seq, nb_blocks);
	free(blocks_seq);

	return bytes_seq;
}
