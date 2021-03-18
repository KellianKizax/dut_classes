#include "image.h"

#include <iostream>
#include <cstring> // memcpy

template<class T>
Image<T>::Image(int dx, int dy):dx(0),dy(0)
{
    if(dx>=0 && dy>=0) {
        this->dx=dx;
        this->dy=dy;
        this->size=dx*dy;
        this->data=std::vector<T>(this->size);
    }    
}

template<class T>
Image<T>::Image(int dx, int dy, const std::vector<T> &data)
{
    if(dx>=0 && dy>=0 && data.size() == (unsigned long)dx*dy) {
        this->dx=dx;
        this->dy=dy;
        this->size=dx*dy;
        this->data=data;
    }    
}

template<class T>
Image<T>::Image(const Image<T> &image)
{
    this->dx=image.dx;
    this->dy=image.dy;
    this->size=image.size;
    this->data=image.data;    
}

template<class T>  
Image<T> &Image<T>::operator=(const Image<T> &image)
{
    if(this!=&image)
    {
    this->dx=image.dx;
    this->dy=image.dy;
    this->size=dx*dy;
    this->data=image.data;
    }
    return *this;
}

template<class T>
int Image<T>::getDx() const
{
    return dx;
}

template<class T>
int Image<T>::getDy() const
{
    return dy;
}

template<class T> 
int Image<T>::getSize() const
{
    return size;
}
    
template<class T> 
std::vector<T> Image<T>::getData() const
{
    return data;
}

/// valeur min
template<class T>
T Image<T>::getMin() const
{
    if(this->data.size()==0) 
        return(T(0));
    T min=data[0];
    for(int i=0; i<size; ++i) {
        if(data[i] < min)
            min=data[i];
    }
    return min;
}

/// valeur max
template<class T>
T Image<T>::getMax() const
{
     if(this->data.size()==0) 
        return(T(0));
    T max=data[0];
    for(int i=0; i<size; ++i) {
        if(data[i] > max)
            max=data[i];
    }
    return max;
}
template<class T>
void Image<T>::print()
{
    
    for(int x=0; x<dx; x++) {
        std::cout.width(3);
        std::cout << "----";
    }
    std::cout << "\n";
    
    for(int y=0; y<dy; y++) {
        for(int x=0; x<dx; x++) {
            std::cout.width(3);
            std::cout << (double)(*this)(x,y) << "|";
        }
        std::cout << "\n";
        for(int x=0; x<dx; x++) {
            std::cout.width(3);
            std::cout << "----";
        }
        std::cout << "\n";
    }
}

    
template<class T>
T &Image<T>::operator()(const int &x, const int &y)
{
    return data[y*dx+x];
}

template<class T>
T Image<T>::operator() (const int &x, const int &y) const
{
    return data[y*dx+x];
}

   
template<class T>
T &Image<T>::operator()(const int &i)
{
    return data[i];
}

template<class T>
T Image<T>::operator() (const int &i) const
{
    return data[i];
}

// ===============================================================

template<class T>
void Image<T>::print_info() {

    // Display dimensions
    std::cout << "Dimensions : \ndx : " << this->dx << "\ndy : " << this->dy << "\n";

    // size
    std::cout << "Taille de l'image : " << this->size << "\n";

    // min and max value of pixels
    std::cout << "\nValeurs des pixels : \nMin : " << unsigned(this->getMin()) << "\nMax : " << unsigned(this->getMax()) << "\n";

    // sum of all pixels
    int sum = 0;
    for( int i = 0; i < this->size; i++ ) {
        sum += data[i];
    }
    std::cout << "Somme des valeurs des pixels : " << sum << "\n";

    // average grey level
    std::cout << "Niveau de gris moyen : " << sum/this->size << "\n";
}

template<class T>
void Image<T>::set_pxl_offset() {

    for ( int i = 0; i < this->getSize(); i++ ) {
        this->data[i] = i %256;
    }
}

template<class T>
void Image<T>::threshold(int value) {

    for ( int i = 0; i < this->getSize(); i++ ) {

        if ( this->data[i] < value )
            this->data[i] = 0;
        else
            this->data[i] = 255;
    }
}

template<class T>
void Image<T>::negate() {

    for ( int i = 0; i < this->getSize(); i++ ) {
        this->data[i] = 255 - this->data[i];
    }
}

template<class T>
void Image<T>::compute_histo() {

    int histo[256] {0};

    for ( int i = 0; i < this->getSize(); i++ ) {
        histo[ this->data[i] ]++;
    }

    for ( int i = 0; i < 256; i++ ) {
        std::cout << i << " " << histo[i] << "\n";
    }
}

template<class T>
void Image<T>::normalize( int min, int max ) {

    int img_min = this->data[0];
    int img_max = this->data[0];

    // Parcours et recherche des valeurs minimum et maximum de l'image
    for ( int i = 1 ; i < this->getSize(); i++ ) {
        if ( img_min > this->data[i] ) {
            img_min = this->data[i];
        }
        else if ( img_max < this->data[i] ) {
            img_max = this->data[i];
        }
    }

    int offset = min - img_min;
    float ratio = (float)( max - min ) / (float)( img_max - img_min );


    // Parcours, calcul et remplacement de la valeur de chaque pixel
    for ( int i = 0; i < this->getSize(); i++ ) {
        this->data[i] = (int8_t) (this->data[i] * ratio + offset);        
    }
}

template<class T>
void Image<T>::equalize() {
    
    int* cumul_histo = (int*) calloc( 256, sizeof(int) );

    this->compute_cumulative_histo( cumul_histo );

    // Parcours, calcul et remplacement de la valeur de chaque pixel
    for ( int i = 0; i < this->getSize(); i++ ) {
        int value = this->data[i];
        this->data[i] = (uint8_t) ((float)( (float)(255)/(float)(this->getSize()) ) * (float)(cumul_histo[value]));
    }

}

template<class T>
void Image<T>::compute_cumulative_histo( int* histo ) {

    // Parcours de l'ensemble des pixels de l'image
    for ( int i = 0; i < this->getSize(); i++ ) {
        int value = this->data[i];
        histo[value] = histo[value] + 1;
    }

    int cumulative = 0;
    // Parcours de l'ensemble de l'histo et calcul de l'histo cumulé
    for ( int i = 0; i < 256; i++ ) {
        cumulative = cumulative + histo[i];
        histo[i] = cumulative;
    }
}
