namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class AtualizarPlanoRequest
{
    public Guid Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Categoria { get; set; }
}
