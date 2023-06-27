namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class InserirMensalidadeRequest
{
    public Guid PlanoAssociadoId { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataLiquidacao { get; set; }
    public int Status { get; set; }
}
