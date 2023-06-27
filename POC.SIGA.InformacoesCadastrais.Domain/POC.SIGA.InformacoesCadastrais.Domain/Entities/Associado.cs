using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.Domain.Entities;

public class Associado
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade => CalcularIdade();
    public EStatusAssociado Status { get; set; }
    public FaixaEtaria? FaixaEtaria { get; set; }

    private int CalcularIdade()
    {
        var dataAtual = DateTime.Now.Date;
        var idade = dataAtual.Year - DataNascimento.Year;
        if (DataNascimento.Date > dataAtual)
            idade--;

        return idade;
    }
}
