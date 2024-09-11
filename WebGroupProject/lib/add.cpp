// sudo apt-get install libgmp-dev
// g++ -shared -fPIC -o libadd.so add.cpp -lgmp

#include <gmp.h>

extern "C" {
    // just for demo purpose, later we will use char pointers or other data type to pass long numbers
    long long Add(long long a, long long b) {
        mpz_t x, y, result; // C-style variable declaration, we will use c++ style later
        mpz_init(x);
        mpz_init(y);
        mpz_init(result);

        mpz_set_si(x, a);
        mpz_set_si(y, b);
        mpz_add(result, x, y);

        long long res = mpz_get_si(result);

        mpz_clear(x);
        mpz_clear(y);
        mpz_clear(result);

        return res;
    }
}
