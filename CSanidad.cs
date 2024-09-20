using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HospitaInterzonallHaedo
{
    public class CSanidad : CEmpleado
    {
        // ATRIBUTOS
        private ulong legajo;
        private string apellido;
        private string nombre;
        private int año;

        private Categoria categoria;
        private ulong matricula;

        private string especializacion;

        private Rol rol;

        private static float bonoMedico;
        private static float bonoEnfermero;
        private static float bonoTecnico;

        // CONSTRUCTOR
        public CSanidad(ulong leg, string ape, string nom, int a, Categoria cate, ulong mat, string esp) :base( leg, ape, nom, a)
        {
            this.categoria = cate;
            this.matricula = mat;
            this.especializacion = esp;
        }
        // GETTERS Y SETTERS

        public void SetRol(Rol r) { this.rol = r; }
        public Rol GetRol() { return this.rol; }
        public Categoria GetCategoria() { return this.categoria; }

        public static void SetBono(float bon, Categoria cat) 
        {
            if(cat == Categoria.Medico) { CSanidad.bonoMedico = bon; }
            if(cat == Categoria.Enfermero) { CSanidad.bonoEnfermero = bon; }
            if(cat == Categoria.Tecnico) { CSanidad.bonoTecnico = bon; }
        }
        public static float GetBono(Categoria cat)
        {
            if (cat == Categoria.Medico) { return CSanidad.bonoMedico; }
            if (cat == Categoria.Enfermero) { return CSanidad.bonoEnfermero; }
            if (cat == Categoria.Tecnico) { return CSanidad.bonoTecnico; }
            return 0;
        }

        // METODOS
        public float BonoProfesional()
        {
            float total = 0;
            if(categoria == Categoria.Medico)
            {
                if (this.GetTieneServicio())
                {
                    if (rol == Rol.Jefe_Servicio){ total = HaberMensual() + bonoMedico * (float)1.5; }
                    if (rol == Rol.Medico_Titular) { total = HaberMensual() + bonoMedico * (float) 1.0; }
                    if (rol == Rol.Medico_Asociado) { total = HaberMensual() + bonoMedico * (float)0.8; }
                    if (rol == Rol.Residente) { total = HaberMensual() + bonoMedico * (float)0.5; }
                } else total = HaberMensual();
            }
            if (categoria == Categoria.Enfermero)
            {
                total = HaberMensual() + bonoEnfermero;
            }
            if(categoria == Categoria.Tecnico)
            {
                total = HaberMensual() + bonoTecnico;
            }
            return total;
        }
        public override string ToString()
        {
            string datos = base.ToString();
            datos += "\nCategoria: " + this.categoria + "\nMatricula: " + this.matricula;
            datos += "\nEspecializacion: " + this.especializacion;
            if (categoria == Categoria.Medico)
            {
                if (this.GetTieneServicio())
                {
                    datos += "\nRol del medico: " + this.rol;
                }
            }
            datos += "\nHaber Mensual: " + this.BonoProfesional() + "\n";
            return datos;
        }

    }
}
