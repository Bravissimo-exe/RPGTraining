using UnityEngine;

public abstract class Portador:MonoBehaviour
{
    protected SistemaDeVida sistemaDeVida;

    protected Portador(SistemaDeVida sistemaDeVida)
    {
        this.sistemaDeVida = sistemaDeVida;
    }

    
    
}
