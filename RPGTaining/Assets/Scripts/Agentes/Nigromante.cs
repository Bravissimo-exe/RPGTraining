using Unity.VisualScripting;
using UnityEngine;

public class Nigromante : PortadorJugable
{
    [SerializeField] private GameObject prefabBola;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    private float _ultimoCast1;
    private bool _pasoPorCarga;

    private GameObject camara;

    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeHabilidades)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camara = GameObject.Find("Camara");
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();
        AñadirVidaUiJugador(camara, sistemaVida.valorMax);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1) ){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeSangre habilidad1){
                _pasoPorCarga = true;
                habilidad1.EmpezarCarga(this);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Alpha1)  && _pasoPorCarga){
            if(sistemaDeHabilidades.Habilidades[0] is BolaDeSangre habilidad1){
                habilidad1.SoltarCarga(prefabBola, shootPoint, rotacionCamara);
                _pasoPorCarga = false;
                _ultimoCast1 = Time.time;
            }
        }
    }

    // private bool Disponible1(){
    //     if(sistemaVida.valorActual >= sistemaDeHabilidades.Habilidades[0].Consumo){
    //         if(Time.time - _ultimoCast1 >= sistemaDeHabilidades.Habilidades[0].CoolDown){
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
