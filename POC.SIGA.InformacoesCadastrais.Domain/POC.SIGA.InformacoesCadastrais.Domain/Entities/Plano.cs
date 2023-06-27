using POC.SIGA.InformacoesCadastrais.Domain.Enums;

namespace POC.SIGA.InformacoesCadastrais.Domain.Entities;

public class Plano
{
    public Guid Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public ECategoriaPlano Categoria { get; set; }

}
