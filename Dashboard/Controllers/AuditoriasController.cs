using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Contracts;
using Dashboard.Respositories;
using Dashboard.Respositories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        IAuditoriaService _service;
        public AuditoriasController(IAuditoriaService service)
        {
            _service = service;
        }


        public IActionResult Get()
        {
            AuditoriasPorEstatusModel res = _service.ObtenerResultados();
            return Ok(res);
        }
    }
}
