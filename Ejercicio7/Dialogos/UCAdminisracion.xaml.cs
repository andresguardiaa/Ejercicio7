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
    /// Interaction logic for UCAdminisracion.xaml
    /// </summary>
    public partial class UCAdminisracion : UserControl
    {
        private UCArbol _UCArbol;
        public UCAdminisracion(UCArbol uCArbol)
        {
            InitializeComponent();
            _UCArbol = uCArbol;
        }

        private void btnArbolEspacios_Click(object sender, RoutedEventArgs e)
        {
            panelCentral.Children.Clear();
            panelCentral.Children.Add(_UCArbol);
        }

        private void btnAddEspacios_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
