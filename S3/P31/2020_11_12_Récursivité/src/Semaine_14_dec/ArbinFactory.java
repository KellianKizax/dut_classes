package Semaine_14_dec;

import Semaine_30_nov.Arbin;

public interface ArbinFactory
{
    static <T> Arbin<T> getInstance()
    {
        return ArbinR.getInstance();
    }
}
