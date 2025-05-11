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
}
