using Ejercicio7.MVVM;
using Microsoft.Extensions.DependencyInjection;
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
        private Window2 _dialogoUsuario;
        private readonly IServiceProvider _serviceProvider;
        public UCListadoUsuarios(MVUsuario mVUsuario,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mvUsuario = mVUsuario;
            _serviceProvider = serviceProvider;

        }

        private async void ListadoUsuariosControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvUsuario.Inicializa();
            this.DataContext = _mvUsuario;
        }

        private void cmEditarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbTipoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mvUsuario.Filtrar();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            _mvUsuario.Filtrar();
        }

       

        private async void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {

            _dialogoUsuario = _serviceProvider.GetRequiredService<Window2>();
            await _dialogoUsuario.Inicializa(_mvUsuario.usuario);
            _dialogoUsuario.ShowDialog();
            if(_dialogoUsuario.DialogResult == true)
            {
                
            }
        }
    }
}
