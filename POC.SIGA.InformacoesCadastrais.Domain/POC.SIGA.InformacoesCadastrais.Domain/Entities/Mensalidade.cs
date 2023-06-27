using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.Domain.Entities;

public class Mensalidade
{
    public Guid Id { get; set; }
    public PlanoAssociado? PlanoAssociado { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataLiquidacao { get; set; }
    public EStatusMensalidade Status { get; set; }
    public decimal Valor => CalcularValor();

    private decimal CalcularValor()
    {
        return PlanoAssociado!.ValorTotal;
    }
}
