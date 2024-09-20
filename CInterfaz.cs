using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitaInterzonallHaedo
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                Sistema de Gestión del Hospital            *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("\n[A]     Establecer o informar el monto de referenca y los bonos profesionales"); // LISTO  
            Console.WriteLine("\n[B]     Registrar un empleado"); // LISTO
            Console.WriteLine("\n[C]     Listar datos de los empleados del hospital"); // LISTO
            Console.WriteLine("\n[D]     Registrar un servicio"); // LISTO
            Console.WriteLine("\n[E]     Asignar empleado a un servicio"); // LISTO
            Console.WriteLine("\n[F]     Remplazar un jefe de servicio"); // LISTO
            Console.WriteLine("\n[G]     Listar servicio"); // LISTO
            Console.WriteLine("\n[H]     Listar empleado"); // LISTO
            Console.WriteLine("\n[I]     Eliminar empleado"); // LISTO
            Console.WriteLine("\n[J]     Mostrar cantidad de empleados y haberes totales de los servicios"); // LISTO
            Console.WriteLine("\n[S]     Salir de la aplicación.");
            Console.WriteLine("\n********************************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + " es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
        }

        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
