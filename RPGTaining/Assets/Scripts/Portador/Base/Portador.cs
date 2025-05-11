using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Portador:MonoBehaviour
{



    protected SistemaDeVida sistemaDeVida;

    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaDeVida = sistemaVida;
    }

    protected void inicializarVida(int vidaMax){
        
        sistemaDeVida = new SistemaDeVida(vidaMax);
        Debug.Log(sistemaDeVida.ValorActual);
        sistemaDeVida.AñadirVidaUi(gameObject, sistemaDeVida.ValorMax);
    }
}
