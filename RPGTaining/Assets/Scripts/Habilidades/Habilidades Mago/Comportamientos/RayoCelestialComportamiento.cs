using UnityEngine;
using System.Collections.Generic;

public class RayoCelestialComportamiento : MonoBehaviour
{
    private int dañoPorTic;

    private float tiempoEntreChecks = 0.1f; // por ejemplo, 1 segundo
    private float tiempoSiguienteCheck = 0f;


    public int DañoPorTic { get => dañoPorTic; set => dañoPorTic = value; }

    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Time.time >= tiempoSiguienteCheck)
        {
            IDañable dañable = other.GetComponent<IDañable>();
            if (dañable != null)
                dañable.RecibirDaño(dañoPorTic);
                

            // Reprograma el próximo chequeo
            tiempoSiguienteCheck = Time.time + tiempoEntreChecks;
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     IDañable dañable = other.GetComponent<IDañable>();
    //     if (dañable != null)
    //         dañable.RecibirDaño(dañoPorTic);

    // }


}
