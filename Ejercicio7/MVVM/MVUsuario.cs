using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Ejercicio7.Backend.Servicios;
using Ejercicio7.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Tipousuario> tipoUsuarioList => _tipoUsuarioList;
        public List<Rol> rolList => _rolList;
        public Usuario usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
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
        }

        public async Task GuardarUsuario()
        {
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
            }
        }
    }
}
