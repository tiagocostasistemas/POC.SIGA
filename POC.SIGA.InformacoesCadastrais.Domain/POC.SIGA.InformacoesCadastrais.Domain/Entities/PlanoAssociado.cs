using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.Domain.Entities;

public class PlanoAssociado
{
    public Guid Id { get; set; }
    public Associado? Associado { get; set; }
    public Plano? Plano { get; set; }
    public ETipoPlano Tipo { get; set; }
    public ECoberturaPlano Cobertura { get; set; }
    public decimal ValorBase => CalcularValorBase();
    public decimal ValorAcrescimo => CalcularValorAcrescimo();
    public decimal ValorTotal => CalcularValorTotal();

    private const decimal PERCENTUAL_ACRESCIMO_PLANO_ODONTOLOGICO = 15;

    private decimal CalcularValorBase()
    {
        return Plano!.Valor;
    }
    private decimal CalcularValorAcrescimo()
    {
        var valorAcrescimo = CalcularValorAcrescimoPorFaixaEtaria();

        if (!Plano!.Categoria.Equals(ECategoriaPlano.Vip) && Cobertura.Equals(ECoberturaPlano.MedicoOdontologico))
            valorAcrescimo +=  (ValorBase * PERCENTUAL_ACRESCIMO_PLANO_ODONTOLOGICO / 100);

        return valorAcrescimo;
    }

    private decimal CalcularValorAcrescimoPorFaixaEtaria()
    {
        decimal valorAcrescimo = (ValorBase * Associado!.FaixaEtaria!.PercentualAcrescimo / 100);
        return valorAcrescimo;
    }
    private decimal CalcularValorTotal()
    {
        return ValorBase + ValorAcrescimo;
    }
}
