using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CApoyo : CEmpleado
    {
        // ATRIBUTOS
        private ulong legajo;
        private string apellido;
        private string nombre;
        private int año;

        public CApoyo(ulong leg, string ape, string nom, int a) :base(leg, ape, nom, a){ }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += "\nHaber Mensual: " + this.HaberMensual();
            return datos;
        }
    }
}
