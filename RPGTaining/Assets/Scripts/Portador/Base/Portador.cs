using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Portador : MonoBehaviour, IDañable, ICurable
{   
    [SerializeField] private Slider barraVida;
    protected GameObject vidaPrefab;

    protected SistemaDeVida sistemaVida;

     private GameObject UI;

    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaVida = sistemaVida;
    }

    protected void InicializarVida(int vidaMax)
    {
        sistemaVida = new SistemaDeVida(vidaMax);
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaMax;
    }

    protected void ActualizarVida(int vidaActual){
        barraVida.value = vidaActual;
        
    }
    
    public void Curar(int cantidad){
        sistemaVida.RegenerarVida(cantidad);
    }

    public void RecibirDaño(int daño){
        Debug.Log("ssz");
        sistemaVida.Daño(daño);
    }
    
}

