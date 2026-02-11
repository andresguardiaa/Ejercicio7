using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM.Base;
using System.Windows.Data;

namespace Ejercicio7.MVVM
{
    public class MVUsuario : MVBase
    {
        private Usuario _usuario;
        private UsuarioRepository _usuarioRepository;
        private TipoUsuarioRepository _tipoUsuarioRepository;
        private RolRepository _rolRepository;

        private List<Tipousuario> _tipoUsuarioList;
        private List<Rol> _rolList;
        private List<Usuario> _usuarioList;
        private Tipousuario _tipoUsuarioSeleccionado;
        private ListCollectionView _listaUsuariosFiltro;

        public List<Tipousuario> tipoUsuarioList => _tipoUsuarioList;
        public List<Rol> rolList => _rolList;
        public List<Usuario> usuarioList => _usuarioList;
        

        private List<Predicate<Usuario>> _criterios;
        private Predicate<Usuario> _criterioTipo;
        private Predicate<Object> _predicadoFiltro;
        private Predicate<Usuario> _criterioNombre;
        private Predicate<Usuario> _criterioNumSalidas;
        private int _filtroNumSalidas;
        private string _filtroUsername;
        public int filtroNumSalidas
        {
            get => _filtroNumSalidas;
            set => SetProperty(ref _filtroNumSalidas, value);
        }
        public string filtroUsername
        {
            get => _filtroUsername;
            set => SetProperty(ref _filtroUsername, value);
        }

        public ListCollectionView listaUsuariosFiltro
        {
            get => _listaUsuariosFiltro;
            set => SetProperty(ref _listaUsuariosFiltro, value);
        }

        public Usuario usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        public Tipousuario tipoUsuarioSeleccionado
        {
            get => _tipoUsuarioSeleccionado;
            set => SetProperty(ref _tipoUsuarioSeleccionado, value);
        }


        public MVUsuario(UsuarioRepository usuarioRepository, TipoUsuarioRepository tipoUsuarioRepository, RolRepository rolRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _rolRepository = rolRepository;
            _usuario = new Usuario();

        }
        public async Task Inicializa()
        {
            _tipoUsuarioList = await GetAllAsync<Tipousuario>(_tipoUsuarioRepository);
            _rolList = await GetAllAsync<Rol>(_rolRepository);
            _usuarioList = await GetAllAsync<Usuario>(_usuarioRepository);
            listaUsuariosFiltro = new ListCollectionView(_usuarioList);
            _criterios = new List<Predicate<Usuario>>();
            InicializaCriterios();
            _predicadoFiltro = new Predicate<Object>(FiltroCriterios);


        }

        public async Task<bool> GuardarUsuario()
        {
            bool resultado = true;
            try
            {
                if (usuario.Idusuario == 0)
                {
                    await _usuarioRepository.AddAsync(usuario);
                }
                else
                {
                    await _usuarioRepository.UpdateAsync(usuario);
                }
                SnackbarMessageQueue.Enqueue("Usuario guardado correctamente.");
            }
            catch (Exception ex)
            {
                SnackbarMessageQueue.Enqueue($"Error al guardar el usuario: {ex.Message}");
                resultado = false;
            }
            return resultado;
        }
        public void Filtrar()
        {
            ActualizaCriterios();
            listaUsuariosFiltro.Filter = _predicadoFiltro;
        }

        private void InicializaCriterios()
        {
            _criterioTipo = new Predicate<Usuario>(u => u.TipoNavigation != null && u.TipoNavigation.Equals(_tipoUsuarioSeleccionado));
            _criterioNombre = new Predicate<Usuario>(u => !string.IsNullOrEmpty(u.Username) && !string.IsNullOrEmpty(filtroUsername) && u.Username.ToLower().Contains(filtroUsername.ToLower()));
            _criterioNumSalidas = new Predicate<Usuario>(u => u.Salida != null && u.Salida.Count >= filtroNumSalidas);
        }

        private void ActualizaCriterios()
        {
            _criterios.Clear();
            if (tipoUsuarioSeleccionado != null)
            {
                _criterios.Add(_criterioTipo);
            }

            
            if (!string.IsNullOrEmpty(filtroUsername))
            {
                _criterios.Add(_criterioNombre);
            }/* else
            {
                MessageBox.Show("El filtro de nombre de usuario está vacío o es incorrecto.", "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
            }*/

            if (filtroNumSalidas > 0)
            {
                _criterios.Add(_criterioNumSalidas);
            }

        }

        private bool FiltroCriterios(object item)
        {
            bool correcto = true;
            Usuario usuario = (Usuario) item;
            if(_criterios != null)
            {
                correcto = _criterios.TrueForAll(x => x(usuario));
            }
            return correcto;
        }
    }
}
