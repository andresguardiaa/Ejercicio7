using Ejercicio7.Dialogos;
using System.Windows;

namespace Ejercicio7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   


    public partial class MainWindow : Window
    {

        private Window1 _ventanaModeloArticulo;
        private Window2 _ventanaUsuario;
        private UCListadoUsuarios _listadoUsuarios;
        private UCAdminisracion _uCAdminisracion;
        private UCListadoArticulos _uCListadoArticulos;
        private UCTreeViewArticulos _uCTreeViewArticulos;

        public MainWindow(Window1 window1, Window2 window2, UCListadoUsuarios uCListadoUsuarios, UCAdminisracion uCAdminisracion, UCListadoArticulos uCListadoArticulos, UCTreeViewArticulos uCTreeViewArticulos)
        {
            InitializeComponent();
            _ventanaModeloArticulo = window1;
            _ventanaUsuario = window2;
            _listadoUsuarios = uCListadoUsuarios;
            _uCAdminisracion = uCAdminisracion;
            _uCListadoArticulos = uCListadoArticulos;
            _uCTreeViewArticulos = uCTreeViewArticulos;
        }


        private void Articulobtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = _ventanaUsuario;
            dlg.ShowDialog();
        }

        private void MarticuloButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = _ventanaModeloArticulo;
            dlg.ShowDialog();
        }

        private void listadoUsuarios_Click(object sender, RoutedEventArgs e)
        {
            panelListaUsuarios.Children.Clear();
            panelListaUsuarios.Children.Add(_listadoUsuarios);
        }

        private void btnUcAdministracion_Click(object sender, RoutedEventArgs e)
        {
            panelListaUsuarios.Children.Clear();
            panelListaUsuarios.Children.Add(_uCAdminisracion);
        }

        private void btnListaArticulos_Click(object sender, RoutedEventArgs e)
        {
            panelListaUsuarios.Children.Clear();
            panelListaUsuarios.Children.Add(_uCListadoArticulos);
        }

        private void btnTreeViewArticulos_Click(object sender, RoutedEventArgs e)
        {
            panelListaUsuarios.Children.Clear();
            panelListaUsuarios.Children.Add(_uCTreeViewArticulos);
        }
    }
}