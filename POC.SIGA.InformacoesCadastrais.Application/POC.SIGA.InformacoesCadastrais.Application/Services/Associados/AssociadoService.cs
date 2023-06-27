using AutoMapper;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Associados;

public class AssociadoService : IAssociadoService
{
    private readonly IAssociadoRepository _associadoRepository;
    private readonly IMapper _mapper;

    public AssociadoService(IAssociadoRepository associadoRepository, IMapper mapper)
    {
        _associadoRepository = associadoRepository;
        _mapper = mapper;
    }

    public async Task<AssociadoResponse> Atualizar(AtualizarAssociadoRequest request)
    {
        var associado = _mapper.Map<Associado>(request);
          
        await _associadoRepository.Atualizar(associado);

        var response = _mapper.Map<AssociadoResponse>(associado);
        return response;
    }

    public async Task Excluir(Guid id)
    {
        await _associadoRepository.Excluir(id);
    }

    public async Task<AssociadoResponse> Inserir(InserirAssociadoRequest request)
    {
        var associado = _mapper.Map<Associado>(request);

        associado = await _associadoRepository.Inserir(associado);

        var response = _mapper.Map<AssociadoResponse>(associado);
        return response;
    }

    public async Task<IEnumerable<AssociadoResponse>> Listar()
    {
        var associados = await _associadoRepository.Listar();
        var response = _mapper.Map<IEnumerable<AssociadoResponse>>(associados);
        return response;
    }

    public async Task<AssociadoResponse?> ObterPorId(Guid id)
    {
        var associado = await _associadoRepository.ObterPorId(id);
        var response = _mapper.Map<AssociadoResponse?>(associado);
        return response;
    }
}
