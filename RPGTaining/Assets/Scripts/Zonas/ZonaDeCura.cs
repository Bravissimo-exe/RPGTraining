using UnityEngine;

public class ZonaDeCura : MonoBehaviour
{
    public void OnTriggerStay(Collider collider)
    {
        Debug.Log("sexo");
        ICurable curable = collider.gameObject.GetComponent<ICurable>();
        if(curable != null){
            curable.Curar(1);
        }
    }
}
