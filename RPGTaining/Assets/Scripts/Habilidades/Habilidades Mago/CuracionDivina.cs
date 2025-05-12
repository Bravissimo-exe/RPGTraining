using UnityEngine;

public class CuracionDivina : Habilidad
{
    private int cantidadCuracion;
    private float ultimoCast;

    public CuracionDivina(string nombre) : base(nombre, null, "Descripción Curación", 30, 12)
    {
    }
    public CuracionDivina() : base ("Curación Divina", null,"Descripción Curación", 30, 12){
    }


    public override void Lanzar(){
        if(Time.time - ultimoCast < CoolDown)
            return;
        
        Debug.Log("Lancé curación");
        //puedo hacer aparecer una luz encima, después miro
        ultimoCast = Time.time;
    }
}
