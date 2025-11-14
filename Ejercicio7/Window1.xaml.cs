using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Windows;

namespace Ejercicio7
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DiinventarioexamenContext _diinventarioexamenContext;
        private ILogger<GenericRepository<Modeloarticulo>> _logger;

        private ModeloArticuloRepository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;
        public Window1()
        {
            InitializeComponent();
            
        }

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            _diinventarioexamenContext = new DiinventarioexamenContext();
            _logger = LoggerFactory.Create(builder =>
            builder.AddConsole()
            ).CreateLogger<GenericRepository<Modeloarticulo>>();
            _modeloArticuloRepository = new ModeloArticuloRepository(_diinventarioexamenContext, _logger);
            _tipoArticuloRepository = new TipoArticuloRepository(_diinventarioexamenContext, null);
            // Cargar datos en el ComboBox
            List<Tipoarticulo> tipos = await _tipoArticuloRepository.GetAllAsync();
            cmbTipoArticulo.ItemsSource = tipos;

        }

        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void RecogerDatos(Modeloarticulo modeloArticulo)
        {
            modeloArticulo.Nombre = txtnombre.Text;
            modeloArticulo.Descripcion = txtdescripcion.Text;
            modeloArticulo.Modelo = txtmodelo.Text;
            modeloArticulo.Marca = txtmarca.Text;
            if(cmbTipoArticulo.SelectedItem != null)
            {
                modeloArticulo.TipoNavigation = (Tipoarticulo)cmbTipoArticulo.SelectedItem;
            }
        }

        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            Modeloarticulo modeloarticulo = new Modeloarticulo();
            RecogerDatos(modeloarticulo);
            try
            {
                await _modeloArticuloRepository.AddAsync(modeloarticulo);
                await _diinventarioexamenContext.SaveChangesAsync();
                DialogResult = true;
            }
            catch (Exception ex) {
                MessageBox.Show("Apaña");
            }

        }
    }
}
