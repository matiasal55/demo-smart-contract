using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IServicioContrato _servicio;

        public ContratoController(IServicioContrato servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Contrato
        [HttpGet("crear")]
        public async Task<object> CrearContrato()
        {
            return await _servicio.CrearContrato();
        }

        [HttpPost("set")]
        public async Task<object> SetNumero([FromBody] ContratoPostReq data)
        {
            return await _servicio.SetNumero(data);
        }
        
        [HttpPost("get")]
        public async Task<object> GetNumero([FromBody] ContratoGetReq data)
        {
            return await _servicio.GetNumero(data);
        }
    }
}
