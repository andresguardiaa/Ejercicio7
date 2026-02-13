using Ejercicio7.Backend.Modelo;
using Ejercicio7.MVVM;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio7.Dialogos
{
    /// <summary>
    /// Interaction logic for UCArbol.xaml
    /// </summary>
    public partial class UCArbol : UserControl
    {
        private MVEspacios _mVEspacios;
        public UCArbol(MVEspacios mVEspacios)
        {
            InitializeComponent();
            _mVEspacios = mVEspacios;
        }

        private async void ucArbolEspacios_Loaded(object sender, RoutedEventArgs e)
        {
            await _mVEspacios.Inicializa();
            this.DataContext = _mVEspacios;
        }

        private void treeEspacios_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            if(treeEspacios.SelectedItem is Espacio)
            {
                dgArticulosEspacio.ItemsSource = ((Espacio) treeEspacios.SelectedItem).Articulos;
            }
        }
    }
}
