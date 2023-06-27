using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Data.Contexts;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Data.Repositories;

public class PlanoRepository : IPlanoRepository
{
    private readonly DataContext _context;

    public PlanoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Plano> Atualizar(Plano plano)
    {
        var planoExistente = await ObterPorId(plano.Id);
        _context.Entry(planoExistente!).CurrentValues.SetValues(plano);
        await _context.SaveChangesAsync();
        return plano;
    }

    public async Task Excluir(Guid id)
    {
        var plano = await ObterPorId(id);
        _context.Planos.Remove(plano!);
        await _context.SaveChangesAsync();
    }

    public async Task<Plano> Inserir(Plano plano)
    {
        plano.Id = Guid.NewGuid();
        await _context.Planos.AddAsync(plano);
        await _context.SaveChangesAsync();
        return plano;
    }

    public async Task<IEnumerable<Plano>> Listar()
    {
        return await _context.Planos.AsNoTracking().ToListAsync();
    }

    public async Task<Plano?> ObterPorId(Guid id)
    {
        return await _context.Planos.FindAsync(id);
    }
}
