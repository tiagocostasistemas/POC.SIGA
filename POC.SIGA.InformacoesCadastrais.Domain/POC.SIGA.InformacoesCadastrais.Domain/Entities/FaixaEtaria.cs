namespace POC.SIGA.InformacoesCadastrais.Domain.Entities;

public class FaixaEtaria
{
    public Guid Id { get; set; }
    public string Descricao => ObterDescricao();
    public int IdadeInicial { get; set; }
    public int IdadeFinal { get; set; }
    public decimal PercentualAcrescimo { get; set; }

    private string ObterDescricao()
    {
        return $"{IdadeInicial} anos até {IdadeFinal} anos";
    }
}
