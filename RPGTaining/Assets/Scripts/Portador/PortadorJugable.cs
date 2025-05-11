using UnityEngine;

public class PortadorJugable : Portador
{
    protected string nombre;
    protected SistemaDeMana sistemaDeMana;
    protected SistemaDeHabilidades sistemaDeHabilidades;

    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(sistemaDeVida)
    {
        this.nombre = nombre;
        this.sistemaDeMana = sistemaDeMana;
        this.sistemaDeHabilidades = sistemaDeHabilidades;
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
