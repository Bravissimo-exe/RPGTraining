using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : SistemaDeEstadisticas
{
    [SerializeField] private Slider slider;

    // Atributos
    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorMin, valorActual)
    {
        valorMax = 100;
        valorMin = 0;
    }
    
    
}
