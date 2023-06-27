namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class InserirPlanoRequest
{
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Categoria { get; set; }
}
