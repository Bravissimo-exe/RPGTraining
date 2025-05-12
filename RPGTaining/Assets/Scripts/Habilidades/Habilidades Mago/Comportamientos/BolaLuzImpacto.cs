using System;
using UnityEngine;

public class BolaLuzImpacto : MonoBehaviour
{

    private int daño;

    public int Daño { get => daño; set => daño = value; }

    public void OnCollisionEnter(Collision collision)
    {
        IDañable dañable = collision.gameObject.GetComponent<IDañable>();
        if(dañable != null){
            dañable.RecibirDaño(daño);
        }

        Destroy(gameObject);
    }
}
