using Unity.VisualScripting;
using UnityEngine;

public class PortadorJugable : Portador
{
<<<<<<< Updated upstream

    protected string nombre;
    protected SistemaDeMana sistemaDeMana;
    protected SistemaDeHabilidades sistemaDeHabilidades;

    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(null)
    {
    }


    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(sistemaDeVida)
    {
        this.nombre = nombre;
        this.sistemaDeHabilidades = sistemaDeHabilidades;
    }

    void Awake()
    {
        inicializarVida(100);
        Debug.Log("sexo5");
=======

    protected PortadorJugable(): base(){
        
    }
    

    protected void Awake()
    {
        AñadirVidaUi(this.gameObject, sistemaDeVida.valorActual, sistemaDeVida.valorMax);
        
        
>>>>>>> Stashed changes
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
