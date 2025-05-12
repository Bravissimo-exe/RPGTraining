using UnityEngine;

// Clase pura C# (NO hereda de MonoBehaviour)
public class SistemaDeEstadisticas
{
   [SerializeField] public int valorMax;
   [SerializeField] public int valorMin;
   [SerializeField] public int valorActual;

    public SistemaDeEstadisticas(int valorMax)
    {
        this.ValorMax = valorMax;
        this.ValorMin = 0;
        this.ValorActual = valorMax;
    }

    public SistemaDeEstadisticas(int valorMax, int valorActual)
    {
        this.ValorMax = valorMax;
        this.ValorMin = 0;
        this.ValorActual = valorActual;
    }

    protected SistemaDeEstadisticas()
    {
<<<<<<< Updated upstream
        this.ValorMax = valorMax;
        this.ValorMin = valorMin;
        this.valorActual = valorMax;

    }

    public int ValorMax { get => valorMax; set => valorMax = value; }
    public int ValorMin { get => valorMin; set => valorMin = value; }
    public int ValorActual { get => valorActual; set => valorActual = value; }

}
=======
        this.valorMax = valorMax;
        this.valorMin = valorMin;
        this.valorActual = valorActual;
    }
}
>>>>>>> Stashed changes
