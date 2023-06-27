using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

namespace POC.SIGA.InformacoesCadastrais.Application
{
    public interface IInformacoesCadastraisService
    {
        #region Associados
        Task<IEnumerable<AssociadoResponse>> ListarAssociados();
        Task<AssociadoResponse?> ObterAssociadoPorId(Guid id);
        Task<AssociadoResponse> InserirAssociado(InserirAssociadoRequest request);
        Task<AssociadoResponse> AtualizarAssociado(AtualizarAssociadoRequest request);
        Task ExcluirAssociado(Guid id);
        #endregion

        #region Planos
        Task<IEnumerable<PlanoResponse>> ListarPlanos();
        Task<PlanoResponse?> ObterPlanoPorId(Guid id);
        Task<PlanoResponse> InserirPlano(InserirPlanoRequest request);
        Task<PlanoResponse> AtualizarPlano(AtualizarPlanoRequest request);
        Task ExcluirPlano(Guid id);
        #endregion

        #region PlanosAssociados
        Task<IEnumerable<PlanoAssociadoResponse>> ListarPlanosAssociados();
        Task<PlanoAssociadoResponse?> ObterPlanoAssociadoPorId(Guid id);
        Task<PlanoAssociadoResponse> InserirPlanoAssociado(InserirPlanoAssociadoRequest request);
        Task<PlanoAssociadoResponse> AtualizarPlanoAssociado(AtualizarPlanoAssociadoRequest request);
        Task ExcluirPlanoAssociado(Guid id);
        #endregion

        #region Mensalidades
        Task<IEnumerable<MensalidadeResponse>> ListarMensalidades();
        Task<MensalidadeResponse?> ObterMensalidadePorId(Guid id);
        Task<MensalidadeResponse> InserirMensalidade(InserirMensalidadeRequest request);
        Task<MensalidadeResponse> AtualizarMensalidade(AtualizarMensalidadeRequest request);
        Task ExcluirMensalidade(Guid id);
        #endregion
    }
}
