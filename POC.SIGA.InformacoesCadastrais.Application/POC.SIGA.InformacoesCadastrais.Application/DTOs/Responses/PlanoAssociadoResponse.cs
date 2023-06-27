using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

public class PlanoAssociadoResponse
{
    public Guid Id { get; set; }
    public AssociadoResponse? Associado { get; set; }
    public PlanoResponse? Plano { get; set; }
    public int Tipo { get; set; }
    public int Cobertura { get; set; }
    public decimal ValorBase { get; set; }
    public decimal ValorAcrescimo { get; set; }
    public decimal ValorTotal { get; set; }
}
