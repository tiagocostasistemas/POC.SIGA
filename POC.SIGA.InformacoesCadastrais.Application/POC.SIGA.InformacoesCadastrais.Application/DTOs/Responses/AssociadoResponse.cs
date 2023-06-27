namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Responses;

public class AssociadoResponse
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
    public int Status { get; set; }
}
