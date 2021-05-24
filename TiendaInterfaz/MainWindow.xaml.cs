using System;
using System.Linq;
using System.Windows;
using System.Configuration;
using log4net;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace TiendaInterfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml: Window
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private static readonly ILog log = Logs.GetLogger();

        public MainWindow()
        {
            log4net.Config.XmlConfigurator.Configure(); // hace falta para generar el archivo de log
            InitializeComponent();
            var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]);
            comboBoxMarcaId.ItemsSource = context.MARCAs.Select(l => l.MarcaId).ToList();
            comboBoxTipoProductoId.ItemsSource = context.TIPOPRODUCTOes.Select(l => l.TipoProductoId).ToList();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void InsertMarca(object sender, RoutedEventArgs e)
        {
            if (CodigoMarca.Text.Trim() == string.Empty || DescripcionMarca.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, introducir datos en ambos campos");
                CodigoMarca.Focus();
                return;
            }
            try
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
                log.Debug("Marca " + CodigoMarca.Text + " con descripción: " + DescripcionMarca.Text + " insertada correctamente");
                MessageBox.Show("Marca " + CodigoMarca.Text + " con descripción: " + DescripcionMarca.Text + "\nInsertada correctamente");
             }
            catch (FormatException fe)
            {
                log.Error(fe);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }

        private void InsertTipoProducto(object sender, RoutedEventArgs e)
        {
            if (CodigoTipoProducto.Text.Trim() == string.Empty || NombreTipoProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, introducir datos en ambos campos");
                return; // return because we don't want System.Windows.ode of button click
            }

            try
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
                log.Debug("Tipo de producto " + CodigoTipoProducto.Text + " con nombre: " + NombreTipoProducto.Text + " insertado correctamente");
                MessageBox.Show("Tipo de producto " + CodigoTipoProducto.Text + " con nombre: " + NombreTipoProducto.Text + "\nInsertado correctamente");
            }
            catch (FormatException fe)
            {
                log.Error(fe);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void InsertProducto(object sender, RoutedEventArgs e)
        {
            if (comboBoxMarcaId.Text.Trim() == string.Empty || comboBoxTipoProductoId.Text.Trim() == string.Empty || DescripcionProducto.Text.Trim() == string.Empty
                      || comboBoxTalle.Text.Trim() == string.Empty || ColorProducto.Text.Trim() == string.Empty || PrecioProducto.Text.Trim() == string.Empty
                      || StockProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, introducir datos en todos los campos");
                return; // return because we don't wSystem.Windows.al code of button click
            }

            try
            {
                using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
                {
                    var producto = new PRODUCTO()
                    {
                        MarcaId = int.Parse(comboBoxMarcaId.Text),
                        TipoProductoId = int.Parse(comboBoxTipoProductoId.Text),
                        Descripcion = DescripcionProducto.Text,
                        Talle = comboBoxTalle.Text,
                        Color = ColorProducto.Text,
                        Precio = decimal.Parse(PrecioProducto.Text),
                        Stock = int.Parse(StockProducto.Text)

                    };
                    context.PRODUCTOes.Add(producto);

                    context.SaveChanges();
                }
                log.Debug("Producto con descripcion: " + DescripcionProducto.Text + " insertado correctamente");
                MessageBox.Show("Producto con descripcion: " + DescripcionProducto.Text + "\nInsertado correctamente");
            }
            catch (FormatException fe)
            {
                log.Error(fe);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        private void SelectProducts(object sender, RoutedEventArgs e)
        {
            using (var context = new TIENDADBEntities(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["database"]))
            {
                var query = context.PRODUCTOes.ToList();

                datag.ItemsSource = query;
            }
            log.Info("Mostrando todos los productos...");
        }

        private void FilterProducts(object sender, RoutedEventArgs e)
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
                    log.Warn("Input no valido. Mostrando todos los resultados por defecto...");
                    break;
            }

            datag.ItemsSource = query;

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                log.Info("Mostrando productos con " + comboBox1.Text + " " + tbProducto.Text);
            }


        }

        public async void InsertTicket(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("Ticket creado correctamente");
                    log.Debug("Ticket creado correctamente");
                }
                else
                {
                    MessageBox.Show("No hay ningún producto seleccionado para crear ticket. Cancelando...");
                    log.Warn("NSystem.Windows.rear un ticket ya que no hay ningún producto seleccionado. Cancelando...");
                }
                }

            }
        }

    }
