using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM.Base;

namespace Ejercicio7.MVVM
{
    public class MVEspacios : MVBase
    {
        private EspacioRepository _espacioRepository;
        private List<Espacio> _espacios;
        private List<Modeloarticulo> _modelosArticulo;
        private List<Departamento> _departamentos;
        private List<Usuario> _usuarios;

        private ModeloArticuloRepository _modeloArticuloRepository;
        private UsuarioRepository _usuarioRepository;
        private DepartamentoRepository _departamentoRepository;
        
        private Articulo _articuloSeleccionado;

        public List<Modeloarticulo> modeloarticulos => _modelosArticulo;
        public List<Departamento> departamentos => _departamentos;
        public List<Usuario> usuarios => _usuarios;
        public Articulo articuloSeleccionado
        {
            get { return _articuloSeleccionado; }
            set
            {
                SetProperty(ref _articuloSeleccionado, value);
            }
        }

        public List<Espacio> espacios
        {
            get { return _espacios; }
            set
            {
                SetProperty(ref _espacios, value);
            }
        }

        public MVEspacios(EspacioRepository espacioRepository, ModeloArticuloRepository modeloArticuloRepository, UsuarioRepository usuarioRepository, DepartamentoRepository departamentoRepository)
        {
            _espacioRepository = espacioRepository;
            _modeloArticuloRepository = modeloArticuloRepository;
            _departamentoRepository = departamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task Inicializa()
        {
            try
            {
                await InicializaListas();
            }
            catch (Exception ex)
            {
                SnackbarMessageQueue.Enqueue($"Error al cargar las Listas: {ex.Message}");
            }
        }

        public async Task InicializaListas()
        {
            _espacios = await GetAllAsync(_espacioRepository);
            _departamentos = await GetAllAsync(_departamentoRepository);
            _modelosArticulo = await GetAllAsync(_modeloArticuloRepository);
            _usuarios = await GetAllAsync(_usuarioRepository);

        }


    }
}
