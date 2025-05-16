using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeSangre : Habilidad
{
    private int dañoBase = 10;
    private int nivelCarga = 0;
    private int cargaMaxima = 3;
    private float tiempoPorCarga = 1f;
    private float ultimoCast;
    private Coroutine rutinaCarga;
    private MonoBehaviour controladorMono;

    //Referencias para Instanciar las habilidades
    private GameObject prefabsBolas;
    private Transform prefabPosicion;
    private Transform prefabRotacion;

    GameObject instanciaBola;

    public BolaDeSangre(string nombre, Sprite icono, string descripcion, int consumo, float coolDown) : base(nombre, icono, descripcion, consumo, coolDown)
    {
    }

    public BolaDeSangre(String nombre) : base(nombre)
    {
    }

    private IEnumerator Cargar()
    {
        nivelCarga = 1;
        while (nivelCarga < cargaMaxima)
        {
            yield return new WaitForSeconds(tiempoPorCarga);
            nivelCarga++;
            Debug.Log("Carga Actual: " + nivelCarga);//Reemplazar por verlo en UI

        }
    }

    public void EmpezarCarga(MonoBehaviour mono)
    {
        controladorMono = mono;
        rutinaCarga = mono.StartCoroutine(Cargar());


    }

    public void SoltarCarga(GameObject bolaSangre, Transform posicion, Transform rotacion)
    {
        prefabsBolas = bolaSangre;
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

        Rigidbody rb;



        if (instanciaBola != null)
        {
            instanciaBola.GetComponent<BolaLuzImpacto>().Daño = dañoBase * nivelCarga;
            UnityEngine.Object.Destroy(instanciaBola, 5f);
            rb = instanciaBola.GetComponent<Rigidbody>();
            rb.linearVelocity = prefabRotacion.forward * 10f;
        }

        ultimoCast = Time.time;
        nivelCarga = 0;
    }
    
}
