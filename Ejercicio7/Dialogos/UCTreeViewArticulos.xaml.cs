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
    /// Lógica de interacción para UCTreeViewArticulos.xaml
    /// </summary>
    public partial class UCTreeViewArticulos : UserControl
    {
        private MVArticuloReal _mvArticuloReal;
        public UCTreeViewArticulos(MVArticuloReal mVArticuloReal)
        {
            InitializeComponent();
            _mvArticuloReal = mVArticuloReal;
        }

        private async void treeViewArticulos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticuloReal.Inicializa();
            DataContext = _mvArticuloReal;
        }
    }
}
