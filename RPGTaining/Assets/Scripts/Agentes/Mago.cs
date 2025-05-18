using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mago : PortadorJugable
{
    private GameObject camara;


    [Header("Referencias Habilidad 1")]
    [SerializeField] private List<GameObject> prefabsBolas = new List<GameObject>();
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    [SerializeField] private Sprite icono1;

    [Header("Referencias Habilidad 2")]
    [SerializeField] private Sprite icono2;

    [Header("Referencias Habilidad 3")]
    [SerializeField] private GameObject prefabZona;
    [SerializeField] private Transform shootPointZona;
    [SerializeField] private Sprite icono3;

    //variables para la Habilidad 1
    private float _ultimoCast1;
    private bool _pasoPorCarga = false;

    //Variables para la Habilidad 2
    private float _ultimoCast2;

    //Variables para la Habilidad 3
    private float _ultimoCast3;

    //UI
    private UIHabilidades uiHabilidades;
    private UIMana uiMana;
    private UIVida uiVida;

    public Mago(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades)
    {
    }

    //Unity obviamente no usa el constructor cuando se instancia un MonoBehaviour
    //Por lo que las cosas las debemos inicializar en el Awake

    void Start()
    {
        camara = GameObject.Find("Camara");
        uiHabilidades = FindFirstObjectByType<UIHabilidades>();
        uiVida = FindFirstObjectByType<UIVida>();
        uiMana = FindFirstObjectByType<UIMana>();

        SetupSistemas();

        sistemaDeHabilidades.AñadirHabilidad(new BolaDeLuz(icono1));
        sistemaDeHabilidades.AñadirHabilidad(new CuracionDivina(icono2));
        sistemaDeHabilidades.AñadirHabilidad(new RayoCelestial(icono3));

        uiHabilidades.AsignarIconos(icono1, icono2, icono3);
        SetupCooldownHabilidades();
    }

    void Update()
    {
        ActualizarUIHabilidades();
        uiVida.ActualizarUIVida(sistemaVida.valorActual, sistemaVida.valorMax);
        uiMana.ActualizarMana(sistemaDeMana.valorActual, sistemaDeMana.valorMax);
       


        //Habilidad 1
        if (Input.GetKeyDown(KeyCode.Alpha1) && Disponible1())
        {
            if (sistemaDeHabilidades.Habilidades[0] is BolaDeLuz habilidad1)
            {
                _pasoPorCarga = true;
                habilidad1.EmpezarCarga(this);
                sistemaDeMana.valorActual -= habilidad1.Consumo;
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
                habilidad2.Usar(this);
                _ultimoCast2 = Time.time;
                sistemaDeMana.valorActual -= habilidad2.Consumo;
            }
        }

        //Habilidad 3
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Disponible3())
        {
            if (sistemaDeHabilidades.Habilidades[2] is RayoCelestial habilidad3)
            {
                habilidad3.Usar(prefabZona, shootPointZona);
                _ultimoCast3 = Time.time;
                sistemaDeMana.valorActual -= habilidad3.Consumo;
            }
        }
    }

    public void SetupSistemas()
    {
        sistemaVida = new SistemaDeVida();
        sistemaDeMana = new SistemaDeMana();
        sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();
    }

    public void SetupCooldownHabilidades()
    {
        _ultimoCast1 = sistemaDeHabilidades.Habilidades[0].CoolDown * -1;
        _ultimoCast2 = sistemaDeHabilidades.Habilidades[1].CoolDown * -1;
        _ultimoCast3 = sistemaDeHabilidades.Habilidades[2].CoolDown * -1;
    }

    private bool Disponible1()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[0].Consumo)
        {
            if (Time.time - _ultimoCast1 >= sistemaDeHabilidades.Habilidades[0].CoolDown)
                return true;
        }
        return false;
    }

    private bool Disponible2()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[1].Consumo)
        {
            if (Time.time - _ultimoCast2 >= sistemaDeHabilidades.Habilidades[1].CoolDown)
            {
                return true;
            }
        }
        return false;
    }

    private bool Disponible3()
    {
        if (sistemaDeMana.valorActual >= sistemaDeHabilidades.Habilidades[2].Consumo)
        {
            if (Time.time - _ultimoCast3 >= sistemaDeHabilidades.Habilidades[2].CoolDown)
            {
                return true;
            }
        }
        return false;
    }

    private void ActualizarUIHabilidades()
    {
        float restante1 = Mathf.Clamp(sistemaDeHabilidades.Habilidades[0].CoolDown - (Time.time - _ultimoCast1), 0, Mathf.Infinity);
        float restante2 = Mathf.Clamp(sistemaDeHabilidades.Habilidades[1].CoolDown - (Time.time - _ultimoCast2), 0, Mathf.Infinity);
        float restante3 = Mathf.Clamp(sistemaDeHabilidades.Habilidades[2].CoolDown - (Time.time - _ultimoCast3), 0, Mathf.Infinity);

        uiHabilidades.ActualizarEstadoHabilidad(0, Disponible1(), restante1);
        uiHabilidades.ActualizarEstadoHabilidad(1, Disponible2(), restante2);
        uiHabilidades.ActualizarEstadoHabilidad(2, Disponible3(), restante3);
    }
    
}
