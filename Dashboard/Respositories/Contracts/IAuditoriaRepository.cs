using Dashboard.Contracts;
using Dashboard.Respositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard
{
    public interface IAuditoriaRepository : IBaseRespository<AuditoriasPorEstatusModel>
    {
        AuditoriasPorEstatusModel ObtenerResultados ();
    }
}
