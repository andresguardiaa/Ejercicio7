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
    /// Interaction logic for UCListadoUsuarios.xaml
    /// </summary>
    public partial class UCListadoUsuarios : UserControl
    {
        private MVUsuario _mvUsuario;
        public UCListadoUsuarios(MVUsuario mVUsuario)
        {
            InitializeComponent();
            _mvUsuario = mVUsuario;
           
        }

        private async void ListadoUsuariosControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvUsuario.Inicializa();
            this.DataContext = _mvUsuario;
        }
    }
}
