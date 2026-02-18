using Ejercicio7.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio7.Dialogos
{
    /// <summary>
    /// Lógica de interacción para UCListadoArticulos.xaml
    /// </summary>
    public partial class UCListadoArticulos : UserControl
    {
        private MVArticuloReal _mvArticuloReal;
        private readonly IServiceProvider _serviceProvider;

        public UCListadoArticulos(MVArticuloReal mVArticuloReal, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mvArticuloReal = mVArticuloReal;
            _serviceProvider = serviceProvider;
        }

        private async void listadoArticulos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticuloReal.Inicializa();
            DataContext = _mvArticuloReal;
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        /*private void txtFiltroNumSerie_TextChanged(object sender, TextChangedEventArgs e)
        {
            _mvArticuloReal.Filtrar();
        }*/
    }
}
