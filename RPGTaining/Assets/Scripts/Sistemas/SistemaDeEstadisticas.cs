using UnityEngine;

public abstract class SistemaDeEstadisticas
{
    [Header("Configuracion Base")]
    [SerializeField] protected int valorMax = 100;
    [SerializeField] protected int valorMin = 0;
    [SerializeField] protected int valorActual;

    public SistemaDeEstadisticas(int valorMax, int valorMin, int valorActual)
    {
        this.ValorMax = valorMax;
        this.ValorMin = valorMin;
        this.ValorActual = valorActual;
    }

    protected SistemaDeEstadisticas()
    {
        this.valorMax = 100;
        this.valorMin = 0;
        this.valorActual = valorMax;
    }

    public int ValorMax { get => valorMax; set => valorMax = value; }
    public int ValorMin { get => valorMin; set => valorMin = value; }
    public int ValorActual { get => valorActual; set => valorActual = value; }


    

}
