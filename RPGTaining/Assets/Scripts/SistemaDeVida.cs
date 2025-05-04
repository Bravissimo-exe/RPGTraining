using UnityEngine;

public class SistemaDeVida : SistemaDeEstadisticas
{
    // Atributos
    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorMin, valorActual)
    {
        valorMax = 100;
        valorMin = 0;
    }
}
