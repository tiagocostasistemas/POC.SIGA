using Microsoft.AspNetCore.Mvc;
using POC.SIGA.InformacoesCadastrais.Application;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.API.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class MensalidadesController : ControllerBase
{
    private readonly IInformacoesCadastraisService _service;

    public MensalidadesController(IInformacoesCadastraisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Mensalidades = await _service.ListarMensalidades();
        return Ok(Mensalidades);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var Mensalidade = await _service.ObterMensalidadePorId(id);
        return Ok(Mensalidade);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InserirMensalidadeRequest request)
    {
        var response = await _service.InserirMensalidade(request);
        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put([FromBody] AtualizarMensalidadeRequest request, Guid id)
    {
        var response = await _service.AtualizarMensalidade(request);
        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delele(Guid id)
    {
        await _service.ExcluirMensalidade(id);
        return Ok();
    }
}
