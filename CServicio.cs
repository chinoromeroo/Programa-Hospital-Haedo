using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CServicio
    {
        // ATRIBUTOS
        private string codigo;
        private string nombre;
        private CEmpleado jefe;
        private ArrayList listaPersonal;
        // CONSTRUCTOR
        public CServicio(string cod, string nom)
        {
            this.codigo = cod;
            this.nombre = nom;
            listaPersonal = new ArrayList();
        }
        // GETTERS Y SETTERS
        public void SetCodigo(string cod) {  this.codigo = cod; }
        public void SetNombre(string nom) {  this.nombre = nom; }
        public void SetJefe(CEmpleado j) 
        { 
            this.jefe = j;
            j.SetTieneServicio();
            this.listaPersonal.Add(j);
        }
        public CEmpleado GetJefe() { return this.jefe; }
        public string GetCodigo() {  return this.codigo; }
        public string GetNombre() { return this.nombre; }
        // METODOS
        public bool AgregarEmpleado(CEmpleado empleado)
        {
            CEmpleado aux = BuscarEmpleado(empleado.GetLegajo());
            if (aux == null)
            {
                listaPersonal.Add(empleado);
                return true;
            }
            else return false;
        }
        public CEmpleado BuscarEmpleado(ulong legajo)
        {
            foreach (CEmpleado aux in listaPersonal)
            {
                if (aux.GetLegajo() == legajo)
                {
                    return aux;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string datos = "\nCodigo: " + this.codigo;
            datos += "\nNombre " + this.nombre;
            datos = "\nEmpleados: ";
            foreach (CEmpleado aux in this.listaPersonal)
            {
                if (aux is CApoyo)
                {
                    datos += "\n\nPersonal de Apoyo: \n";
                    datos += aux.ToString();
                }
                else
                {
                    datos += "\n\nPersonal de Sanidad: \n";
                    datos += aux.ToString();
                }
            }

            return datos;
        }
        //fffff
        public bool RemoverEmpleadoServicio(ulong legajo)
        {
            foreach (CEmpleado aux in this.listaPersonal)
            {
                if (BuscarEmpleado(legajo) != null)
                {
                    this.listaPersonal.Remove(BuscarEmpleado(legajo));
                    return true;
                }
            }
            return false;
        }

        public int CantidadEmpleados()
        {
            int contador = 0;
            foreach(CEmpleado aux in listaPersonal)
            {
                contador++;
            }
            return contador;
        }
        public float TotalHaberes()
        {
            float acum = 0;
            foreach (CEmpleado aux in listaPersonal)
            {
                acum += aux.HaberMensual();
            }
            return acum;
        }
    }
}
