using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Domain.Repositories;

public interface IAssociadoRepository
{
    Task<IEnumerable<Associado>> Listar();
    Task<Associado?> ObterPorId(Guid id);
    Task<Associado> Inserir(Associado associado);
    Task<Associado> Atualizar(Associado associado);
    Task Excluir(Guid id);
}
