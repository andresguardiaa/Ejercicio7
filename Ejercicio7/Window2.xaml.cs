using di.proyecto.clase._2025.Frontend.Mensajes;
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
using System.Windows.Shapes;

namespace Ejercicio7
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        private MVUsuario _mvUsuario;

        public Window2(MVUsuario mVUsuario)
        {
            InitializeComponent();
            _mvUsuario = mVUsuario;
        }

        private async void diagUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvUsuario.Inicializa();
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvUsuario.OnErrorEvent));
            DataContext = _mvUsuario;
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if(!_mvUsuario.IsValid(this))
            {

                    MensajeError.Mostrar("Victor Julai", "Xokas gigachad", 0);
                    MessageBox.Show("Apaña");
                
            }
            else if(await _mvUsuario.GuardarUsuario())
            {
                DialogResult = true;
            }
            
        }

        
    }
}
