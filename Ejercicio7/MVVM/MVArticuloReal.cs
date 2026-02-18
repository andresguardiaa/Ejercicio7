using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ejercicio7.MVVM
{
    public class MVArticuloReal : MVBase
    {
        private Articulo _articulo;
        private ArticuloRepository _articuloRepository;
        private DepartamentoRepository _departamentoRepository;
        private List<Articulo> _listaArticulos;
        private List<Departamento> _listaDepartamentos;
        private Articulo _articuloSeleccionado;
        private Departamento _departamentoSeleccionado;


        private ListCollectionView _listaArticulosFiltro; //Lista que se muestra en el DataGrid, con los filtros aplicados, o ninguno si no hay filtros
        private List<Predicate<Articulo>> _criterios; //Lista de criterios de filtrado, se añaden o eliminan según los filtros que se quieran aplicar
        private Predicate<Object> _predicadoFiltro; //Predicado que se asigna al filtro del ListCollectionView, y que se encarga de aplicar todos los criterios de filtrado que haya en la lista de criterios
        private Predicate<Articulo> _criterioNumSerie; //Criterio de filtrado por número de serie, se añade a la lista de criterios si el filtro de número de serie no está vacío, y se elimina si el filtro de número de serie está vacío
        private Predicate<Articulo> _criterioDepartamento; //Criterio de filtrado por departamento, se añade a la lista de criterios si el filtro de departamento no está vacío, y se elimina si el filtro de departamento está vacío
        private Predicate<Articulo> _criterioTieneNumserie; //Criterio de filtrado por si el artículo tiene número de serie o no, se añade a la lista de criterios si el filtro de tiene número de serie está activado, y se elimina si el filtro de tiene número de serie está desactivado
        
        private string _filtroNumSerie; //Valor del filtro de número de serie, se asigna a la propiedad del filtro, y se utiliza para crear el criterio de filtrado por número de serie
        private bool _filtroTieneNumSerie; //Valor del filtro de tiene número de serie, se asigna a la propiedad del filtro, y se utiliza para crear el criterio de filtrado por si el artículo tiene número de serie o no
        public string filtroNumSerie
        {
            get => _filtroNumSerie;
            set
            {
                SetProperty(ref _filtroNumSerie, value);
                Filtrar();// lo llamamos aquí para que cada vez que se cambie el valor del filtro, se apliquen los filtros a la lista de artículos, y se actualice el DataGrid automáticamente
            }
        }

        public bool filtroTieneNumSerie
        {
            get => _filtroTieneNumSerie;
            set 
            { 
                SetProperty(ref _filtroTieneNumSerie, value);
                Filtrar(); 
            }
        }

        public Articulo articuloSeleccionadoReal
        {
            get => _articuloSeleccionado;
            set => SetProperty(ref _articuloSeleccionado, value);
        }
        public Departamento departamentoSeleccionado
        {
            get => _departamentoSeleccionado;
            set
            {
                SetProperty(ref _departamentoSeleccionado, value);
                Filtrar();
            }
        }

        public List<Articulo> listaArticulos => _listaArticulos;
        public List<Departamento> listaDepartamentos => _listaDepartamentos;
        public ListCollectionView listaArticulosFiltro
        {             
            get => _listaArticulosFiltro;
            set => SetProperty(ref _listaArticulosFiltro, value);
        }

        public MVArticuloReal(ArticuloRepository articuloRepository, DepartamentoRepository departamentoRepository) 
        { 
            _articuloRepository = articuloRepository;
            _departamentoRepository = departamentoRepository;

        }


        public async Task Inicializa()
        {
            try
            {
                await InicializaListas();
                InicializaCriterios();
                _criterios = new List<Predicate<Articulo>>(); //importante inicializar que sino el .Clear() de la función AddCriterios() da error de referencia a objeto no establecido
                _predicadoFiltro = new Predicate<object>(FiltroCriterios);
            }
            catch (Exception ex)
            {
                SnackbarMessageQueue.Enqueue($"Error al cargar las Listas: {ex.Message}");

            }
        }

        

        private async Task InicializaListas()
        {
            _listaArticulos = await GetAllAsync<Articulo>(_articuloRepository);
            _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
            _listaArticulosFiltro = new ListCollectionView(_listaArticulos);
        }

        public void Filtrar()
        {
            AddCriterios();
            listaArticulosFiltro.Filter = _predicadoFiltro;
        }


        private void InicializaCriterios() //Inicializa los criterios de filtrado
        {
            _criterioDepartamento = new Predicate<Articulo>(a => a.DepartamentoNavigation != null && a.DepartamentoNavigation.Equals(_departamentoSeleccionado));
            _criterioNumSerie = new Predicate<Articulo>(a => !string.IsNullOrEmpty(a.Numserie) && !string.IsNullOrEmpty(filtroNumSerie) && a.Numserie.ToLower().StartsWith(filtroNumSerie.ToLower()));
            _criterioTieneNumserie = new Predicate<Articulo>(a => !string.IsNullOrEmpty(a.Numserie));
        }

        private void AddCriterios()
        {
            _criterios.Clear();
            if (!string.IsNullOrEmpty(filtroNumSerie))
            {
                _criterios.Add(_criterioNumSerie);
            }

            if (departamentoSeleccionado != null)
            {
                _criterios.Add(_criterioDepartamento);
            }

            if (filtroTieneNumSerie)
            {
                _criterios.Add(_criterioTieneNumserie);
            }

        }

        private bool FiltroCriterios(object item) //Aplica todos los criterios de filtrado que haya en la lista de criterios, si no hay ningún criterio, devuelve true para mostrar todos los elementos
        {
            bool correcto = true;
            Articulo articulo = (Articulo) item;
            if (_criterios != null)
            {
                correcto = _criterios.TrueForAll(x => x(articulo));
            }
            return correcto;
        }
    }
}
