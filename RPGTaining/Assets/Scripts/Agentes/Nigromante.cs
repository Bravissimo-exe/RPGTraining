using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Nigromante : PortadorJugable
{
    [Header("Referencias habilidad1")]
    [SerializeField] private Sprite icono1;
    [SerializeField] private GameObject prefabBola;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;
    private BolaDeSangre habilidad1;
    private float _ultimoCast1;

    [Header("Referencias habilidad2")]
    [SerializeField] private Sprite icono2;
    [SerializeField] private GameObject prefabZona;
    [SerializeField] private Transform spawnPoint;
    private SangrePutrefacta habilidad2;
    private float _ultimoCast2;

    [Header("Referencias habilidad3")]
    [SerializeField] private Sprite icono3;
    private ApropiacionSanguinea habilidad3;
    private float _ultimoCast3;


    private bool corriendoGastoVida;
    private UIHabilidades uiHabilidades;

    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades)
    {
    }

    // Eliminar el constructor (no válido en MonoBehaviour)
    void Start()
    {
        uiHabilidades = FindAnyObjectByType<UIHabilidades>();
        InicializarVida(500);
        InicializarHabilidades();
        InicializarHabilidadBola();

        uiHabilidades.AsignarIconos(icono1, icono2, icono3);
        SetupCooldownHabilidades();
    }

    private void InicializarHabilidades()
    {
        // Obtener o crear SistemaDeHabilidades
        sistemaDeHabilidades = GetComponent<SistemaDeHabilidades>();
        if (sistemaDeHabilidades == null)
        {
            sistemaDeHabilidades = gameObject.AddComponent<SistemaDeHabilidades>();
        }

        // Crear y asignar la habilidad
        InicializarHabilidadBola();
        sistemaDeHabilidades.AñadirHabilidad(habilidad1);
        InicializarHabilidadZona();
        sistemaDeHabilidades.AñadirHabilidad(habilidad2);
        InicializacionHabilidadCura();
        sistemaDeHabilidades.AñadirHabilidad(habilidad3);
    }

    private void InicializarHabilidadBola()
    {
        habilidad1 = new BolaDeSangre(icono1);
        habilidad1.PrefabsSetters(shootPoint, rotacionCamara); // Pasamos la REFERENCIA al Transform
    }

    private void InicializarHabilidadZona()
    {
        habilidad2 = new SangrePutrefacta(icono2);
        habilidad2.PrefabsSetters(spawnPoint);
    }

    private void InicializacionHabilidadCura()
    {
        habilidad3 = new ApropiacionSanguinea(icono3);
    }

    void Update()
    {
        ActualizarUIHabilidades();
        ActualizarVida(sistemaVida.valorActual);

        //Habilidad 1

        if (Input.GetKeyDown(KeyCode.Alpha1) && Disponible1())
        {
            if (habilidad1 != null)
            {
                habilidad1.Instanciar(prefabBola);
            }
        }

        if (Input.GetKey(KeyCode.Alpha1) && Disponible1())
        {
            habilidad1.mantener(shootPoint, rotacionCamara);

            if (!corriendoGastoVida)
            {
                StartCoroutine(GastoVida());
            }
            corriendoGastoVida = false;
        }

        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            habilidad1.mantener(shootPoint, rotacionCamara);
            if (habilidad1 != null)
            {
                habilidad1.Lanzar();
                Debug.Log("Bola lanzada!");
                _ultimoCast1 = Time.time;
            }
        }

        //Habilidad 2

        if (Input.GetKeyDown(KeyCode.Alpha2) && Disponible2())
        {
            if (habilidad2 != null)
            {
                habilidad2.Instanciar(prefabZona);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2) && Disponible2())
        {
            habilidad2.Mantener(spawnPoint);
        }

        else if (Input.GetKeyUp(KeyCode.Alpha2) && Disponible2())
        {
            if (habilidad2 != null)
            {
                habilidad2.Lanzar();
                RecibirDaño(20);
                _ultimoCast2 = Time.time;
            }
        }

        //Habilidad 3

        if (Input.GetKey(KeyCode.Alpha3) && Disponible3())
        {
            habilidad3.Raycast(transform, sistemaVida);
        }

        if(Input.GetKeyUp(KeyCode.Alpha3) && Disponible3()) {
            _ultimoCast3 = Time.time;
        }
    }

    public void SetupCooldownHabilidades()
    {
        _ultimoCast1 = sistemaDeHabilidades.Habilidades[0].CoolDown * -1;
        _ultimoCast2 = sistemaDeHabilidades.Habilidades[1].CoolDown * -1;
        _ultimoCast3 = sistemaDeHabilidades.Habilidades[2].CoolDown * -1;
    }


    public IEnumerator GastoVida()
    {
        corriendoGastoVida = true;

        while (Input.GetKey(KeyCode.Alpha1))
        {
            RecibirDaño(1); // Quita 1 de vida cada cierto tiempo
            yield return new WaitForSeconds(100000f);
        }
    }
    
    private bool Disponible1()
    {
        if (sistemaVida.valorActual >= sistemaDeHabilidades.Habilidades[0].Consumo)
        {
            if (Time.time - _ultimoCast1 >= sistemaDeHabilidades.Habilidades[0].CoolDown)
                return true;
        }
        return false;
    }

    private bool Disponible2()
    {
        if (sistemaVida.valorActual >= sistemaDeHabilidades.Habilidades[1].Consumo)
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
        if (sistemaVida.valorActual >= sistemaDeHabilidades.Habilidades[2].Consumo)
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
