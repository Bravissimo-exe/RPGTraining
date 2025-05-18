using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Portador : MonoBehaviour, IDañable, ICurable
{
    [SerializeField]protected Slider barraVida;

    protected GameObject vidaPrefab;

    protected SistemaDeVida sistemaVida;

    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaVida = sistemaVida;
    }


    protected void InicializarVida(int vidaMax)
    {
        sistemaVida = new SistemaDeVida(vidaMax);
    }

    public void Curar(int cantidad)
    {
        sistemaVida.valorActual += cantidad;
        if (sistemaVida.valorActual > sistemaVida.valorMax)
            sistemaVida.valorActual = sistemaVida.valorMax;
    }

    protected void ActualizarVida(int vidaActual){
        barraVida.value = vidaActual;
    }

    public void RecibirDaño(int daño)
    {
        sistemaVida.valorActual -= daño;
    }

    public void Morir()
    {
        Destroy(this);
    }
    
}

