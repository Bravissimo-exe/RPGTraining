using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : SistemaDeEstadisticas
{

<<<<<<< Updated upstream
=======
    protected GameObject vidaPrefab;
    protected Slider barraVida;

    public event Action muerte;

    public SistemaDeVida() : base(100,100){

    }
    public SistemaDeVida(int vidaMax) : base(vidaMax)
    {
        
    }

>>>>>>> Stashed changes
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

    public void Daño(int vidaActual, int cantidad){
        vidaActual -= cantidad;

        if(vidaActual <= 0){
            muerte?.Invoke();
        }
    }

    public void ActualizarVida(int vidaActual, int vidaMax){
        
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaActual;
    }
}
