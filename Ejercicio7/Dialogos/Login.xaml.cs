using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.Frontend.Mensajes;
using Ejercicio7.Backend.Modelo;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Ejercicio7.Dialogos
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private DiinventarioexamenContext _diinventarioexamenContext;
        private UsuarioRepository _usuarioRepository;
        //private ILogger<GenericRepository<Usuario>> _logger;
        private readonly MainWindow _ventanaPrincipal;

        public Login(UsuarioRepository usuarioRepository, MainWindow ventanaPrincipal)
        {
            InitializeComponent();
            //Instancia contexto y repositorio
            //_diinventarioexamenContext = DiinventarioexamenContext();
            _usuarioRepository = usuarioRepository;
            _ventanaPrincipal = ventanaPrincipal;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                bool isAuthenticated = await _usuarioRepository.LoginAsync(txtUsuario.Text, passClave.Password);
                if (isAuthenticated)
                {
                    _ventanaPrincipal.Show();
                    this.Close();
                
                } else {
                   MensajeError.Mostrar("Error de autenticación", "Usuario o clave incorrectos.", 3);

                }

            }
            else
            {
                MensajeAdvertencia.Mostrar("Campos vacíos", "Por favor, ingrese usuario y clave.", 3);

            }


        }

    }
}
