using UnityEngine;

public class SistemaDeVida : SistemaDeEstadisticas
{
    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorMin, valorActual)
    {
    }

    public SistemaDeVida() : base ()
    {
    }

    public virtual void regenerarVida(int cantidad){
        if(ValorActual + cantidad > valorMax){
            ValorActual+= cantidad;
        } else{
            valorActual = valorMax;
        }
    }
}
