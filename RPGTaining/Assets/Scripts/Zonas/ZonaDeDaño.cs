using UnityEngine;

public class ZonaDeDaño : MonoBehaviour
{
	public void OnTriggerStay(Collider collider)
	{

		IDañable dañable = collider.gameObject.GetComponent<IDañable>();
		if (dañable != null)
		{
			dañable.RecibirDaño(1);
		}

		GameObject otherObject = collider.gameObject;
		Debug.Log("Colisión con: " + otherObject.name);
	}

}