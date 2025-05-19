using UnityEngine;

public class ApropiacionSanguinea : Habilidad
{

     public ApropiacionSanguinea(Sprite icono) : base("Apropiacion sanguinea", icono, "Mirada que roba vida", 0, 15f)
    {
    }

    public ApropiacionSanguinea(string nombre) : base(nombre)
    {
    }


    public void Raycast(Transform posicion, SistemaDeVida sistemaDeVida)
    {

        RaycastHit hit;
        Ray ray = new Ray(posicion.position, posicion.forward);
        if (Physics.Raycast(ray, out hit, 100f)) // 100f es el rango del raycast
        {
            if (hit.collider.CompareTag("NPC"))
            {
                IDañable dañable = hit.collider.gameObject.GetComponent<IDañable>();
                if (dañable != null)
                {
                    if(sistemaDeVida.valorActual < sistemaDeVida.valorMax)
                    dañable.RecibirDaño(1);
                    sistemaDeVida.Curar(1);
                    
                }
            }
        }
    }

    public override void Lanzar()
    {
        throw new System.NotImplementedException();
    }
}
