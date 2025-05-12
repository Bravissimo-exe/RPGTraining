    using UnityEngine;

    public class CuracionDivina : Habilidad
    {
        private int cantidadCuracion;
        private float ultimoCast;

        private Portador portador;

        public CuracionDivina(string nombre) : base(nombre, null, "Descripción Curación", 30, 12)
        {
        }
        public CuracionDivina() : base ("Curación Divina", null,"Descripción Curación", 30, 12){
        }

        public void Usar(Portador portador, int cantidad){
            this.portador = portador;
            cantidadCuracion = cantidad;
            Lanzar();
        }

        public override void Lanzar(){
            Debug.Log("Lancé curación");
            portador.Curar(cantidadCuracion);
            //puedo hacer aparecer una luz encima, después miro
        }
    }
