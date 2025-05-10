using UnityEngine;

public class PortadorJugable : Portador



{
    public PortadorJugable(SistemaDeVida sistemaDeVida) : base(sistemaDeVida)
    {
    }

    void Awake()
    {
        añadirMovimiento();
        añadirCamara();
    }

    private void añadirMovimiento(){
        if(GetComponent<Movement>() == null){
            gameObject.AddComponent<Movement>();
        }
    }

     private void añadirCamara(){
        if(GetComponent<Camera>() == null){
            gameObject.AddComponent<Camera>();
        }
    }

}
