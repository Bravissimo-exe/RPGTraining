using UnityEngine;

public class ExpropiacionSanguineaComportamiento : MonoBehaviour
{
     private int daño;

    public int Daño { get => daño; set => daño = value; }
    
    public void Quitar(GameObject otro)
    {
        IDañable dañable = otro.gameObject.GetComponent<IDañable>();
        if (dañable != null)
        {
            dañable.RecibirDaño(daño);
            Destroy(gameObject);
        }
    }
}
