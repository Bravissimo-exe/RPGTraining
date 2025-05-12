using UnityEngine;

<<<<<<< Updated upstream
public abstract class Portador : MonoBehaviour, IDañable
=======
public abstract class Portador : MonoBehaviour , IDañable, ICurable
>>>>>>> Stashed changes
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
        sistemaDeVida.regenerarVida(cantidad);
    }

    protected void inicializarVida(int vidaMax){
        sistemaDeVida = new SistemaDeVida(vidaMax);
        Debug.Log(sistemaDeVida.ValorActual);
        sistemaDeVida.AñadirVidaUi(gameObject, sistemaDeVida.ValorMax);
    }

    public void Curar(int cantidad){
        sistemaDeVida.ValorActual += cantidad;
        if(sistemaDeVida.ValorActual > sistemaDeVida.ValorMax)
            sistemaDeVida.ValorActual = sistemaDeVida.ValorMax;
    }
}
