using Microsoft.AspNetCore.Mvc;
using POC.SIGA.InformacoesCadastrais.Application;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.API.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class PlanosAssociadosController : ControllerBase
{
    private readonly IInformacoesCadastraisService _service;

    public PlanosAssociadosController(IInformacoesCadastraisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var planosAssociados = await _service.ListarPlanosAssociados();
        return Ok(planosAssociados);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var planoAssociado = await _service.ObterPlanoAssociadoPorId(id);
        return Ok(planoAssociado);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InserirPlanoAssociadoRequest request)
    {
        var response = await _service.InserirPlanoAssociado(request);
        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put([FromBody] AtualizarPlanoAssociadoRequest request, Guid id)
    {
        var response = await _service.AtualizarPlanoAssociado(request);
        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delele(Guid id)
    {
        await _service.ExcluirPlanoAssociado(id);
        return Ok();
    }
}
