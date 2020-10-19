using Dashboard.Contracts;
using Dashboard.Respositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Services
{
    public class AuditoriaService : IAuditoriaService
    {
        public readonly IAuditoriaRepository _repo;
        public AuditoriaService(IAuditoriaRepository repo)
        {
            _repo = repo;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AuditoriasPorEstatusModel ObtenerResultados()
        {
            return _repo.ObtenerResultados();
        }
    }
}
