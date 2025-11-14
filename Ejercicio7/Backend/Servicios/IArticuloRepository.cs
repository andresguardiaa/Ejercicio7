using di.proyecto.clase._2025.Backend.Servicios;
using Ejercicio7.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7.Backend.Servicios
{
    /// <summary>
    /// Contrato específico para operaciones sobre la entidad <see cref="Articulo"/>.
    /// Hereda las operaciones CRUD y de consulta definidas en <see cref="IGenericRepository{T}"/>.
    /// </summary>
    public interface IArticuloRepository : IGenericRepository<Articulo>
    {
    }
}