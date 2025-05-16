using UnityEngine;
using System.Collections.Generic;

public class RayoCelestialComportamiento : MonoBehaviour
{
    private int dañoPorTic;


    public int DañoPorSegundo { get => dañoPorTic; set => dañoPorTic = value; }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        IDañable dañable = other.GetComponent<IDañable>();
        if (dañable != null)
        {
            // dañable.RecibirDaño((int)(dañoPorTic * Time.deltaTime));
            dañable.RecibirDaño(dañoPorTic);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     IDañable dañable = other.GetComponent<IDañable>();
    //     if (dañable != null)
    //     {
    //         objetosDentro.Add(dañable);
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     IDañable dañable = other.GetComponent<IDañable>();
    //     if (dañable != null && objetosDentro.Contains(dañable))
    //     {
    //         objetosDentro.Remove(dañable);
    //     }
    // }

}
