namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class AtualizarAssociadoRequest
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Status { get; set; }
}
