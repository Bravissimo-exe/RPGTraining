using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Portador : MonoBehaviour, IDañable, ICurable
{
    protected Slider barraVida;

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

    protected void AñadirVidaUiJugador(GameObject Padre, int vidaMax)
    {

        vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVidaPlayer");
        if (vidaPrefab == null) return;

        GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);

        barraVida = UI.GetComponentInChildren<Slider>();
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaMax;
    }

    protected void AñadirVidaUi(GameObject Padre, int vidaMax)
    {
        Debug.Log("hola");
        vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVida");
        if (vidaPrefab == null) return;

        GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);

        barraVida = UI.GetComponentInChildren<Slider>();
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaMax;
    }

    protected void ActualizarVida(int vidaActual)
    {
        barraVida.value = vidaActual;

    }

    public void Curar(int cantidad)
    {
        sistemaVida.valorActual += cantidad;
        if (sistemaVida.valorActual > sistemaVida.valorMax)
            sistemaVida.valorActual = sistemaVida.valorMax;
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

