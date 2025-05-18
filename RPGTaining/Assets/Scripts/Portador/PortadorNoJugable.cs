using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador
{
    public PortadorNoJugable(SistemaDeVida sistemaVida) : base(sistemaVida)
    {
    }

    void Awake()
    {
        InicializarVida(1000);
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    }
  
}
