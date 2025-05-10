using UnityEngine;

public abstract class SistemaDeEstadisticas
{
    private int valorMax;
    private int valorMin;
    private int valorActual;

    protected SistemaDeEstadisticas(int valorMax, int valorMin, int valorActual)
    {
        this.valorMax = valorMax;
        this.valorMin = valorMin;
        this.valorActual = valorActual;
    }

    public int ValorMax { get => valorMax; set => valorMax = value; }
    public int ValorMin { get => valorMin; set => valorMin = value; }
    public int ValorActual { get => valorActual; set => valorActual = value; }
}
