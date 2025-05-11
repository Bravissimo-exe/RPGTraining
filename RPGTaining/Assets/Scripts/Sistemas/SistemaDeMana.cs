using UnityEngine;

public class SistemaDeMana : SistemaDeEstadisticas
{
    public SistemaDeMana(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual)
    {
    }

    public virtual void regenerarMana(int cantidad){
         ValorActual+= cantidad;
    }
}
