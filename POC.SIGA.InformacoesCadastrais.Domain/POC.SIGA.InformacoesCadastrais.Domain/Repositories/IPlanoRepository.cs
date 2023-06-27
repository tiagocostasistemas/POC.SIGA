using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Domain.Repositories;

public interface IPlanoRepository
{
    Task<IEnumerable<Plano>> Listar();
    Task<Plano?> ObterPorId(Guid id);
    Task<Plano> Inserir(Plano plano);
    Task<Plano> Atualizar(Plano plano);
    Task Excluir(Guid id);
}
