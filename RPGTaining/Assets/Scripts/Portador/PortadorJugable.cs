using Unity.VisualScripting;
using UnityEngine;

public class PortadorJugable : Portador
{
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
        InicializarVida(100);
        Debug.Log("sexo5");
        añadirMovimiento();
        // añadirCamara();
    }

    private void añadirMovimiento(){
        if(GetComponent<Movement>() == null){
            gameObject.AddComponent<Movement>();
        }
    }

    // private void añadirCamara(){
    //     if(GetComponent<Camara>() == null){
    //         gameObject.AddComponent<Camara>();
    //     }
    // }

}
