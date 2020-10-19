using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Respositories.Models
{
    public class AuditoriasPorEstatusModel
    {
        public int autorizadas { get; set; }
        public int propuestas { get; set; }
        public int rechazadas { get; set; }
    }
}
