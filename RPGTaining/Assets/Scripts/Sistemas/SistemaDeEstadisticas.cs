using UnityEngine;

public abstract class SistemaDeEstadisticas : MonoBehaviour
{
    [Header("Configuracion Base")]
    [SerializeField] private int valorMax = 100;
    [SerializeField] private int valorMin = 0;
    [SerializeField] private int valorActual;

    public SistemaDeEstadisticas(int valorMax, int valorMin, int valorActual)
    {
        this.ValorMax = valorMax;
        this.ValorMin = valorMin;
        this.ValorActual = ValorMax;
    }

    public int ValorMax { get => valorMax; set => valorMax = value; }
    public int ValorMin { get => valorMin; set => valorMin = value; }
    public int ValorActual { get => valorActual; set => valorActual = value; }


    

}
