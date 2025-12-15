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
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {

        public RolRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Rol>> logger) : base(context, logger)
        {
        }

    }
}
