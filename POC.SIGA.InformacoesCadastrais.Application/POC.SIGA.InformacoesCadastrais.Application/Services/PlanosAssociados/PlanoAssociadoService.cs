using AutoMapper;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.PlanosAssociados;

public class PlanoAssociadoService : IPlanoAssociadoService
{
    private readonly IPlanoAssociadoRepository _planoAssociadoRepository;
    private readonly IAssociadoRepository _associadoRepository;
    private readonly IPlanoRepository _planoRepository;
    private readonly IMapper _mapper;

    public PlanoAssociadoService(IPlanoAssociadoRepository planoAssociadoRepository, IAssociadoRepository associadoRepository, IPlanoRepository planoRepository, IMapper mapper)
    {
        _planoAssociadoRepository = planoAssociadoRepository;
        _associadoRepository = associadoRepository;
        _planoRepository = planoRepository;
        _mapper = mapper;
    }

    public async Task<PlanoAssociadoResponse> Atualizar(AtualizarPlanoAssociadoRequest request)
    {
        var planoAssociado = _mapper.Map<PlanoAssociado>(request);

        planoAssociado.Associado = await _associadoRepository.ObterPorId(request.AssociadoId);
        planoAssociado.Plano = await _planoRepository.ObterPorId(request.PlanoId);

        planoAssociado = await _planoAssociadoRepository.Atualizar(planoAssociado);

        var response = _mapper.Map<PlanoAssociadoResponse>(planoAssociado);
        return response;
    }

    public async Task Excluir(Guid id)
    {
        await _planoAssociadoRepository.Excluir(id);
    }

    public async Task<PlanoAssociadoResponse> Inserir(InserirPlanoAssociadoRequest request)
    {
        var planoAssociado = _mapper.Map<PlanoAssociado>(request);  

        planoAssociado.Associado = await _associadoRepository.ObterPorId(request.AssociadoId);
        planoAssociado.Plano = await _planoRepository.ObterPorId(request.PlanoId);

        planoAssociado = await _planoAssociadoRepository.Inserir(planoAssociado);

        var response = _mapper.Map<PlanoAssociadoResponse>(planoAssociado);
        return response;
    }

    public async Task<IEnumerable<PlanoAssociadoResponse>> Listar()
    {
        var planosAssociados = await _planoAssociadoRepository.Listar();
        var response = _mapper.Map<IEnumerable<PlanoAssociadoResponse>>(planosAssociados);
        return response;
    }

    public async Task<PlanoAssociadoResponse?> ObterPorId(Guid id)
    {
        var planoAssociado = await _planoAssociadoRepository.ObterPorId(id);
        var response = _mapper.Map<PlanoAssociadoResponse>(planoAssociado);
        return response;
    }

    private decimal CalcularValorAcresimoPorFaixaEtaria(PlanoAssociado planoAssociado)
    {
        var idade = planoAssociado.Associado!.Idade;
        var faixas = new List<FaixaEtaria>();

        var faixa = faixas.Where(x => idade >= x.IdadeInicial && idade <= x.IdadeFinal).FirstOrDefault();

        return (planoAssociado.ValorBase * faixa!.PercentualAcrescimo / 100);
    }
}
