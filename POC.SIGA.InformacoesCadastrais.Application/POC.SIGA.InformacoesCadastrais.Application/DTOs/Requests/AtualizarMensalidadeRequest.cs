namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class AtualizarMensalidadeRequest
{
    public Guid Id { get; set; }
    public Guid PlanoAssociadoId { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataLiquidacao { get; set; }
    public int Status { get; set; }
}
