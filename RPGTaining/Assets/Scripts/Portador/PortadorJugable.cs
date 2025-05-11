using UnityEngine;

public class PortadorJugable : Portador



{
<<<<<<< Updated upstream
    public PortadorJugable(SistemaDeVida sistemaDeVida) : base(sistemaDeVida)
=======
    protected string nombre;
    protected SistemaDeMana sistemaDeMana;
    protected SistemaDeHabilidades sistemaDeHabilidades;

    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(null)
>>>>>>> Stashed changes
    {
    }

<<<<<<< Updated upstream
=======
    public PortadorJugable(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(sistemaDeVida)
    {
        this.nombre = nombre;
        this.sistemaDeHabilidades = sistemaDeHabilidades;
    }


>>>>>>> Stashed changes
    void Awake()
    {
        inicializarVida(100);
        Debug.Log("sexo5");
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
