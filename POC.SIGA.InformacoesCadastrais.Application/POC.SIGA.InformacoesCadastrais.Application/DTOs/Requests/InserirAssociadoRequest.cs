namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class InserirAssociadoRequest
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Status { get; set; }
}
