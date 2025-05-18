using UnityEngine;

public class BolaSangreImpacto : MonoBehaviour
{

    private int daño;

    public int Daño { get => daño; set => daño = value; }
    private Vector3 scaleChange;
    void Start()
    {
        scaleChange = new Vector3(0.001f, 0.001f, 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += scaleChange;
    }

    public void OnCollisionEnter(Collision otro)
    {
        if (otro.gameObject.tag != "Player")
        { 
            IDañable dañable = otro.gameObject.GetComponent<IDañable>();
            if (dañable != null)
            {
                dañable.RecibirDaño(daño);
                Destroy(gameObject);
            }
        }
        
    }
}
