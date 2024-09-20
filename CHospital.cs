using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CHospital
    {
        //ATRIBUTOS
        private ArrayList listaEmpleados;
        private ArrayList listaServicios;
        // CONSTRUCTOR
        public CHospital()
        {
            listaEmpleados = new ArrayList();
            listaServicios = new ArrayList();
        }
        // METODOS
        public bool AgregarEmpleado(CEmpleado empleado)
        {
            CEmpleado aux = BuscarEmpleado(empleado.GetLegajo());
            if (aux == null)
            {
                listaEmpleados.Add(empleado);
                return true;
            }
            else return false;
        }
        public CEmpleado BuscarEmpleado(ulong legajo)
        {
            foreach (CEmpleado aux in listaEmpleados)
            {
                if(aux.GetLegajo() == legajo)
                {
                    return aux;
                }
            }
            return null;
        }
        public string MostrarEmpleados()
        {
            string datos = "";
            if(listaEmpleados.Count == 0) { return datos = "NO HAY EMPLEADOS REGISTRADOS"; }
            datos = "EMPLEADOS: ";
            foreach (CEmpleado aux in this.listaEmpleados)
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
        public int ContadorMedicos()
        {
            int contador = 0;
            CSanidad empleado; 
            foreach(CEmpleado aux in listaEmpleados)
            {
                if(aux is CSanidad)
                {
                    empleado = (CSanidad)aux;
                    if(empleado.GetCategoria() == Categoria.Medico)
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }
        public bool AgregarServicio(CServicio servicio)
        {
            CServicio aux = BuscarServicio(servicio.GetCodigo());
            if (aux == null)
            {
                listaServicios.Add(servicio);
                return true;
            }
            else return false;
        }
        public CServicio BuscarServicio(string codigo)
        {
            foreach (CServicio aux in listaServicios)
            {
                if (aux.GetCodigo() == codigo)
                {
                    return aux;
                }
            }
            return null;
        }
        public bool AgregarEmpleadoAServicio(string codigo, ulong legajo)
        {
            CServicio servicio = BuscarServicio(codigo);
            CEmpleado empleado = BuscarEmpleado(legajo);
            if (empleado != null && servicio != null)
            {
                if(empleado is CSanidad)
                {
                CSanidad AUX;
                    AUX = (CSanidad)empleado;
                    if(AUX.GetCategoria() == Categoria.Medico && empleado.GetTieneServicio() == true) { return false; }
                    if (AUX.GetCategoria() == Categoria.Enfermero && empleado.GetTieneServicio() == true) { return false; }
                } 
                servicio.AgregarEmpleado(empleado);
                empleado.SetTieneServicio(); 
                return true;
            }
            return false;
        }
        public string ListarEmpleados(ulong legajo)
        {
            string datos = "";
            CEmpleado empleado = BuscarEmpleado(legajo);
            datos += empleado.ToString();
            foreach(CServicio aux in listaServicios)
            {
                if(aux.BuscarEmpleado(legajo) != null)
                {
                    datos += "\nNombre de servicio: " + aux.GetNombre();
                }
            }
            return datos;
        }
        public bool RemoverEmpleado(ulong legajo)
        {
            foreach (CEmpleado aux in this.listaEmpleados)
            {
                if (BuscarEmpleado(legajo) != null)
                {
                    this.listaEmpleados.Remove(BuscarEmpleado(legajo));
                    return true;
                }
            }
            return false;
        }
        public string ListarServicios() 
        {
            string datos = "";
            if(this.listaServicios.Count == 0) { return datos = "NO HAY SERVICIOS REGISTRADOS";  }
            datos = "Servicios: \n";
            foreach (CServicio servicio in listaServicios)
            {
                datos += "\nNombre del servicio: " + servicio.GetNombre();
                datos += "\nCantidad de empleados: " + servicio.CantidadEmpleados().ToString();
                datos += "\nTotal de haberes mensuales: " + servicio.TotalHaberes().ToString(); 
            }
            return datos;
        }
    }
}
