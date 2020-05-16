using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_Tarea1
{
	enum Product_cat
	{
		Frutas = 1,
		Vegetales,
		Lacteos
	}
	class Producto
	{
		public string Nombre { get; set; }
		public Product_cat Categoria { get; set; }
		public double Precio { get; set; }
	}
}
