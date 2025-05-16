
using System;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : SistemaDeEstadisticas
{
    protected GameObject vidaPrefab;
    protected Slider barraVida;

    public SistemaDeVida() : base(100, 100)
    {

    }
    public SistemaDeVida(int vidaMax) : base(vidaMax) { }

    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual) { }

    public void AñadirVidaUiJugador(GameObject Padre, int vidaMax)
    {
        Debug.Log("sexo1");
        vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVidaPlayer");
        if (vidaPrefab == null) return;

        GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);
        Debug.Log("sexo2");
        barraVida = UI.GetComponentInChildren<Slider>();
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaMax;
    }

    public void AñadirVidaUi(GameObject Padre, int vidaMax)
    {
        Debug.Log("sexo1");
        vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVida");
        if (vidaPrefab == null) return;

        GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);
        Debug.Log("sexo2");
        barraVida = UI.GetComponentInChildren<Slider>();
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaMax;
    }

    public void RecibirDaño(int cantidad)
    {
        valorActual -= cantidad;
        if (valorActual < valorMin)
            valorActual = 0;
    }



    public void Curar(int cantidad)
    {
        valorActual += cantidad;
        if (valorActual > valorMax)
            valorActual = valorMax;
    }
}
