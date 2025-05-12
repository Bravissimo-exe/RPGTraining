using UnityEngine;

public abstract class Portador : MonoBehaviour , IDañable, ICurable
{
    protected SistemaDeVida sistemaDeVida;

    protected Portador(SistemaDeVida sistemaDeVida)
    {
        this.sistemaDeVida = sistemaDeVida;
    }

    public void RecibirDaño(int daño)

    {   
        sistemaDeVida.Daño(daño);
    }

    public void Curar(int cantidad){
        sistemaDeVida.Curar(cantidad);
    }

    protected void inicializarVida(){
        sistemaDeVida = new SistemaDeVida();
        Debug.Log(sistemaDeVida.ValorActual);
        sistemaDeVida.AñadirVidaUi(gameObject, sistemaDeVida.ValorMax);
    }
}
