using HospitaInterzonallHaedo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace HospitaInterzonallHaedo
{
    public class CControladora
    {
        static void Main()
        {
            char OPCION, ELEGIR;
            float MONTO, BONO;
            string datos, APELLIDO, NOMBRE, ESPECIALIDAD, CODIGO;
            int AÑO;
            ulong LEGAJO, MATRICULA;
            Categoria CATEGORIA;
            Rol ROL;
            CServicio SERVICIO;
            CSanidad SANIDAD;
            CEmpleado JEFE, EMPLEADO;
            CHospital hospital= new CHospital();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out OPCION);
                switch (OPCION)
                {
                    case 'A':
                        do
                        {
                            ELEGIR = CInterfaz.PedirDato("[A] Establecer monto [B] Establecer bonos [C] Informar montos y bonos").ToUpper()[0];
                            switch (ELEGIR)
                            {
                                case 'A':
                                    MONTO = Convert.ToSingle(CInterfaz.PedirDato("monto de referencia"));
                                    CEmpleado.SetMonto(MONTO);
                                    break;
                                case 'B':
                                    BONO = Convert.ToSingle(CInterfaz.PedirDato("Bono medicos "));
                                    CSanidad.SetBono(BONO, Categoria.Medico);
                                    BONO = Convert.ToSingle(CInterfaz.PedirDato("Bono enfermeros"));
                                    CSanidad.SetBono(BONO, Categoria.Enfermero);
                                    BONO = Convert.ToSingle(CInterfaz.PedirDato("Bono tecnicos "));
                                    CSanidad.SetBono(BONO, Categoria.Tecnico);
                                    break;
                                case 'C':
                                    datos = "";
                                    datos += "Monto: " + CEmpleado.GetMonto();
                                    datos += "\nBonos Medicos: " + CSanidad.GetBono(Categoria.Medico);
                                    datos += "\nBonos Enfermeros: " + CSanidad.GetBono(Categoria.Enfermero);
                                    datos += "\nBonos Tecnicos: " + CSanidad.GetBono(Categoria.Tecnico);
                                    CInterfaz.MostrarInfo(datos);
                                    break;
                                default:
                                    CInterfaz.MostrarInfo("Opcion no válida, ingrese una válida.");
                                    continue;
                            }
                            break;
                        } while (true);
                        break;
                    case 'B':
                        LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del empleado"));
                        APELLIDO = CInterfaz.PedirDato("el apellido del empleado");
                        NOMBRE = CInterfaz.PedirDato("el nombre del empleado");
                        AÑO = Convert.ToInt32(CInterfaz.PedirDato("el año de ingreso"));
                        do
                        {
                            ELEGIR = CInterfaz.PedirDato("[A] Empleado de apoyo [B] Medico [C] Enfermero [D] Tecnico").ToUpper()[0];
                            switch (ELEGIR)
                            {
                                case 'A':
                                    if (hospital.AgregarEmpleado(new CApoyo(LEGAJO, APELLIDO, NOMBRE, AÑO)))
                                    {
                                        CInterfaz.MostrarInfo("Se registro correctamente el empleado de apoyo");
                                    }
                                    else CInterfaz.MostrarInfo("No se pudo registrar al empleado de apoyo");
                                    break;
                                case 'B':
                                    CATEGORIA = Categoria.Medico;
                                    MATRICULA = Convert.ToUInt64(CInterfaz.PedirDato("la matricula del medico"));
                                    ESPECIALIDAD = CInterfaz.PedirDato("la especialidad del medico");
                                    SANIDAD = new CSanidad(LEGAJO, APELLIDO, NOMBRE, AÑO, CATEGORIA, MATRICULA, ESPECIALIDAD);
                                    if (hospital.AgregarEmpleado(SANIDAD))
                                    {
                                        CInterfaz.MostrarInfo("Se registro correctamente al medico");
                                    }
                                    else
                                    {
                                        CInterfaz.MostrarInfo("No se pudo registrar al medico");
                                    }
                                    break;
                                case 'C':
                                    CATEGORIA = Categoria.Enfermero;
                                    MATRICULA = Convert.ToUInt64(CInterfaz.PedirDato("la matricula del enfermero"));
                                    ESPECIALIDAD = CInterfaz.PedirDato("la especialidad del enfermero");
                                    SANIDAD = new CSanidad(LEGAJO, APELLIDO, NOMBRE, AÑO, CATEGORIA, MATRICULA, ESPECIALIDAD);
                                    if (hospital.AgregarEmpleado(SANIDAD))
                                    {
                                        CInterfaz.MostrarInfo("Se registro correctamente el enfermero");
                                    }
                                    else
                                    {
                                        CInterfaz.MostrarInfo("No se pudo registrar el enfermero");
                                    }
                                    break;
                                case 'D':
                                    CATEGORIA = Categoria.Tecnico;
                                    MATRICULA = Convert.ToUInt64(CInterfaz.PedirDato("la matricula del tecnico"));
                                    ESPECIALIDAD = CInterfaz.PedirDato("la especialidad del tecnico");
                                    SANIDAD = new CSanidad(LEGAJO, APELLIDO, NOMBRE, AÑO, CATEGORIA, MATRICULA, ESPECIALIDAD);
                                    if (hospital.AgregarEmpleado(SANIDAD))
                                    {
                                        CInterfaz.MostrarInfo("Se registro correctamente el tecnico");
                                    }
                                    else
                                    {
                                        CInterfaz.MostrarInfo("No se pudo registrar el tecnico");
                                    }
                                    break;
                                default:
                                    CInterfaz.MostrarInfo("Opcion no válida, ingrese una válida.");
                                    continue;
                            }
                            break;
                        } while (true);
                        break;
                    case 'C':
                        CInterfaz.MostrarInfo(hospital.MostrarEmpleados()); 
                        break;
                    case 'D':
                        if (hospital.ContadorMedicos() > 0)
                        {
                            CODIGO = CInterfaz.PedirDato("el codigo del servicio");
                            NOMBRE = CInterfaz.PedirDato("el nombre del servicio");
                            LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del medico que sera el Jefe de Servicio"));
                            JEFE = hospital.BuscarEmpleado(LEGAJO);
                            SERVICIO = new CServicio(CODIGO, NOMBRE);
                            if (hospital.AgregarServicio(SERVICIO) && JEFE != null)
                            {
                                CSanidad AUX;
                                AUX = (CSanidad)JEFE;
                                if (AUX.GetCategoria() == Categoria.Medico)
                                {
                                    AUX.SetRol(Rol.Jefe_Servicio);
                                    SERVICIO.SetJefe(JEFE);
                                    CInterfaz.MostrarInfo("Se agrego correctamente el servicio");
                                }
                                else CInterfaz.MostrarInfo("El legajo del empleado no pertenece a un medico");
                            }
                            else CInterfaz.MostrarInfo("No se pudo agregar el servicio");
                        }
                        else CInterfaz.MostrarInfo("No hay medicos registrados");
                        break;
                    case 'E': 
                        CODIGO = CInterfaz.PedirDato("el codigo del servicio");
                        if (hospital.BuscarServicio(CODIGO) != null)
                        {
                            LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del empleado"));
                            EMPLEADO = hospital.BuscarEmpleado(LEGAJO);
                            if (EMPLEADO != null)
                            {
                                if(EMPLEADO is CSanidad)
                                {
                                    SANIDAD = (CSanidad)EMPLEADO;
                                    if (SANIDAD.GetCategoria() == Categoria.Medico)
                                    {
                                        ELEGIR = CInterfaz.PedirDato("ROL DEL MEDICO --> [A] Medico Titular [B] Medico Asociado [C] Medico Residente").ToUpper()[0];
                                        do
                                        {
                                            switch (ELEGIR)
                                            {
                                                case 'A':
                                                    SANIDAD.SetRol(Rol.Medico_Titular);
                                                    break;
                                                case 'B':
                                                    SANIDAD.SetRol(Rol.Medico_Asociado);
                                                    break;
                                                case 'C':
                                                    SANIDAD.SetRol(Rol.Residente);
                                                    break;
                                                default:
                                                    CInterfaz.MostrarInfo("Opción Invalida");
                                                    continue;
                                            }
                                            break;
                                        }while (true);
                                    }
                                }
                                if (hospital.AgregarEmpleadoAServicio(CODIGO, LEGAJO))
                                {
                                    CInterfaz.MostrarInfo("Se pudo ingresar el empleado al servicio");
                                }
                                else CInterfaz.MostrarInfo("No se pudo agregar al empleado al servicio");
                            }
                            else CInterfaz.MostrarInfo("El empleado ingresado no existe");
                        }
                        else CInterfaz.MostrarInfo("El servicio ingresado no existe");
                        break;
                    case 'F':
                        CODIGO = CInterfaz.PedirDato("el codigo del servicio");
                        SERVICIO = hospital.BuscarServicio(CODIGO);
                        if (SERVICIO != null)
                        {
                            LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del nuevo Jefe de Servicio"));
                            JEFE = hospital.BuscarEmpleado(LEGAJO);
                            if (JEFE != null)
                            {
                                if (JEFE.GetLegajo() != SERVICIO.GetJefe().GetLegajo())
                                {
                                    SERVICIO.GetJefe().SetFalaseAutomatico(); // Deja de estar "asignado" a un servicio
                                    SERVICIO.RemoverEmpleadoServicio(SERVICIO.GetJefe().GetLegajo()); // Se lo elimina de la lista de empleados
                                    SERVICIO.SetJefe(JEFE);
                                    CInterfaz.MostrarInfo("El Jefe de Servicio fue cambiado de manera correcta");
                                }
                                else CInterfaz.MostrarInfo("El Jefe de Servicio ingresado es el mismo que el del servicio");
                            }
                            else CInterfaz.MostrarInfo("El Jefe de Servicio ingresado no existe");
                        }
                        else CInterfaz.MostrarInfo("El servicio ingresado no existe");
                        break;
                    case 'G':
                        CODIGO = CInterfaz.PedirDato("el codigo del servicio");
                        SERVICIO = hospital.BuscarServicio(CODIGO);
                        if (SERVICIO != null)
                        {
                            CInterfaz.MostrarInfo(SERVICIO.ToString());
                        }
                        else CInterfaz.MostrarInfo("No existe el servicio con codigo " + CODIGO.ToString());
                        break;
                    case 'H':
                        LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del empleado"));
                        if (hospital.BuscarEmpleado(LEGAJO) != null)
                        {
                            CInterfaz.MostrarInfo(hospital.ListarEmpleados(LEGAJO));
                        }
                        else CInterfaz.MostrarInfo("El legajo del empleado es inexistente");
                        break;
                    case 'I':
                        if(hospital.MostrarEmpleados() == "NO HAY EMPLEADOS REGISTRADOS") // If para evitar error en el GETTIENESERVICIO si se desea eliminar empleado y no hay registrados
                        {
                            CInterfaz.MostrarInfo("NO HAY EMPLEADOS REGISTRADOS PARA ELIMINAR");
                        }
                        else
                        {
                            LEGAJO = Convert.ToUInt64(CInterfaz.PedirDato("el legajo del empleado"));
                            EMPLEADO = hospital.BuscarEmpleado(LEGAJO);
                            if (!EMPLEADO.GetTieneServicio())
                            {
                                if (hospital.RemoverEmpleado(LEGAJO))
                                {
                                    CInterfaz.MostrarInfo("Se elimino el empleado correctamente");
                                }
                                else CInterfaz.MostrarInfo("No se pudo eliminar al empleado");
                            }
                            else CInterfaz.MostrarInfo("El empleado se encuentra en un servicio");
                        }
                        break;
                    case 'J':
                        CInterfaz.MostrarInfo(hospital.ListarServicios());
                        break;
                }
            } while (OPCION != 'S');
        }
    }
}
