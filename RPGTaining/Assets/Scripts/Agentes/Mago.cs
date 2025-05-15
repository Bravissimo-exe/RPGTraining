using System.Collections.Generic;
using UnityEngine;

public class Mago : PortadorJugable
{

    //Referencias
    //Habilidad1
    [SerializeField] private List<GameObject> prefabsBolas = new List<GameObject>();
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    //Referencias
    //Habilidad3
    [SerializeField] private GameObject prefabZona;
    [SerializeField] private Transform shootPointZona;

    //variables para la habilidad 1
    private float _ultimoCast1;
    private bool _pasoPorCarga = false;


    private float _ultimoCast2;
    private float _ultimoCast3;

    public Mago(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades)
    {
    }

    //Unity obviamente no usa el constructor cuando se instancia un MonoBehaviour
    //Por lo que las cosas las debemos inicializar en el Awake

    void Start()
    {
        AñadirVidaUiJugador(this.gameObject, sistemaVida.valorMax);
        SetupSistemas();
        sistemaDeHabilidades.AñadirHabilidad(new BolaDeLuz("Bola de Luz"));
        sistemaDeHabilidades.AñadirHabilidad(new CuracionDivina());
    }

    void Update()
    {
        ActualizarVida(sistemaVida.valorActual);

        // Debug.Log("Tiempo transcurrido: " + (Time.time - _ultimoCast1));
        // Debug.Log("holaaa: " + _ultimoCast1);

        //Habilidad 1
        if (Input.GetKeyDown(KeyCode.Alpha1) && Disponible1())
        {
            if (sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1)
            {
                _pasoPorCarga = true;
                habilidad1.EmpezarCarga(this);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) && Disponible1() && _pasoPorCarga)
        {
            if (sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1)
            {
                habilidad1.SoltarCarga(prefabsBolas, shootPoint, rotacionCamara);
                _pasoPorCarga = false;
                _ultimoCast1 = Time.time;
            }
        }

        //Habilidad 2
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Disponible2())
        {
            if (sistemaDeHabilidades.Habilidades[1] is CuracionDivina habilidad2)
            {
                habilidad2.Lanzar();
            }
        }

        //Habilidad 3
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Disponible3())
        {
            if (sistemaDeHabilidades.Habilidades[3] is RayoCelestial habilidad3)
            {
                habilidad3.Usar(prefabZona, shootPointZona);
            }
        }
    }

    public void SetupSistemas()
    {
        sistemaDeMana = new SistemaDeMana();
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();
    }

    private bool Disponible1()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[0].Consumo)
        {
            if (Time.time - _ultimoCast1 >= sistemaDeHabilidades.Habilidades[0].CoolDown)
            {
                return true;
            }
        }
        return false;
    }

    private bool Disponible2()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[1].Consumo){
            if (Time.time - _ultimoCast2 >= sistemaDeHabilidades.Habilidades[1].CoolDown){
                return true;
            }
        }
        return false;
    }

    private bool Disponible3()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[2].Consumo){
            if (Time.time - _ultimoCast3 >= sistemaDeHabilidades.Habilidades[2].CoolDown){
                return true;
            }
        }
        return false;
    }
    
}
