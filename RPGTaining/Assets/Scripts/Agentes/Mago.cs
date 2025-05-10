using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mago : PortadorJugable
{
    public Mago(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades){
    }
    //Unity obviamente no usa el constructor cuando se instancia un MonoBehaviour
    //Por lo que las cosas las debemos inicializar en el Awake

    void Awake(){
        SetupSistemas();
        sistemaDeHabilidades.AñadirHabilidad(new BolaDeLuz("Bola de Luz"));
    }

    void Start(){

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1){
                habilidad1.EmpezarCarga(this);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Alpha1)){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1){
                habilidad1.SoltarCarga();
            }
        }
    }

    private void SetupSistemas(){
        sistemaDeVida = new SistemaDeVida();
        sistemaDeMana = new SistemaDeMana();
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();

    }
    
}
