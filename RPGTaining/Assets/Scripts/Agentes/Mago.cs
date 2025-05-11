using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mago : PortadorJugable
{

    //Referencias
    [SerializeField] private List<GameObject> prefabsBolas = new List<GameObject>();
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

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

        //Habilidad 1
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1){
                habilidad1.EmpezarCarga(this);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Alpha1)){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1){
                habilidad1.SoltarCarga(prefabsBolas, shootPoint, rotacionCamara);
            }
        }

        //Habilidad 2


        //Habilidad 3
    }

    private void SetupSistemas(){
        sistemaDeVida = new SistemaDeVida();
        sistemaDeMana = new SistemaDeMana();
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();

    }
    
}
