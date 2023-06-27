namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class AtualizarPlanoAssociadoRequest
{
    public Guid Id { get; set; }
    public Guid AssociadoId { get; set; }
    public Guid PlanoId { get; set; }
    public int Tipo { get; set; }
    public int Cobertura { get; set; }
}
