namespace POC.SIGA.InformacoesCadastrais.Application.DTOs.Requests;

public class InserirPlanoAssociadoRequest
{
    public Guid AssociadoId { get; set; }
    public Guid PlanoId { get; set; }
    public int Tipo { get; set; }
    public int Cobertura { get; set; }
}
