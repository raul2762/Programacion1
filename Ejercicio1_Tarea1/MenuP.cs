using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ejercicio1_Tarea1
{
	public class MenuP
	{
        private static void MenuPrincipal()
		{
            ListaCompra listaCompra = ListaCompra.Instancia;

            Console.Clear();
			int val_opcion = 0;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Lista de Compra: \n 1 - Crear Lista \n 2 - Editar Lista \n 3 - Detalle Lista \n 4 - Eliminar Lista \n 5 - Salir");

            try
            {
                Console.Write("Digite una opcion: ");
                val_opcion = Convert.ToInt32(Console.ReadLine());

                switch (val_opcion)
                {
                    case 1:
                        listaCompra.Crear();
                        break;
                    case 2:
                        listaCompra.ShowListas();
                        break;
                    case 3:
                        listaCompra.ShowListas();
                        break;
                    case 4:
                        listaCompra.ShowListas();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Opcion no valida");
                        Thread.Sleep(2000);
                        MenuPrincipal();
                        break;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Opcion no valida");
                Thread.Sleep(2000);
                MenuPrincipal();

            }
        }

		public static void ShowMenuPrincipal()
		{
			MenuPrincipal();
		}


	}
}
