using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Portador : MonoBehaviour, IDañable
{
    protected Slider barraVida;

    protected GameObject vidaPrefab;

    protected SistemaDeVida sistemaVida;

    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaVida = sistemaVida;
    }

    protected void Start()
    {

    }

    abstract void InicializarVida(int vidaMax){
        sistemaVida = new SistemaDeVida(vidaMax);
    }

    protected void AñadirVidaUi(GameObject Padre, int vidaActual, int vidaMax){

            vidaPrefab = Resources.Load<GameObject>("UI/BarraDeVida");
            if(vidaPrefab == null) return;

            GameObject UI = GameObject.Instantiate(vidaPrefab, Padre.transform);

            barraVida = UI.GetComponentInChildren<Slider>();
            barraVida.maxValue = vidaMax;
            barraVida.value = vidaActual;
    }

    protected void ActualizarVida(int vidaActual, int vidaMax){
        barraVida.maxValue = vidaMax;
        barraVida.value = vidaActual;
    }
    
    public void RecibirDaño(int daño){
        sistemaVida.Daño(daño);
    }
    
}

