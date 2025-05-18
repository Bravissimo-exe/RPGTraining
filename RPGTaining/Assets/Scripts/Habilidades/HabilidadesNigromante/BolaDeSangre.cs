using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BolaDeSangre : Habilidad
{
    private int dañoBase = 10;
    private float inicioCarga;
    private int finalCarga;

    //Referencias para Instanciar las habilidades
    private Transform firePoint;
    private Transform prefabRotacion;
    private Rigidbody bolaRb;

    GameObject instanciaBola;

    public BolaDeSangre(string nombre, Sprite icono, string descripcion, int consumo, float coolDown) : base(nombre, icono, descripcion, consumo, coolDown)
    {
    }

    public BolaDeSangre(string nombre) : base(nombre)
    {
    }

    public void PrefabsSetters(Transform firePoint, Transform prefabRotacion)
    {
        this.prefabRotacion = prefabRotacion;
        this.firePoint = firePoint;
    }

    public void Instanciar(GameObject bola)
    {
        if (instanciaBola == null)
        {
            instanciaBola = Object.Instantiate(bola, firePoint.position, prefabRotacion.rotation);
            bolaRb = instanciaBola.GetComponent<Rigidbody>();
            instanciaBola.GetComponent<Collider>().enabled = false;
            bolaRb.isKinematic = true;
            inicioCarga = Time.time;
        }
    }
    public void mantener(Transform point, Transform rotation)
    {

        instanciaBola.transform.position = point.position;
        instanciaBola.transform.rotation = rotation.rotation;
    }

    public override void Lanzar()
    {
        if (instanciaBola != null && bolaRb != null)
        {
            finalCarga = (int)(Time.time - inicioCarga);

            bolaRb.isKinematic = false;
            bolaRb.linearVelocity = prefabRotacion.forward * 30f; // Usar velocity en lugar de linearVelocity
            instanciaBola.GetComponent<Collider>().enabled = true;
            instanciaBola.GetComponent<BolaSangreImpacto>().Daño = (int)(dañoBase * (finalCarga + 5));
            instanciaBola = null; // Permitir crear una nueva instancia
            Debug.Log("Daño: " + (dañoBase * (finalCarga + 2.5)));
        }
    }

}
