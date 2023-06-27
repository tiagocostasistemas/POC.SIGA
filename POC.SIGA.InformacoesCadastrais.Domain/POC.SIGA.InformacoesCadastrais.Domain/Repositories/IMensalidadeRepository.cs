using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Domain.Repositories;

public interface IMensalidadeRepository
{
    Task<IEnumerable<Mensalidade>> Listar();
    Task<Mensalidade?> ObterPorId(Guid id);
    Task<Mensalidade> Inserir(Mensalidade Mensalidade);
    Task<Mensalidade> Atualizar(Mensalidade Mensalidade);
    Task Excluir(Guid id);
}
