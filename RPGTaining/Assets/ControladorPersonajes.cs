using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonajes : MonoBehaviour
{
    [SerializeField]private GameObject panelMana;
    GameObject objM, objN;
    // Update is called once per frame
    void Update()
    {
        objM = GameObject.Find("Mago");
        if (objM != null)
        {
            panelMana.SetActive(true);
        }

        else if (objM == null)
        {
            panelMana.SetActive(false);
        }
        
        if(objM != null && objN != null)
        {
            Debug.Log("O lo uno o lo otro!!!");
        }
    }
}
