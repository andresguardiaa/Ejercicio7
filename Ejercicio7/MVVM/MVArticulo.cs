using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM.Base;

namespace Ejercicio7.MVVM
{
    public class MVArticulo : MVBase
    {

        ///Hereda de mvbase, para crear la lista y gestionar la validación

        /// <summary>
        /// Objeto modelo de articulo que estamos gestionando
        /// vinculado a la lista para mostrar y editar los datos
        /// </summary>

        private Modeloarticulo _modeloArticulo;
        private ModeloArticuloRepository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;

        private List<Tipoarticulo> _tipoArticuloList;


        public List<Tipoarticulo> tipoArticuloList => _tipoArticuloList;

        public Modeloarticulo modeloArticulo
        { 
            get => _modeloArticulo;
            set => SetProperty(ref _modeloArticulo, value);
        }



        public MVArticulo(ModeloArticuloRepository modeloArticuloRepository, TipoArticuloRepository tipoArticuloRepository)
        {

            _modeloArticuloRepository = modeloArticuloRepository;
            _tipoArticuloRepository = tipoArticuloRepository;
            _modeloArticulo = new Modeloarticulo();


        }

        public async Task Inicializa()
        {
            _tipoArticuloList = await GetAllAsync<Tipoarticulo>(_tipoArticuloRepository);
        }





    }
}
