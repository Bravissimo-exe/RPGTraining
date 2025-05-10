using UnityEngine;

public abstract class Habilidad : MonoBehaviour
{
    [SerializeField] private string nombre;
    [SerializeField] private Sprite icono;
    [SerializeField] private string descripcion;
    [SerializeField] private float consumo;
    [SerializeField] private float coolDown;


    public Habilidad(string nombre, Sprite icono, string descripcion, float consumo, float coolDown)
    {
        this.Nombre = nombre;
        this.Icono = icono;
        this.Descripcion = descripcion;
        this.Consumo = consumo;
        this.CoolDown = coolDown;
    }
    public Habilidad(string nombre)
    {
        this.Nombre = nombre;
        this.Icono = null;
        this.Descripcion = "Descripcion de habilidad genérica";
        this.Consumo = 10;
        this.CoolDown = 5f;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public Sprite Icono { get => icono; set => icono = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public float Consumo { get => consumo; set => consumo = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }

    public abstract void Lanzar();

}
