using System;
using System.Linq;
using System.Configuration;

namespace TiendaInterfaz2
{
    class Program
    {
        /*
         * -Crear un proyecto y utilizando entity framework permitir ingresar datos en las tablas MARCA, TIPOPRODUCTO y PRODUCTO
         * -En otra pantalla, listar todos los productos, agegar un control para poder buscar y filtrar en la lista, permitir seleccionar productos y generar un TICKET con los productos seleccionados.
         */

        static void Main(string[] args)
        {

            int codigo;
            var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]);
            var query = context.PRODUCTOes.ToList();

            while (true)
            {
                Console.WriteLine("Elige una opción: \n1. Insertar datos en la tabla MARCA\n2. Insertar datos en la tabla TIPOPRODUCTO\n3. Insertar datos en la tabla PRODUCTO\n" +
            "4. Listar todos los productos\n5. Buscar en la lista de productos\n6. Generar ticket con los productos seleccionados\nPulsa cualquier otro botón para salir");

                int choice = int.Parse(Console.ReadLine());

                string descripcion;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Añadir codigo: ");
                        codigo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Añadir descripcion: ");
                        descripcion = Console.ReadLine();
                        Metodos.insertMarca(codigo, descripcion);
                        break;
                    case 2:
                        Console.WriteLine("Añadir codigo: ");
                        codigo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Añadir nombre: ");
                        descripcion = Console.ReadLine();
                        Metodos.insertTipoProducto(codigo, descripcion);
                        break;
                    case 3:
                        Console.WriteLine("Añadir marcaId: ");
                        codigo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Añadir tipoProductoId: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Añadir descripcion: ");
                        descripcion = Console.ReadLine();
                        Console.WriteLine("Añadir talle: ");
                        string talle = Console.ReadLine();
                        Console.WriteLine("Añadir color: ");
                        string color = Console.ReadLine();
                        Console.WriteLine("Añadir precio: ");
                        string precio = Console.ReadLine();
                        Console.WriteLine("Añadir stock: ");
                        int stock = int.Parse(Console.ReadLine());
                        Metodos.insertProducto(codigo, id, descripcion, talle, color, precio, stock);
                        break;
                    case 4:
                        Console.WriteLine(Metodos.selectProducts(query));
                        break;
                    case 5:
                        query = Metodos.getQuery();
                        Console.WriteLine(Metodos.selectProducts(query));
                        break;
                    case 6:
                        Metodos.insertTicket(query, 5);
                        //File.WriteAllText("prueba.txt", Metodos.selectProducts(query));
                        break;
                    default:
                        Console.WriteLine("Saliendo...");
                        break;

                }

                if (choice.Equals(0))
                {
                    break;
                }
            }
            Console.ReadKey();
            }

        }
    }



