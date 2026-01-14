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

        public MainWindow(Window1 window1, Window2 window2, UCListadoUsuarios uCListadoUsuarios)
        {
            InitializeComponent();
            _ventanaModeloArticulo = window1;
            _ventanaUsuario = window2;
            _listadoUsuarios = uCListadoUsuarios;
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
            if(panelListaUsuarios!= null) panelListaUsuarios.Children.Clear();
            panelListaUsuarios.Children.Add(_listadoUsuarios);
        }
    }
}