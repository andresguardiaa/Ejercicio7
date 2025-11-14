using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
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

namespace Ejercicio7.Dialogos
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private DiinventarioexamenContext _diinventarioexamenContext;
        private UsuarioRepository _usuarioRepository;
        private ILogger<GenericRepository<Usuario>> _logger;

        public Login()
        {
            InitializeComponent();
            //Instancia contexto y repositorio
            _diinventarioexamenContext = new DiinventarioexamenContext();
            _usuarioRepository = new UsuarioRepository(_diinventarioexamenContext, null);
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                bool isAuthenticated = await _usuarioRepository.LoginAsync(txtUsuario.Text, passClave.Password);
                if (isAuthenticated)
                {
                    MainWindow ventanaPrincipal = new MainWindow();
                    ventanaPrincipal.Show();
                    this.Close();
                
                } else {
                    MessageBox.Show("Usuario o clave incorrectos.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else
            {
                MessageBox.Show("Por favor, introduce usuario y clave.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void ventanaLogin_Loaded(object sender, RoutedEventArgs e)
        {
            _diinventarioexamenContext = new DiinventarioexamenContext();
            //Permite registrar eventos y errores
            _logger = LoggerFactory.Create(builder => 
            builder.AddConsole()
            ).CreateLogger<GenericRepository<Usuario>>();

            _usuarioRepository = new UsuarioRepository(_diinventarioexamenContext, _logger);

        }
    }
}
