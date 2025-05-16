
using System;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : SistemaDeEstadisticas 
{
    protected GameObject vidaPrefab;
    protected Slider barraVida;

    public event Action muerte;

    public SistemaDeVida() : base(100,100){

    }
    public SistemaDeVida(int vidaMax) : base(vidaMax){}

    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual){}

    public void Daño(int cantidad){
        Debug.Log("sex");
        if(valorActual > valorMin){
            valorActual -= cantidad;
        }
        if(valorActual <= 0){
            muerte?.Invoke();
        }
    }

    public void RegenerarVida(int cantidad){
        if(valorActual < valorMax){
            valorActual+= cantidad;
        }
    }
}
