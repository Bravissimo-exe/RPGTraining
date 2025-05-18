using UnityEngine;

public class RayoCelestial : Habilidad
{
    private int dañoPorTic = 1;
    private float duracion = 5f;

    private GameObject zonaPrefab;
    private Transform zonaPosicion;
    
    public RayoCelestial(string nombre) : base(nombre, null, "Holaquehace", 30, 10f)
    {
    }
    public RayoCelestial() : base("Rayo Celestial", null,"Descripción Rayo Celestial", 30, 10f) { }

    public RayoCelestial(Sprite icono) : base("Rayo Celestial", icono, "Descripcion Rayo Celestial", 30, 10f) { }

    public void Usar(GameObject prefab, Transform posicion)
    {
        zonaPrefab = prefab;
        zonaPosicion = posicion;
        Lanzar();
    }

    public override void Lanzar()
    {
        GameObject instancia = Object.Instantiate(zonaPrefab, zonaPosicion.position, Quaternion.identity);
        instancia.GetComponent<RayoCelestialComportamiento>().DañoPorTic = dañoPorTic;
        Object.Destroy(instancia, duracion);
    }

}
