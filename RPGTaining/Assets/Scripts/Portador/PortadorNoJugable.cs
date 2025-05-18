using UnityEngine;

public class PortadorNoJugable : Portador
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

    // Update is called once per frame
    void Update()
    {
    }
  
}
