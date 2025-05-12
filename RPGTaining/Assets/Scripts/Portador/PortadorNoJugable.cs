using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador, IDañable
{
    public PortadorNoJugable(SistemaDeVida sistemaVida) : base(sistemaVida)
    {
    }

    void Awake()
    {
        InicializarVida(100);
    }

    void Start()
    {
        AñadirVidaUi(this.gameObject, sistemaVida.valorMax);
    }
    
    void Update()
    {
        ActualizarVida(sistemaVida.valorActual);
    }
}
