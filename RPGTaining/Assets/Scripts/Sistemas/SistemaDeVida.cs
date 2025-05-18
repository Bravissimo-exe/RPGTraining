
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
