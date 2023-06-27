using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Mensalidades;

public interface IMensalidadeService
{
    Task<IEnumerable<MensalidadeResponse>> Listar();
    Task<MensalidadeResponse?> ObterPorId(Guid id);
    Task<MensalidadeResponse> Inserir(InserirMensalidadeRequest request);
    Task<MensalidadeResponse> Atualizar(AtualizarMensalidadeRequest request);
    Task Excluir(Guid id);
}
