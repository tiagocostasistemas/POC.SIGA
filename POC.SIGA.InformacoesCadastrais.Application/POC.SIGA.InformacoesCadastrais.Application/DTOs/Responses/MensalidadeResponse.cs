namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

public class MensalidadeResponse
{
    public Guid Id { get; set; }
    public PlanoAssociadoResponse? PlanoAssociado { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataLiquidacao { get; set; }
    public int Status { get; set; }
    public decimal Valor { get; set; }
}
