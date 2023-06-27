using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.PlanosAssociados;

public interface IPlanoAssociadoService
{
    Task<IEnumerable<PlanoAssociadoResponse>> Listar();
    Task<PlanoAssociadoResponse?> ObterPorId(Guid id);
    Task<PlanoAssociadoResponse> Inserir(InserirPlanoAssociadoRequest request);
    Task<PlanoAssociadoResponse> Atualizar(AtualizarPlanoAssociadoRequest request);
    Task Excluir(Guid id);
}
