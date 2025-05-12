using UnityEngine;

public class ZonaDeDaño : MonoBehaviour
{
    public void OnTriggerStay(Collider collider)
    {
        Debug.Log("sexo");
        IDañable dañable = collider.gameObject.GetComponent<IDañable>();
        if(dañable != null){
            dañable.RecibirDaño(1);
        }
        
    }
}