using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mago : PortadorJugable
{

    //Referencias
    [SerializeField] private List<GameObject> prefabsBolas = new List<GameObject>();
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    
    private float _tiempoPasadoHabilidad1 = -5;
    private bool _pasoPorKeyDown = false;

    public Mago(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades){
    }
    
    //Unity obviamente no usa el constructor cuando se instancia un MonoBehaviour
    //Por lo que las cosas las debemos inicializar en el Awake

    void Awake(){
        SetupSistemas();
        sistemaDeHabilidades.AñadirHabilidad(new BolaDeLuz("Bola de Luz"));
        sistemaDeHabilidades.AñadirHabilidad(new CuracionDivina("Curación Divina"));
    }

    void Start(){
    }

    void Update(){

        Debug.Log("Tiempo transcurrido: " + (Time.time - _tiempoPasadoHabilidad1));

        //Habilidad 1
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1 && Time.time - _tiempoPasadoHabilidad1 >= habilidad1.CoolDown){
                habilidad1.EmpezarCarga(this);
                _pasoPorKeyDown = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Alpha1)){
            
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1 && _pasoPorKeyDown){
                habilidad1.SoltarCarga(prefabsBolas, shootPoint, rotacionCamara);
                _tiempoPasadoHabilidad1 = Time.time;
                _pasoPorKeyDown = false;
            }
        }

        //Habilidad 2
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(sistemaDeHabilidades.Habilidades[1] is CuracionDivina habilidad2){
                habilidad2.Lanzar();
            }
        }

        //Habilidad 3
    }

    private void SetupSistemas(){
        sistemaDeVida = new SistemaDeVida();
        sistemaDeMana = new SistemaDeMana();
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();

    }
    
}
