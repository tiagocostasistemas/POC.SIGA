using Microsoft.AspNetCore.Mvc;
using POC.SIGA.InformacoesCadastrais.Application;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.API.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class PlanosController : ControllerBase
{
    private readonly IInformacoesCadastraisService _service;

    public PlanosController(IInformacoesCadastraisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var planos = await _service.ListarPlanos();
        return Ok(planos);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var plano = await _service.ObterPlanoPorId(id);
        return Ok(plano);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InserirPlanoRequest request)
    {
        var response = await _service.InserirPlano(request);
        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put([FromBody] AtualizarPlanoRequest plano, Guid id)
    {
        var response = await _service.AtualizarPlano(plano);
        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delele(Guid id)
    {
        await _service.ExcluirPlano(id);
        return Ok();
    }
}
