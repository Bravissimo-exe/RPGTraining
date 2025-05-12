using UnityEngine;
using UnityEngine.UI;

public class PortadorNoJugable : Portador
{
    public PortadorNoJugable(SistemaDeVida sistemaVida) : base(sistemaVida)
    {
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void muelto(){
        Destroy(gameObject);
    }
}
