using UnityEngine;

public class SistemaDeVida : SistemaDeEstadisticas
{
    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorMin, valorActual)
    {
    }

    public virtual void regenerarVida(int cantidad){
         ValorActual+= cantidad;
    }
}
