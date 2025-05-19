using UnityEngine;

public class SangrePutrefacta : Habilidad
{
    //Referencias para Instanciar las habilidades
    private Transform spawnPoint;
    
    private Collider zonaC;
    private GameObject instanciaZona;

    private Quaternion rotacion = new Quaternion(0,0,0,0);

     public SangrePutrefacta(Sprite icono) : base("Sangre putrefacta", icono, "Charco de sangre que consume Vida", 10, 5f)
    {
    }

    public void PrefabsSetters(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }

    public void Instanciar(GameObject zona)
    {
        if (instanciaZona == null)
        {
            instanciaZona = Object.Instantiate(zona, spawnPoint.position, rotacion);
            instanciaZona.GetComponent<Collider>().enabled = false;
            Debug.Log("instanciado");
        }
    }

    public void Mantener(Transform point)
    {
        instanciaZona.transform.position = point.position;
        instanciaZona.GetComponent<Collider>().enabled = false;
        Debug.Log("mantenido");
    }

    public override void Lanzar()
    {
        if (instanciaZona != null)
        {
            instanciaZona.GetComponent<Collider>().enabled = true;
            instanciaZona.GetComponent<SangrePutrefactaComportamiento>().Daño = 1;
            instanciaZona = null; // Permitir crear una nueva instancia
            Debug.Log("soltado");
        }
    }

}
