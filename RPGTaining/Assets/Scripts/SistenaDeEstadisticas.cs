using UnityEngine;

public class SistenaDeEstadisticas : MonoBehaviour
{
    [Header("Configuracion Base")]
    [SerializeField] protected int valorMax = 100;
    [SerializeField] protected int valorMin = 0;
    [SerializeField] protected int valorActual;

    //inicializa el valor al maximo al intanciar el objeto
     protected virtual void Awake()
    {
        valorActual = valorMax;
    }


    public int GetValorActual{
        get => valorActual;
    }

    public int GetValorMax{
        get => valorMax;
    }

    public int GetValorMin{
        get => valorMin;
    }

    

}
