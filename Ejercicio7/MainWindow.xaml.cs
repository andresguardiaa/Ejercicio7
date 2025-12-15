using System.Windows;

namespace Ejercicio7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   


    public partial class MainWindow : Window
    {

        private readonly Window1 _ventanaModeloArticulo;
        private readonly Window2 _ventanaUsuario;

        public MainWindow(Window1 window1, Window2 window2)
        {
            InitializeComponent();
            _ventanaModeloArticulo = window1;
            _ventanaUsuario = window2;
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
    }
}