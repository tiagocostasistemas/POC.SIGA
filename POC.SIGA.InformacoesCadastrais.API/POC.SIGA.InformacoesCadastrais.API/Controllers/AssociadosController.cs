using Microsoft.AspNetCore.Mvc;
using POC.SIGA.InformacoesCadastrais.Application;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

namespace POC.SIGA.InformacoesCadastrais.API.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class AssociadosController : ControllerBase
{
    private readonly IInformacoesCadastraisService _service;

    public AssociadosController(IInformacoesCadastraisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var associados = await _service.ListarAssociados(); 
        return Ok(associados);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var associado = await _service.ObterAssociadoPorId(id);
        return Ok(associado);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InserirAssociadoRequest request)
    {
        var response = await _service.InserirAssociado(request);
        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put([FromBody] AtualizarAssociadoRequest request, Guid id)
    {
        var response = await _service.AtualizarAssociado(request);
        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delele(Guid id)
    {
        await _service.ExcluirAssociado(id);
        return Ok();
    }
}
