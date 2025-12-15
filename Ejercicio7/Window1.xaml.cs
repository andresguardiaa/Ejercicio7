using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM;
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

        private MVArticulo _mvArticulo;

        public Window1(MVArticulo mVArticulo)
        {
            InitializeComponent();
            _mvArticulo = mVArticulo;
            
           
        }

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            DataContext = _mvArticulo;

        }

        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        

        
        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogResult = true;
            }
            catch (Exception ex) {
                MessageBox.Show("Apaña");
            }

        }
    }
}
