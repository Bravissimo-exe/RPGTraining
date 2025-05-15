using JetBrains.Annotations;
using UnityEngine;

public class PruebaScale : MonoBehaviour
{
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
}
