using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CafeProgramation.Programation;

namespace TestProgramation
{
    class Program
    {
        static void Main(string[] args)
        {
            CafeProgramation.Programation.Data oData = new Data();
            CafeProgramation.Programation.Logic oLogic = new Logic();
            int opcion;
            string entrada;
            do
            {
                Console.WriteLine("***---...---Programación del café---...---***");
                Console.WriteLine("1.- Programación automatica");
                Console.WriteLine("2.- Eliminar programación actual");
                Console.WriteLine("3.- Ver programación de cierto mes -- [NO DISPONIBLE]");
                Console.WriteLine("4.- Ver programación de empleado de cierta fecha -- [NO DISPONIBLE]");
                Console.WriteLine("0.- Salir");
                entrada = Console.ReadLine();
                try
                {
                    opcion = Int32.Parse(entrada);
                }
                catch (FormatException)
                {
                    opcion = -1;
                    Console.WriteLine(entrada + " no es una entrada valida, intenta de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                }
                switch (opcion)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Deseas reprogramar?\ty/n");
                        entrada = Console.ReadLine();
                        if (entrada.Equals("y"))
                        {
                            Console.WriteLine("Iniciando ...");
                            oLogic.ProgramationPizarronStart();
                            Console.WriteLine("Finalizado");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (entrada.Equals("n"))
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entrada invalida");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case 2:
                        Console.WriteLine("Deseas eliminar la programación?\ty/n");
                        entrada = Console.ReadLine();
                        if (entrada.Equals("y"))
                        {
                            Console.WriteLine("Eliminando ...");
                            oData.DeleteCafe_Programation();
                            Console.WriteLine("Finalizado");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (entrada.Equals("n"))
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entrada invalida");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
              
                    default:
                        Console.WriteLine("Opcion no valida intenta de nuevo");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                
            } while (opcion != 0);

            //oLogic.ProgramationPizarronStart();

            Console.WriteLine("Ok");
            Console.ReadLine();
        }
    }
}
