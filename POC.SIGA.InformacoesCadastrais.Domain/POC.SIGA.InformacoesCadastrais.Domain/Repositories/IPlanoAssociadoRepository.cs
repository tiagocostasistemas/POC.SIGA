using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Domain.Repositories;

public interface IPlanoAssociadoRepository
{
    Task<IEnumerable<PlanoAssociado>> Listar();
    Task<PlanoAssociado?> ObterPorId(Guid id);
    Task<PlanoAssociado> Inserir(PlanoAssociado planoAssociado);
    Task<PlanoAssociado> Atualizar(PlanoAssociado planoAssociado);
    Task Excluir(Guid id);
}
