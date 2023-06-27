using AutoMapper;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Application.Services.Planos;

public class PlanoService : IPlanoService
{
    private readonly IPlanoRepository _planoRepository;
    private readonly IMapper _mapper;

    public PlanoService(IPlanoRepository planoRepository, IMapper mapper)
    {
        _planoRepository = planoRepository;
        _mapper = mapper;
    }

    public async Task<PlanoResponse> Atualizar(AtualizarPlanoRequest request)
    {
        var plano = _mapper.Map<Plano>(request);
        plano = await _planoRepository.Atualizar(plano);

        var response = _mapper.Map<PlanoResponse>(plano);
        return response;
    }

    public async Task Excluir(Guid id)
    {
        await _planoRepository.Excluir(id);
    }

    public async Task<PlanoResponse> Inserir(InserirPlanoRequest request)
    {
        var plano = _mapper.Map<Plano>(request);
        plano = await _planoRepository.Inserir(plano);

        var response = _mapper.Map<PlanoResponse>(plano);
        return response;
    }

    public async Task<IEnumerable<PlanoResponse>> Listar()
    {
        var planos = await _planoRepository.Listar();
        var response = _mapper.Map<IEnumerable<PlanoResponse>>(planos);
        return response;
    }

    public async Task<PlanoResponse?> ObterPorId(Guid id)
    {
        var plano = await _planoRepository.ObterPorId(id);
        var response = _mapper.Map<PlanoResponse?>(plano);
        return response;
    }
}
