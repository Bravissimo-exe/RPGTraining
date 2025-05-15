using UnityEngine;

public class RayoCelestial : Habilidad
{
    private GameObject zonaPrefab;
    private Transform zonaPosicion;
    
    public RayoCelestial(string nombre) : base(nombre, null, "Holaquehace", 30, 10f)
    {
    }
    public RayoCelestial() : base("Rayo Celestial", null,"Descripción Rayo Celestial", 30, 6f) { }

    public void Usar(GameObject prefab, Transform posicion)
    {
        zonaPrefab = prefab;
        zonaPosicion = posicion;
        Lanzar();
    }

    public override void Lanzar()
    {
        Object.Instantiate(zonaPrefab, zonaPosicion);
    }

}
