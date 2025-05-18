using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Nigromante : PortadorJugable
{
    [Header("Referencias")]
    [SerializeField] private GameObject prefabBola;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotacionCamara;

    private BolaDeSangre habilidad1;
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
    }

    private void InicializarHabilidadBola()
    {
        habilidad1 = new BolaDeSangre("Bola De Sangre");
        habilidad1.PrefabsSetters(shootPoint, rotacionCamara); // Pasamos la REFERENCIA al Transform
    }

    void Update()
    {
        ActualizarVida(sistemaVida.valorActual);

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