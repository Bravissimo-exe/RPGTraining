using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BolaDeLuz : Habilidad
{

    private int dañoBase = 10;
    private int nivelCarga = 0;
    private int cargaMaxima = 3;
    private float tiempoPorCarga = 1f;
    private float ultimoCast;
    private Coroutine rutinaCarga;
    private MonoBehaviour controladorMono;

    //Referencias para Instanciar las habilidades
    private List<GameObject> prefabsBolas;
    private Transform prefabPosicion;
    private Transform prefabRotacion;



    public BolaDeLuz(string nombre, Sprite icono, string descripcion, float consumo, float coolDown) : base(nombre, icono, descripcion, consumo, coolDown)
    {
    }

    public BolaDeLuz(string nombre) : base(nombre, null, "Descripcion de habilidad genérica", 10f, 5f)
    {
    }
    public BolaDeLuz() : base("Bola de Luz", null, "Descripción Bola de Luz", 10f, 3f){
    }

    private IEnumerator Cargar(){
        nivelCarga = 1;
        while(nivelCarga < cargaMaxima){
            yield return new WaitForSeconds(tiempoPorCarga);
            nivelCarga++;
            Debug.Log("Carga Actual: " + nivelCarga);//Reemplazar por verlo en UI
        }
    }

    public void EmpezarCarga(MonoBehaviour mono){
        controladorMono = mono;
        rutinaCarga = mono.StartCoroutine(Cargar());
    }

    public void SoltarCarga(List<GameObject> prefabs, Transform posicion, Transform rotacion){
        prefabsBolas = prefabs;
        prefabPosicion = posicion;
        prefabRotacion = rotacion;

        if (rutinaCarga != null)
        {
            // Cancela la carga si aún está en progreso
            // (si no es qué simplemente ya terminó)
            controladorMono.StopCoroutine(rutinaCarga);
        }

        Lanzar();
    }

    public override void Lanzar()
    {
        GameObject instanciaBola;
        Rigidbody rb;
        switch (nivelCarga)
        {
            case 1:
                //Instanciar Carga 1
                Debug.Log("Lancé una bola de luz de 1 carga");
                instanciaBola = Object.Instantiate(prefabsBolas[0], prefabPosicion.position, prefabRotacion.rotation);
                break;
            case 2:
                //Instanciar Carga 2
                Debug.Log("Lancé una bola de luz de 2 cargas");
                instanciaBola = Object.Instantiate(prefabsBolas[1], prefabPosicion.position, prefabRotacion.rotation);
                break;
            case 3:
                //Instanciar Carga 3
                Debug.Log("Lancé una bola de luz de 3 cargas");
                instanciaBola = Object.Instantiate(prefabsBolas[2], prefabPosicion.position, prefabRotacion.rotation);
                break;
            default:
                instanciaBola = null;
                break;
        }

        if(instanciaBola != null){
            instanciaBola.GetComponent<BolaLuzImpacto>().Daño = dañoBase * nivelCarga;
            Object.Destroy(instanciaBola, 5f);
            rb = instanciaBola.GetComponent<Rigidbody>();
            rb.linearVelocity = prefabRotacion.forward * 10f;
        }
        
        ultimoCast = Time.time;
        nivelCarga = 0;
    }
}
