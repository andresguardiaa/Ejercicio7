using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7.Backend.Servicios
{
    public class TipoUsuarioRepository : GenericRepository<Tipousuario>, ITipoUsuarioRepostory
    {

        public TipoUsuarioRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Tipousuario>> logger) : base(context, logger)
        {
        }

    }
}
