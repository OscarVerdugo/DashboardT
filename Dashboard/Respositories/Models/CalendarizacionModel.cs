using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Respositories.Models
{
    public class CalendarizacionModel
    {
        public string codAuditoria { get; set; }
        public int idAuditoria { get; set; }
        public string codCalendarizacion { get; set; }
        public DateTime fechaInicialProyectada { get; set; }
        public DateTime fechaFinalProyectada { get; set; }
        public DateTime fechaInicialReal { get; set; }
        public DateTime fechaFinalReal { get; set; }
        public DateTime fechaElaboracion { get; set; }

    }
}
