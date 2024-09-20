using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CConsultorio
    {
        // ATRIBUTOS
        private ulong numero;
        private int piso;
        private string sector;
        private ArrayList listaServicios;

        // CONSTRUCTOR
        public CConsultorio(ulong num, int p, string sect)
        {
            this.numero = num;
            this.piso = p;
            this.sector = sect;
            listaServicios = new ArrayList();
        }
        // METODOS
        public ulong GetNumero() { return this.numero; }
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
        public override string ToString()
        {
            string datos = "Numero: " + this.numero;
            datos += "\nPiso: " + this.piso;
            datos += "\nSector: " + this.sector;
            return datos;
        }
    }
}
