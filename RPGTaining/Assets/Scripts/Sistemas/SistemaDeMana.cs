using UnityEngine;

public class SistemaDeMana : SistemaDeEstadisticas
{
    public SistemaDeMana(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual)
    {
    }
    public SistemaDeMana(){}

    public virtual void regenerarMana(int cantidad){
        if(valorActual + cantidad > valorMax){
            valorActual+= cantidad;
        } else{
            valorActual = valorMax;
        }
    }
}
