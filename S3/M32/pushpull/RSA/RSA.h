
#ifndef RSA_h
#define RSA_h

#include "arithm.h"

#include <sys/stat.h>
#include <fcntl.h>
#include <sys/types.h>
#include<unistd.h>

typedef struct {
    uint32_t  module;
    uint32_t  e;
    } public_key;

typedef struct {
    uint32_t  p;
    uint32_t  q;
    uint32_t  d;
    public_key pub_key;
    } RSA_key;

uint32_t cypher(uint32_t block, public_key key);
uint32_t decypher(uint32_t block, RSA_key key);
RSA_key gen_key(int k_p, int k_q, float eps);

uint8_t*  file_to_bytes(char* file_name, size_t* nb_bytes);
void bytes_to_file(char* file_name, uint8_t* bytes_seq, size_t nb_bytes);
uint32_t* cypher_file(char* file_name, size_t* nb_blocks, public_key key);

uint32_t* bytes_to_blocks(uint8_t* bytes_seq, size_t nb_bytes, size_t* nb_blocks);

uint8_t*  blocks_to_bytes(uint32_t* blocks_seq, size_t nb_blocks);
uint8_t* decypher_file(char* file_name, RSA_key key, size_t* nb_bytes);



#endif /* RSA_h */