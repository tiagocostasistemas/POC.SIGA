using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Associados;

public interface IAssociadoService
{
    Task<IEnumerable<AssociadoResponse>> Listar();
    Task<AssociadoResponse?> ObterPorId(Guid id);
    Task<AssociadoResponse> Inserir(InserirAssociadoRequest request);
    Task<AssociadoResponse> Atualizar(AtualizarAssociadoRequest request);
    Task Excluir(Guid id);
}
