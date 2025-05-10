using UnityEngine;

public abstract class Portador : MonoBehaviour
{
    //propiedades
    protected SistemaDeVida sistemaVida;

    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaVida = sistemaVida;
    }
}
