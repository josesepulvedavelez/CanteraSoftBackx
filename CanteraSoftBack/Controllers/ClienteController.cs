using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteraSoftBack.Contracts;
using CanteraSoftBack.Data;
using CanteraSoftBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanteraSoftBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet("SeleccionarTodos")]
        public async Task<ActionResult> SeleccionarTodos()
        {
            try
            {
                var clientes = await _cliente.SeleccionarTodos();
                return Ok(clientes);
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
                var cliente = await _cliente.SeleccionarPorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult> Guardar(ClienteModel element)
        {
            try
            {
                var cliente = await _cliente.Guardar(element);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult> Actualizar(ClienteModel element)
        {
            try
            {
                var cliente = await _cliente.Actualizar(element);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}