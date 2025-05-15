using UnityEngine;

public class BolaSangreImpacto : MonoBehaviour
{
    private Vector3 scaleChange;
    void Start()
    {
        scaleChange = new Vector3(0.001f, 0.001f, 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        scaleChange = new Vector3(0.001f, 0.001f, 0.001f);
    }
}
