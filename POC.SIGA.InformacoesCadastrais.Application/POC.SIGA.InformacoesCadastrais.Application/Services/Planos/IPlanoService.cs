using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Planos;

public interface IPlanoService
{
    Task<IEnumerable<PlanoResponse>> Listar();
    Task<PlanoResponse?> ObterPorId(Guid id);
    Task<PlanoResponse> Inserir(InserirPlanoRequest request);
    Task<PlanoResponse> Atualizar(AtualizarPlanoRequest request);
    Task Excluir(Guid id);
}
