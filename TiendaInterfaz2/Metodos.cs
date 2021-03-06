using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace TiendaInterfaz2
{
    class Metodos
    {

        public static void insertMarca(int codigo, string descripcion)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var marca = new MARCA()
                {
                    Codigo = codigo,
                    Descripcion = descripcion
                };
                context.MARCAs.Add(marca);

                context.SaveChanges();
            }
        }

        public static void insertTipoProducto(int codigo, string nombre)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var tipoProducto = new TIPOPRODUCTO()
                {
                    Codigo = codigo,
                    Nombre = nombre
                };
                context.TIPOPRODUCTOes.Add(tipoProducto);

                context.SaveChanges();
            }
        }

        public static void insertProducto(int marcaId, int tipoProductoId, string descripcion, string talle, string color, string precio, int stock)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var producto = new PRODUCTO()
                {
                    MarcaId = marcaId,
                    TipoProductoId = tipoProductoId,
                    Descripcion = descripcion,
                    Talle = talle,
                    Color = color,
                    Precio = decimal.Parse(precio),
                    Stock = stock

                };
                context.PRODUCTOes.Add(producto);

                context.SaveChanges();
            }
        }

        public static async void insertTicket(List<PRODUCTO> query, int descuento)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                foreach (var product in query)
                {
                    var ticket = new TICKET()
                    {
                        Fecha = DateTime.Now,
                        Subtotal = product.Precio,
                        Descuento = descuento,  
                        Importe = product.Precio,
                        CantidadProductos = product.Stock

                    };
                   context.TICKETs.Add(ticket);
                   await context.SaveChangesAsync();

                    var ticketDetail = new TICKETDETALLE()
                    {
                        TicketId = ticket.TicketId,
                        ProductoId = product.ProductoId,
                        Descuento = descuento,
                        Importe = product.Precio,
                        CantidadProductos = product.Stock

                    };
                    context.TICKETDETALLEs.Add(ticketDetail);
                    await context.SaveChangesAsync();
                }
                context.SaveChanges();
            }
        }


        public static string selectProducts(List<PRODUCTO> query)
        {
            string text = "";
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {

                foreach (var product in query)
                {
                    text += "ProductoId: " + product.ProductoId + ", MarcaId: " + product.MarcaId + ", TipoProductoId: " + product.TipoProductoId +
                        ", Descripcion: " + product.Descripcion + ", Talle: " + product.Talle + ", Color: " + product.Color + ", Precio: " + product.Precio + ", Stock: " + product.Stock + "\n";
                }

            }
            return text;
        }

        public static List<PRODUCTO> getQuery()
        {
            Console.WriteLine("Buscar producto por:\n1. ProductoId\n2. MarcaId\n3. TipoProductoId\n4. Talle\n5. Color\n6. Precio\n7. Stock");
            int opcion = int.Parse(Console.ReadLine());
            int codigo;
            string descripcion = "";
            decimal precio;
            var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]);
            var query = context.PRODUCTOes.ToList();
            var sum = context.PRODUCTOes;
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Introducir productoId: ");
                    codigo = int.Parse(Console.ReadLine());
                    query = context.PRODUCTOes.Where(s => s.ProductoId == codigo).ToList();

                    break;
                case 2:
                    Console.WriteLine("Introducir MarcaId: ");
                    codigo = int.Parse(Console.ReadLine());
                    query = context.PRODUCTOes.Where(s => s.MarcaId == codigo).ToList();
                    break;
                case 3:
                    Console.WriteLine("Introducir TipoProductoId: ");
                    codigo = int.Parse(Console.ReadLine());
                    query = context.PRODUCTOes.Where(s => s.TipoProductoId == codigo).ToList();
                    break;
                case 4:
                    Console.WriteLine("Introducir Talle: ");
                    descripcion = Console.ReadLine();
                    query = context.PRODUCTOes.Where(s => s.Talle == descripcion).ToList();
                    break;
                case 5:
                    Console.WriteLine("Introducir color: ");
                    descripcion = Console.ReadLine();
                    query = context.PRODUCTOes.Where(s => s.Color == descripcion).ToList();
                    break;
                case 6:
                    Console.WriteLine("Introducir precio: ");
                    precio = decimal.Parse(Console.ReadLine());
                    query = context.PRODUCTOes.Where(s => s.Precio == precio).ToList();
                    break;
                case 7:
                    Console.WriteLine("Introducir stock: ");
                    codigo = int.Parse(Console.ReadLine());
                    query = context.PRODUCTOes.Where(s => s.Stock == codigo).ToList();
                    break;
                default:
                    Console.WriteLine("Input no valido");
                    break;
            }
            return query;
        }
    }
}
