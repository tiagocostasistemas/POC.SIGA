using AutoMapper;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;
using POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.API.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMapAssociado();
        CreateMapPlano();
        CreateMapPlanoAssociado();
        CreateMapMensalidade();
    }

    private void CreateMapAssociado()
    {
        CreateMap<Associado, AssociadoResponse>()
            .ForMember(response => response.Status, opt => opt.MapFrom(associado => (int)associado.Status));

        CreateMap<InserirAssociadoRequest, Associado>()
            .ForMember(associado => associado.Status, opt => opt.MapFrom(request => (EStatusAssociado)request.Status))
            .ForMember(associado => associado.Idade, opt => opt.Ignore())
            .ForMember(associado => associado.Id, opt => opt.Ignore())
            .ForMember(associado => associado.FaixaEtaria, opt => opt.Ignore());

        CreateMap<AtualizarAssociadoRequest, Associado>()
            .ForMember(associado => associado.Status, opt => opt.MapFrom(request => (EStatusAssociado)request.Status))
            .ForMember(associado => associado.Idade, opt => opt.Ignore())
            .ForMember(associado => associado.FaixaEtaria, opt => opt.Ignore());
    }

    private void CreateMapPlano()
    {
        CreateMap<Plano, PlanoResponse>()
            .ForMember(response => response.Categoria, opt => opt.MapFrom(plano => (int)plano.Categoria));

        CreateMap<InserirPlanoRequest, Plano>()
            .ForMember(plano => plano.Categoria, opt => opt.MapFrom(request => (ECategoriaPlano)request.Categoria))
            .ForMember(plano => plano.Id, opt => opt.Ignore());

        CreateMap<AtualizarPlanoRequest, Plano>()
            .ForMember(plano => plano.Categoria, opt => opt.MapFrom(request => (ECategoriaPlano)request.Categoria));
    }

    private void CreateMapPlanoAssociado()
    {
        CreateMap<PlanoAssociado, PlanoAssociadoResponse>()
            .ForMember(response => response.Tipo, opt => opt.MapFrom(planoAssociado => (int)planoAssociado.Tipo))
            .ForMember(response => response.Cobertura, opt => opt.MapFrom(planoAssociado => (int)planoAssociado.Cobertura));

        CreateMap<InserirPlanoAssociadoRequest, PlanoAssociado>()
            .ForMember(planoAssociado => planoAssociado.Tipo, opt => opt.MapFrom(request => (ETipoPlano)request.Tipo))
            .ForMember(planoAssociado => planoAssociado.Cobertura, opt => opt.MapFrom(request => (ECoberturaPlano)request.Cobertura))
            .ForMember(planoAssociado => planoAssociado.Id, opt => opt.Ignore())
            .ForMember(planoAssociado => planoAssociado.Associado, opt => opt.Ignore())
            .ForMember(planoAssociado => planoAssociado.Plano, opt => opt.Ignore())
            .ForMember(planoAssociado => planoAssociado.ValorBase, opt => opt.Ignore())
            .ForMember(planoAssociado => planoAssociado.ValorAcrescimo, opt => opt.Ignore())
            .ForMember(planoAssociado => planoAssociado.ValorTotal, opt => opt.Ignore());
    }

    private void CreateMapMensalidade()
    {
        CreateMap<Mensalidade, MensalidadeResponse>()
            .ForMember(response => response.Status, opt => opt.MapFrom(Mensalidade => (int)Mensalidade.Status));

        CreateMap<InserirMensalidadeRequest, Mensalidade>()
            .ForMember(Mensalidade => Mensalidade.Status, opt => opt.MapFrom(request => (EStatusMensalidade)request.Status));

        CreateMap<AtualizarMensalidadeRequest, Mensalidade>()
            .ForMember(Mensalidade => Mensalidade.Status, opt => opt.MapFrom(request => (EStatusMensalidade)request.Status));
    }
}

