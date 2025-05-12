using UnityEngine;

public class RayoCelestial : Habilidad
{
    public RayoCelestial(string nombre) : base(nombre)
    {
    }

    public RayoCelestial(string nombre, Sprite icono, string descripcion, int consumo, float coolDown) : base(nombre, icono, descripcion, consumo, coolDown)
    {
    }

    public RayoCelestial() : base("Rayo Celestial", null, "Descripcion Rayo Celestial", 30, 15f){

    }

    

    public override void Lanzar()
    {
        throw new System.NotImplementedException();
    }
}
