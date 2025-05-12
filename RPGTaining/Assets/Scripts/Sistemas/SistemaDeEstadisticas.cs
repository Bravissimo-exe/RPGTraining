using UnityEngine;

// Clase pura C# (NO hereda de MonoBehaviour)
public class SistemaDeEstadisticas
{
   [SerializeField] public int valorMax;
   [SerializeField] public int valorMin;
   [SerializeField] public int valorActual;

    public SistemaDeEstadisticas(int valorMax)
    {
        this.valorMax = valorMax;
        this.valorMin = 0;
        this.valorActual = valorMax;
    }

    public SistemaDeEstadisticas(int valorMax, int valorActual)
    {
        this.valorMax = valorMax;
        this.valorMin = 0;
        this.valorActual = valorActual;
    }

    protected SistemaDeEstadisticas()
    {
        valorMax = valorMax;
        valorMin = valorMin;
        valorActual = valorActual;
    }
}
