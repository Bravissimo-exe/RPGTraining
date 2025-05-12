
using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : SistemaDeEstadisticas
{
    private GameObject vidaPrefab;
    private Slider barraVida;


    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorMin, valorActual)
    {
    }
    
    public SistemaDeVida () : base(100, 0, 100){

    }
    public void AñadirVidaUi(GameObject Padre, int vidaMax){
            Debug.Log("sexo1");
            vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVida");
            if(vidaPrefab == null) return;

            GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);
            Debug.Log("sexo2");
            barraVida = UI.GetComponentInChildren<Slider>();
            barraVida.maxValue = vidaMax;
            barraVida.value = vidaMax;
    }

    public void Daño(int cantidad){  
        if(ValorActual >= 1){
            ValorActual -= cantidad;
        }
    }

    public void regenerarVida(int cantidad){
        if(valorActual < valorMax ){
            valorActual += cantidad;
        }
    }

    public void Curar(int cantidad){
        valorActual += cantidad;
        if(valorActual > valorMax){
            valorActual = valorMax;
        }
    }

    public void ActualizarVida(int vidaActual){
        barraVida.value = vidaActual;
    }
}
