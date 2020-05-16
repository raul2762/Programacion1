using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ejercicio1_Tarea1
{
	public class ListaCompra
	{
		private static ListaCompra _instancia = null;
		private Dictionary<int, string> NombresLista;
		private List<List<Producto>> ListasDeCompra;
		private int ContadorLista = 0;
		private ListaCompra()
		{
			ListasDeCompra = new List<List<Producto>>();
			NombresLista = new Dictionary<int, string>();
		}
		
		
		public static ListaCompra Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ListaCompra();
				}
				return _instancia;
			}
		}
		enum TipoListado
		{
			Listar = 1,
			Editar,
			Eliminar
		}

		enum AccionProd
		{
			Editar = 1,
			Eliminar
		}

		private void CrearLista(List<Producto> listaProducto = null, string _nombreLista = "")
		{
			Console.Clear();
			Producto producto = new Producto();
			
			string nombreLista = _nombreLista;
			if (listaProducto == null)
			{
				listaProducto = new List<Producto>();
			}
			int id_producto = 0;

			Console.ForegroundColor = ConsoleColor.Cyan;

			if (ContadorLista <= 10)
			{
				try
				{
					if (listaProducto.Count <= 0)
					{
						Console.Write("Nombre de lista: ");
						nombreLista = Console.ReadLine();
					}

					Console.Write("Nombre de producto: ");
					producto.Nombre = Console.ReadLine();

					Console.Write("Categoria 1 - Frutas 2 - Vegetales 3 - Lacteos: ");
					int No_cat = Convert.ToInt32(Console.ReadLine());

					switch (No_cat)
					{
						case 1:
							producto.Categoria = Product_cat.Frutas;
							break;
						case 2:
							producto.Categoria = Product_cat.Vegetales;
							break;
						case 3:
							producto.Categoria = Product_cat.Lacteos;
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Error! Opcion no valida");
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("los productos agregado anterior a este aun se mantienen.");
							Console.ReadKey();
							CrearLista(listaProducto, nombreLista);
							break;
					}

					Console.Write("Precio: ");
					producto.Precio = Convert.ToDouble(Console.ReadLine());
					listaProducto.Add(producto);

					Console.Write("Agregar otro producto Y-Si N-No: ");
					string val_opcion = Console.ReadLine();

					if (val_opcion.ToLower() == "y")
					{
						ContadorLista++;
						CrearLista(listaProducto, nombreLista);
					}
					else if (val_opcion.ToLower() == "n")
					{
						ListasDeCompra.Add(listaProducto);
						id_producto = ListasDeCompra.Count - 1;
						NombresLista.Add(id_producto, nombreLista);
						MenuP.ShowMenuPrincipal();
					}
				}
				catch (Exception)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! Opcion no valida");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("los productos agregado anterior a este aun se mantienen.");
					Console.ReadKey();
					CrearLista(listaProducto, nombreLista);
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Solo se permite un maximo de 10 producto por lista de compra");
				Console.ReadKey();
				MenuP.ShowMenuPrincipal();
			}
			
			
		}

		private void MostrarListas()
		{
			Console.Clear();
			int val_opcion;
			string val_opcion_string;
			//ListasDeCompra = new List<List<Producto>>();
			Console.ForegroundColor = ConsoleColor.Cyan;

			if (ListasDeCompra.Count > 0)
			{
				Console.WriteLine("Listas disponibles");
				Console.WriteLine("********************************");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("E - Salir");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("********************************");
				Console.WriteLine("|Id | Nombre ");
				foreach (KeyValuePair<int, string> item in NombresLista)
				{
					Console.WriteLine("|{0} | {1}", item.Key, item.Value);
					Console.WriteLine("----------------------------");
				}
				Console.Write("Detalle de lista, digite el Id: ");
				val_opcion_string = Console.ReadLine();


				if (val_opcion_string.ToLower() == "e")
				{
					MenuP.ShowMenuPrincipal();
				}
				val_opcion = Convert.ToInt32(val_opcion_string);
				Console.Write("Tipo detalle \n1 - Producto por categoria 2 - Todos : ");
				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						Console.WriteLine("1 - Frutas 2 - Vegetales 3 - Lacteos");
						int opcion_cat = Convert.ToInt32(Console.ReadLine());
						DetalleLista(val_opcion, opcion_cat);
						break;
					case 2:
						DetalleLista(val_opcion);
						break;
					default:
						break;
				}

			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("***No existe lista de compra***");
				Console.ReadKey();
				MenuP.ShowMenuPrincipal();
			}
		}

		private void FiltroLista(int id)
		{
			Console.Clear();
			int val_opcion_filtro;
			int val_opcion_cat;
			Product_cat product_Cat;

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Nombre de Lista: *** {0} ***", NombresLista[id]);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("1 - Producto por categoria \n2 - Mostrar todos los productos");
			Console.ForegroundColor = ConsoleColor.Magenta;
			val_opcion_filtro = Convert.ToInt32(Console.ReadLine());
			Console.ForegroundColor = ConsoleColor.Cyan;

			if (val_opcion_filtro == 1)
			{
				Console.WriteLine("1 - Frutas 2 - Vegetales 3 - Lacteos");
				Console.Write("Digite una opcion: ");
				Console.ForegroundColor = ConsoleColor.Magenta;
				val_opcion_cat = Convert.ToInt32(Console.ReadLine());
				Console.ForegroundColor = ConsoleColor.Cyan;

				switch (val_opcion_cat)
				{
					case 1:
						product_Cat = Product_cat.Frutas;
						break;
					case 2:
						product_Cat = Product_cat.Vegetales;
						break;
					case 3:
						product_Cat = Product_cat.Lacteos;
						break;
					default:
						product_Cat = Product_cat.Frutas;
						break;
				}

				Console.WriteLine("|Precio | Categoria | Precio");
				for (int i = 0; i < ListasDeCompra[id].Count; i++)
				{
					if (ListasDeCompra[id][i].Categoria == product_Cat)
					{
						Console.WriteLine("----------------------------");
						Console.WriteLine("|{0} | {1} | {2}", ListasDeCompra[id][i].Nombre, ListasDeCompra[id][i].Categoria, ListasDeCompra[id][i].Precio);
						Console.WriteLine("----------------------------");
					}

				}
				Console.WriteLine("Volver atras...");
				Console.ReadKey();
				ShowListas();
			}
			else if (val_opcion_filtro == 2)
			{
				Console.WriteLine("|Precio | Categoria | Precio");
				for (int i = 0; i < ListasDeCompra[id].Count; i++)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine("|{0} | {1} | {2}", ListasDeCompra[id][i].Nombre, ListasDeCompra[id][i].Categoria, ListasDeCompra[id][i].Precio);
					Console.WriteLine("----------------------------");
				}
				Console.WriteLine("Volver atras...");
				Console.ReadKey();
				ShowListas();
			}
		}

		private void DetalleLista(int id, int filtro = 0)
		{

			Console.Clear();
			Product_cat product_Cat = Product_cat.Frutas;
			if (filtro > 0)
			{
				switch (filtro)
				{
					case 1:
						product_Cat = Product_cat.Frutas;
						break;
					case 2:
						product_Cat = Product_cat.Vegetales;
						break;
					case 3:
						product_Cat = Product_cat.Lacteos;
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Error! Opcion de categoria no valida");
						Console.ReadKey();
						MostrarListas();
						break;
				}
			}
			Console.WriteLine("Lista: *** {0} ***", NombresLista[id]);
			Console.WriteLine("5 - Volver atras");
			Console.WriteLine("***********************************");
			Console.WriteLine("| Id | Precio | Categoria | Precio");
			for (int i = 0; i < ListasDeCompra[id].Count; i++)
			{
				if (filtro == 0)
				{
					Console.WriteLine("----------------------------");
					Console.WriteLine("|{0} | {1} | {2} | {3}", i, ListasDeCompra[id][i].Nombre, ListasDeCompra[id][i].Categoria, ListasDeCompra[id][i].Precio);
					Console.WriteLine("----------------------------");
				}
				else if (filtro > 0)
				{
					if (ListasDeCompra[id][i].Categoria == product_Cat)
					{
						Console.WriteLine("----------------------------");
						Console.WriteLine("|{0} | {1} | {2} | {3}", i, ListasDeCompra[id][i].Nombre, ListasDeCompra[id][i].Categoria, ListasDeCompra[id][i].Precio);
						Console.WriteLine("----------------------------");
					}
					
				}
				
			}
			Console.Write("Producto Id: ");
			int id_product = Convert.ToInt32(Console.ReadLine());
			if (id_product == 5)
			{
				MostrarListas();
			}
			Console.Write("1 - Editar 2 - Eliminar 5 - Volver atras: ");
			int id_accion = Convert.ToInt32(Console.ReadLine());

			switch (id_accion)
			{
				case 1:
					DelEditProducto(id, id_product, AccionProd.Editar);
					break;
				case 2:
					DelEditProducto(id, id_product, AccionProd.Eliminar);
					break;
				case 5:
					MostrarListas();
					break;
				default:
					break;
			}
		}

		private void DelEditProducto(int idLista, int idProduct, AccionProd accion)
		{
			try
			{
				if (accion == AccionProd.Editar)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Editando producto: ({0} {1} {2} {3})", idProduct, ListasDeCompra[idLista][idProduct].Nombre, ListasDeCompra[idLista][idProduct].Categoria, ListasDeCompra[idLista][idProduct].Precio);
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.Write("Nombre de producto: ");
					ListasDeCompra[idLista][idProduct].Nombre = Console.ReadLine();
					Console.Write("Categoria 1 - Frutas 2 - Vegetales 3 - Lacteos: ");
					int No_cat = Convert.ToInt32(Console.ReadLine());

					switch (No_cat)
					{
						case 1:
							ListasDeCompra[idLista][idProduct].Categoria = Product_cat.Frutas;
							break;
						case 2:
							ListasDeCompra[idLista][idProduct].Categoria = Product_cat.Vegetales;
							break;
						case 3:
							ListasDeCompra[idLista][idProduct].Categoria = Product_cat.Lacteos;
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Error! Opcion de categoria no valida");
							Console.ReadKey();
							DelEditProducto(idLista, idProduct, accion);
							break;
					}

					Console.WriteLine("Precio: ");
					ListasDeCompra[idLista][idProduct].Precio = Convert.ToDouble(Console.ReadLine());

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Producto editado exitosamente!!");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Thread.Sleep(2000);
					DetalleLista(idLista);
				}
				else if (accion == AccionProd.Eliminar)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Seguro que desea eliminar este articulo? 1-Si 2-No?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("({0} {1} {2} {3})", idProduct, ListasDeCompra[idLista][idProduct].Nombre, ListasDeCompra[idLista][idProduct].Categoria, ListasDeCompra[idLista][idProduct].Precio);
					int opcion = Convert.ToInt32(Console.ReadLine());

					switch (opcion)
					{
						case 1:
							ListasDeCompra[idLista].RemoveAt(idProduct);
							break;
						case 2:
							DetalleLista(idLista);
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Error! Opcion no valida");
							Console.ReadKey();
							DetalleLista(idLista);
							break;
					}
				}
			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! Opcion no valida");
				Console.ReadKey();
				DelEditProducto(idLista, idProduct, accion);
			}
			
		}
		public void Crear()
		{
			CrearLista();
		}



		public void ShowListas()
		{
			MostrarListas();
		}
	}
}
