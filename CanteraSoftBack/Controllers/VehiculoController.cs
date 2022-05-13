using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteraSoftBack.Contracts;
using CanteraSoftBack.Models;
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

        [HttpGet("SeleccionarPorId/{id}")]
        public async Task<ActionResult> SeleccionarPorId(int id)
        {
            try
            {
                var vehiculo = await _vehiculo.SeleccionarPorId(id);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult> Guardar(VehiculoModel vehiculoModel)
        {
            try
            {
                var vehiculo = await _vehiculo.Guardar(vehiculoModel);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult> Actualizar(VehiculoModel vehiculoModel)
        {
            try
            {
                var vehiculo = await _vehiculo.Actualizar(vehiculoModel);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}