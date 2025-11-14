using Castle.Core.Logging;
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
    /// <summary>
    /// Implementación del repositorio para la entidad <see cref="Articulo"/>.
    /// Extiende <see cref="GenericRepository{Articulo}"/> y expone el contrato <see cref="IArticuloRepository"/>.
    /// </summary>
    public class ArticuloRepository : GenericRepository<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Articulo>> logger) 
            : base(context, logger)
        {
        }
    }
}