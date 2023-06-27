using AutoMapper;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Mensalidades;

public class MensalidadeService : IMensalidadeService
{
    private readonly IMensalidadeRepository _MensalidadeRepository;
    private readonly IPlanoAssociadoRepository _planoAssociadoRepository;
    private readonly IMapper _mapper;

    public MensalidadeService(IMensalidadeRepository MensalidadeRepository, IPlanoAssociadoRepository planoAssociadoRepository, IMapper mapper)
    {
        _MensalidadeRepository = MensalidadeRepository;
        _planoAssociadoRepository = planoAssociadoRepository;
        _mapper = mapper;
    }

    public async Task<MensalidadeResponse> Atualizar(AtualizarMensalidadeRequest request)
    {
        var Mensalidade = _mapper.Map<Mensalidade>(request);
        Mensalidade.PlanoAssociado = await _planoAssociadoRepository.ObterPorId(request.PlanoAssociadoId);
        Mensalidade = await _MensalidadeRepository.Atualizar(Mensalidade);

        var response = _mapper.Map<MensalidadeResponse>(Mensalidade);
        return response;
    }

    public async Task Excluir(Guid id)
    {
        await _MensalidadeRepository.Excluir(id);
    }

    public async Task<MensalidadeResponse> Inserir(InserirMensalidadeRequest request)
    {
        var Mensalidade = _mapper.Map<Mensalidade>(request);

        Mensalidade.PlanoAssociado = await _planoAssociadoRepository.ObterPorId(request.PlanoAssociadoId);
        Mensalidade = await _MensalidadeRepository.Inserir(Mensalidade);
        

        var response = _mapper.Map<MensalidadeResponse>(Mensalidade);
        return response;
    }

    public async Task<IEnumerable<MensalidadeResponse>> Listar()
    {
        var Mensalidades = await _MensalidadeRepository.Listar();
        var response = _mapper.Map<IEnumerable<MensalidadeResponse>>(Mensalidades);
        return response;
    }

    public async Task<MensalidadeResponse?> ObterPorId(Guid id)
    {
        var Mensalidade = await _MensalidadeRepository.ObterPorId(id);
        var response = _mapper.Map<MensalidadeResponse>(Mensalidade);
        return response;
    }
}
