using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoApi.DTOs;
using PedidoApi.Services;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class ClienteController : ControllerBase
{
    
    private readonly ClienteService _service;
    
    public ClienteController(ClienteService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {   
        var clientes = await _service.ObterTodosAsync();
        var dtos = clientes.Select(c => new ClienteDto{Nome = c.Nome, Email = c.Email}).ToList();
        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CriarCliente(ClienteDto dto)
    {
        var cliente = new Cliente { Nome = dto.Nome, Email = dto.Email };
        var criado = await _service.CriarCliente(cliente);
        var criadoDto = new ClienteDto{Nome = criado.Nome, Email = criado.Email};
        return CreatedAtAction(nameof(GetClientes), new {id = criado.Id}, criadoDto);
    }
}