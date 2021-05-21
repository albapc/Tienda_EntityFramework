using System;
using System.Linq;
using System.Windows;
using System.Configuration;

namespace TiendaInterfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void insertMarca(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var marca = new MARCA()
                {
                    Codigo = int.Parse(CodigoMarca.Text),
                    Descripcion = DescripcionMarca.Text
                };
                context.MARCAs.Add(marca);

                context.SaveChanges();
            }
            MessageBox.Show("Marca " + CodigoMarca.Text + " con descripción: " + DescripcionMarca.Text + "\nInsertada correctamente");
        }

        private void insertTipoProducto(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var tipoProducto = new TIPOPRODUCTO()
                {
                    Codigo = int.Parse(CodigoTipoProducto.Text),
                    Nombre = NombreTipoProducto.Text
                };
                context.TIPOPRODUCTOes.Add(tipoProducto);

                context.SaveChanges();
            }
            MessageBox.Show("Tipo de producto " + CodigoTipoProducto.Text + " con nombre: " + NombreTipoProducto.Text + "\nInsertado correctamente");
        }

        private void insertProducto(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var producto = new PRODUCTO()
                {
                    MarcaId = int.Parse(MarcaIdProducto.Text),
                    TipoProductoId = int.Parse(TipoProductoIdProducto.Text),
                    Descripcion = DescripcionProducto.Text,
                    Talle = TalleProducto.Text,
                    Color = ColorProducto.Text,
                    Precio = decimal.Parse(PrecioProducto.Text),
                    Stock = int.Parse(StockProducto.Text)

                };
                context.PRODUCTOes.Add(producto);

                context.SaveChanges();
            }
            MessageBox.Show("Producto con descripcion: " + DescripcionProducto.Text + "\nInsertado correctamente");
        }

        private void selectProducts(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var query = context.PRODUCTOes.ToList();

                datag.ItemsSource = query;
            }
        }

        private void filterProducts(object sender, RoutedEventArgs e)
        {
            var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]);
            var query = context.PRODUCTOes.ToList();

            switch (comboBox1.Text)
            {
                case "ProductoId":
                    query = context.PRODUCTOes.AsEnumerable().Where(s => s.ProductoId == int.Parse(tbProducto.Text)).ToList();
                    break;
                case "MarcaId":
                    query = context.PRODUCTOes.AsEnumerable().Where(s => s.MarcaId == int.Parse(tbProducto.Text)).ToList();
                    break;
                case "TipoProductoId":
                    query = context.PRODUCTOes.AsEnumerable().Where(s => s.TipoProductoId == int.Parse(tbProducto.Text)).ToList();
                    break;
                case "Talle":
                    query = context.PRODUCTOes.Where(s => s.Talle == tbProducto.Text).ToList();
                    break;
                case "Color":
                    query = context.PRODUCTOes.Where(s => s.Color == tbProducto.Text).ToList();
                    break;
                case "Precio":
                    query = context.PRODUCTOes.AsEnumerable().Where(s => s.Precio == decimal.Parse(tbProducto.Text)).ToList();
                    break;
                case "Stock":
                    query = context.PRODUCTOes.AsEnumerable().Where(s => s.Stock == int.Parse(tbProducto.Text)).ToList();
                    break;
                default:
                    Console.WriteLine("Input no valido. Mostrando todos los resultados por defecto...");
                    break;
            }

            datag.ItemsSource = query;
        }

        public async void insertTicket(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                decimal? total = 0;
                if (datag.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < datag.SelectedItems.Count; i++)
                    {
                        PRODUCTO p = (PRODUCTO)datag.SelectedItems[i];
                        total += p.Precio;
                    }

                    for (int i = 0; i < datag.SelectedItems.Count; i++)
                    {
                        PRODUCTO p = (PRODUCTO)datag.SelectedItems[i];
                        //se generará un porcentaje aleatorio de descuento
                        Random rd = new Random();
                        int rand_desc = rd.Next(5, 70);

                        Console.WriteLine(rand_desc);

                        decimal descuento = (decimal)((rand_desc / (decimal)100f) * p.Precio); // es necesario pasar el 100 a float para que muestre los decimales en el resultado
                        Console.WriteLine(descuento);

                        var ticket = new TICKET()
                        {
                            Fecha = DateTime.Now,
                            Subtotal = p.Precio,
                            Descuento = descuento,
                            Importe = total - descuento,
                            CantidadProductos = datag.SelectedItems.Count

                        };
                        context.TICKETs.Add(ticket);
                        await context.SaveChangesAsync();

                        var ticketDetail = new TICKETDETALLE()
                        {
                            TicketId = ticket.TicketId,
                            ProductoId = p.ProductoId,
                            Descuento = descuento,
                            Importe = total - descuento,
                            CantidadProductos = datag.SelectedItems.Count

                        };
                        context.TICKETDETALLEs.Add(ticketDetail);
                        await context.SaveChangesAsync();
                    }
                    context.SaveChanges();
                }
            }
            MessageBox.Show("Ticket creado correctamente");
        }
    }
}