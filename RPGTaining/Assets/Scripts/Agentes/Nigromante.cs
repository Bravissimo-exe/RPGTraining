using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Nigromante : PortadorJugable
{
    [Header("Referencias habilidad1")]
    [SerializeField] private GameObject prefabBola;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    [Header("Referencias habilidad2")]
    [SerializeField] private GameObject prefabZona;
    [SerializeField] private Transform spawnPoint;

    private BolaDeSangre habilidad1;
    private SangrePutrefacta habilidad2;
    private ApropiacionSanguinea habilidad3;
    private bool corriendoGastoVida;

    public Nigromante(string nombre, SistemaDeVida sistemaDeVida, SistemaDeMana sistemaDeMana, SistemaDeHabilidades sistemaDeHabilidades) : base(nombre, sistemaDeVida, sistemaDeMana, sistemaDeHabilidades)
    {
    }

    // Eliminar el constructor (no válido en MonoBehaviour)
    void Start()
    {
        InicializarVida(500);
        InicializarHabilidades();
        InicializarHabilidadBola();
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
        habilidad1 = new BolaDeSangre("Bola De Sangre");
        habilidad1.PrefabsSetters(shootPoint, rotacionCamara); // Pasamos la REFERENCIA al Transform
    }

    private void InicializarHabilidadZona()
    {
        habilidad2 = new SangrePutrefacta("Sangre putrefacta");
        habilidad2.PrefabsSetters(spawnPoint);
    }

    private void InicializacionHabilidadCura()
    {
        habilidad3 = new ApropiacionSanguinea("Apropiacion Sanguinea");
        
    }

    void Update()
    {

        //Habilidad 1

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (habilidad1 != null)
            {
                habilidad1.Instanciar(prefabBola);
            }
        }

        if (Input.GetKey(KeyCode.Alpha1))
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
            if (habilidad1 != null)
            {
                habilidad1.Lanzar();
                Debug.Log("Bola lanzada!");
            }

        }

        //Habilidad 2

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (habilidad2 != null)
            {
                habilidad2.Instanciar(prefabZona);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            habilidad2.Mantener(spawnPoint);
        }

        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (habilidad2 != null)
            {
                habilidad2.Lanzar();
                RecibirDaño(20);
            }
        }

        //Habilidad 3

        if (Input.GetKey(KeyCode.Alpha3))
        {
            habilidad3.Raycast(transform, sistemaVida);
            
        }
    }


    public IEnumerator GastoVida()
    {
        corriendoGastoVida = true;

        while (Input.GetKey(KeyCode.Alpha1))
        {
            RecibirDaño(1); // Quita 1 de vida cada cierto tiempo
            yield return new WaitForSeconds(100000f); // <-- AJUSTA AQUÍ la velocidad (por ejemplo, 1.5 segundos entre cada daño)
        }
    }
}
