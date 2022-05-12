using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteraSoftBack.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanteraSoftBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculo _vehiculo;

        public VehiculoController(IVehiculo vehiculo)
        {
            _vehiculo = vehiculo;
        }

        [HttpGet("SeleccionarTodos")]
        public async Task<ActionResult> SeleccionarTodos()
        {
            try
            {
                var vehiculos = await _vehiculo.SeleccionarTodos();
                return Ok(vehiculos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}