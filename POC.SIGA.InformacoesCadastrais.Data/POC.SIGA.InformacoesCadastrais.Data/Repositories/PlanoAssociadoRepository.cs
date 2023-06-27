using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Data.Contexts;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Data.Repositories;

public class PlanoAssociadoRepository : IPlanoAssociadoRepository
{
    private readonly DataContext _context;

    public PlanoAssociadoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<PlanoAssociado> Atualizar(PlanoAssociado planoAssociado)
    {
        var planoAssociadoExistente = await ObterPorId(planoAssociado.Id);
        _context.Entry(planoAssociadoExistente!).CurrentValues.SetValues(planoAssociado);
        await _context.SaveChangesAsync();
        return planoAssociado;
    }

    public async Task Excluir(Guid id)
    {
        var planoAssociado = await ObterPorId(id);
        _context.PlanosAssociados.Remove(planoAssociado!);
        await _context.SaveChangesAsync();
    }

    public async Task<PlanoAssociado> Inserir(PlanoAssociado planoAssociado)
    {
        await _context.PlanosAssociados.AddAsync(planoAssociado);
        await _context.SaveChangesAsync();
        return planoAssociado;
    }

    public async Task<IEnumerable<PlanoAssociado>> Listar()
    {
        return await _context.PlanosAssociados
            .AsNoTracking()
            .Include(planoAssociado => planoAssociado.Associado)
            .Include(planoAssociado => planoAssociado.Plano)
            .ToListAsync();
    }

    public async Task<PlanoAssociado?> ObterPorId(Guid id)
    {
        return await _context.PlanosAssociados
            .AsNoTracking()
            .Include(planoAssociado => planoAssociado.Associado)
            .Include(planoAssociado => planoAssociado.Plano)
            .FirstOrDefaultAsync(planoAssociado => planoAssociado.Id.Equals(id));
    }
}
