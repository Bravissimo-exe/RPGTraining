using UnityEngine;

public abstract class Portador : MonoBehaviour, IDañable
{
    protected SistemaDeVida sistemaDeVida;

    protected Portador(SistemaDeVida sistemaDeVida)
    {
        this.sistemaDeVida = sistemaDeVida;
    }

    public void RecibirDaño(int daño)
    {
        sistemaDeVida.ValorActual -= daño;
    }

    public void Curar(int cantidad){
        sistemaDeVida.ValorActual += cantidad;
        if(sistemaDeVida.ValorActual > sistemaDeVida.ValorMax)
            sistemaDeVida.ValorActual = sistemaDeVida.ValorMax;
    }
}
