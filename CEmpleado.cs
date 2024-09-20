using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CEmpleado
    {
        // ATRIBUTOS
        private ulong legajo;
        private string apellido;
        private string nombre;
        private int año;

        private bool tieneServicio = false;
        private static float monto;

        // CONSTRUCTOR 
        public CEmpleado( ulong leg, string ape, string nom, int a)
        {
            this.legajo = leg;
            this.apellido = ape;
            this.nombre = nom;
            this.año = a;
        }

        // GETTERS Y SETTERS
        public void SetTieneServicio() { this.tieneServicio = true; }
        public void SetFalaseAutomatico() { this.tieneServicio = false; }

        public bool GetTieneServicio() { return this.tieneServicio; }
        public static void SetMonto(float mon) { CEmpleado.monto = mon; }
        public static float GetMonto() { return CEmpleado.monto; }
        public ulong GetLegajo() { return this.legajo; }
        // METODOS
        public float HaberMensual()
        {
            float total = 0;
            int antiguedad = DateTime.Now.Year - año;
            if (antiguedad < 2) { total = CEmpleado.monto * (float)0.5; }
            if (antiguedad >= 2 && antiguedad < 4) { total = CEmpleado.monto * (float)0.7; }
            if (antiguedad >= 4 && antiguedad < 6) { total = CEmpleado.monto * (float)0.9; }
            if (antiguedad >= 6 && antiguedad < 8) { total = CEmpleado.monto * (float)1.10; }
            if (antiguedad >= 8 && antiguedad < 10) { total = CEmpleado.monto * (float)1.30; }
            if (antiguedad >= 10 && antiguedad < 12) { total = CEmpleado.monto * (float)1.50; }
            if (antiguedad >= 12 && antiguedad < 14) { total = CEmpleado.monto * (float)1.70; }
            if (antiguedad >= 14 && antiguedad < 16) { total = CEmpleado.monto * (float)1.90; }
            if (antiguedad >= 16 && antiguedad < 18) { total = CEmpleado.monto * (float)2.10; }
            if (antiguedad >= 18 && antiguedad < 20) { total = CEmpleado.monto * (float)2.30; }
            if (antiguedad >= 20) { total = CEmpleado.monto * (float)2.5; }

            return total;
        }
        public override string ToString()
        {
            string datos = "";
            datos += "Legajo: " + this.legajo + "\nApellido: " + this.apellido + "\nNombre: " + this.nombre + "\nAño de ingreso: " + this.año;
            return datos;
        }

    }
}
