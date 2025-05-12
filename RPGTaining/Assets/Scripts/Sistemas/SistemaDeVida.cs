
using System;
using UnityEditor;
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

    
    public SistemaDeVida(int valorMax, int valorMin, int valorActual) : base(valorMax, valorActual)
    {
    }


    public virtual void regenerarVida(int cantidad){
         valorActual+= cantidad;
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
        valorActual -= cantidad;

        if(valorActual <= 0){
            muerte?.Invoke();
        }
    }

    public void ActualizarVida(int vidaActual, int vidaMax){
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaActual;
    }

    public void RegenerarVida(int cantidad){
        valorActual+= cantidad;
    }
}
