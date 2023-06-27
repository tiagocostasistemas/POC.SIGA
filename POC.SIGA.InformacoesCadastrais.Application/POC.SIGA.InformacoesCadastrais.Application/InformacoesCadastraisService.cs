using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Application.Services.Associados;
using POC.SIGA.InformacoesCadastrais.Application.Services.Mensalidades;
using POC.SIGA.InformacoesCadastrais.Application.Services.Planos;
using POC.SIGA.InformacoesCadastrais.Application.Services.PlanosAssociados;

namespace POC.SIGA.InformacoesCadastrais.Application
{
    public class InformacoesCadastraisService : IInformacoesCadastraisService
    {
        private readonly IAssociadoService _associadoService;
        private readonly IPlanoService _planoService;
        private readonly IPlanoAssociadoService _planoAssociadoService;
        private readonly IMensalidadeService _MensalidadeService;

        public InformacoesCadastraisService(IAssociadoService associadoService, IPlanoService planoService, IPlanoAssociadoService planoAssociadoService, IMensalidadeService MensalidadeService)
        {
            _associadoService = associadoService;
            _planoService = planoService;
            _planoAssociadoService = planoAssociadoService;
            _MensalidadeService = MensalidadeService;
        }



        #region Associados
        public async Task<AssociadoResponse> AtualizarAssociado(AtualizarAssociadoRequest request)
        {
            return await _associadoService.Atualizar(request);
        }

        public async Task ExcluirAssociado(Guid id)
        {
            await _associadoService.Excluir(id);
        }

        public async Task<AssociadoResponse> InserirAssociado(InserirAssociadoRequest request)
        {
            return await _associadoService.Inserir(request);
        }

        public async Task<IEnumerable<AssociadoResponse>> ListarAssociados()
        {
            return await _associadoService.Listar();
        }

        public async Task<AssociadoResponse?> ObterAssociadoPorId(Guid id)
        {
            return await _associadoService.ObterPorId(id);
        }
        #endregion

        #region Planos
        public async Task<PlanoResponse> AtualizarPlano(AtualizarPlanoRequest request)
        {
            return await _planoService.Atualizar(request);
        }

        public async Task ExcluirPlano(Guid id)
        {
            await _planoService.Excluir(id);
        }

        public async Task<PlanoResponse> InserirPlano(InserirPlanoRequest request)
        {
            return await _planoService.Inserir(request);
        }

        public async Task<IEnumerable<PlanoResponse>> ListarPlanos()
        {
            return await _planoService.Listar();
        }

        public async Task<PlanoResponse?> ObterPlanoPorId(Guid id)
        {
            return await _planoService.ObterPorId(id);
        }
        #endregion

        #region PlanosAssociados
        public async Task<PlanoAssociadoResponse> AtualizarPlanoAssociado(AtualizarPlanoAssociadoRequest request)
        {
            return await _planoAssociadoService.Atualizar(request);
        }

        public async Task ExcluirPlanoAssociado(Guid id)
        {
            await _planoAssociadoService.Excluir(id);
        }

        public async Task<PlanoAssociadoResponse> InserirPlanoAssociado(InserirPlanoAssociadoRequest request)
        {
            return await _planoAssociadoService.Inserir(request);
        }

        public async Task<IEnumerable<PlanoAssociadoResponse>> ListarPlanosAssociados()
        {
            return await _planoAssociadoService.Listar();
        }

        public async Task<PlanoAssociadoResponse?> ObterPlanoAssociadoPorId(Guid id)
        {
            return await _planoAssociadoService.ObterPorId(id);
        }
        #endregion

        #region Mensalidades
        public async Task<MensalidadeResponse> AtualizarMensalidade(AtualizarMensalidadeRequest request)
        {
            return await _MensalidadeService.Atualizar(request);
        }

        public async Task ExcluirMensalidade(Guid id)
        {
            await _MensalidadeService.Excluir(id);
        }

        public async Task<MensalidadeResponse> InserirMensalidade(InserirMensalidadeRequest request)
        {
            return await _MensalidadeService.Inserir(request);
        }

        public async Task<IEnumerable<MensalidadeResponse>> ListarMensalidades()
        {
            return await _MensalidadeService.Listar();
        }

        public async Task<MensalidadeResponse?> ObterMensalidadePorId(Guid id)
        {
            return await _MensalidadeService.ObterPorId(id);
        }
        #endregion

    }
}
