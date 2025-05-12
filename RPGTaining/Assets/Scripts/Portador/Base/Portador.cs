using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< Updated upstream
public abstract class Portador : MonoBehaviour
=======
public abstract class Portador: MonoBehaviour
>>>>>>> Stashed changes
{

<<<<<<< Updated upstream
    protected Portador(SistemaDeVida sistemaVida)
    {
        this.sistemaDeVida = sistemaVida;
    }

    protected void inicializarVida(int vidaMax){
        sistemaDeVida = new SistemaDeVida(vidaMax);
        Debug.Log(sistemaDeVida.ValorActual);
        sistemaDeVida.AñadirVidaUi(gameObject, sistemaDeVida.ValorMax);
    }
=======
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
    
    
>>>>>>> Stashed changes
}

