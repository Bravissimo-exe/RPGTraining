using UnityEngine;

public class SangrePutrefactaComportamiento : MonoBehaviour
{
    private int daño;

    public int Daño { get => daño; set => daño = value; }
    
    public void OnTriggerStay(Collider collider)
    {

        IDañable dañable = collider.gameObject.GetComponent<IDañable>();
        if (dañable != null && collider.tag != "Player")
        {
            dañable.RecibirDaño(1);
        }
        Destroy(gameObject, 3);
    }
}
