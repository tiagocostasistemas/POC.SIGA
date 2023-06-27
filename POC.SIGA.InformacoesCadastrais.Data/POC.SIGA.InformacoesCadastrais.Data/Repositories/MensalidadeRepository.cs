using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Data.Contexts;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Data.Repositories;

public class MensalidadeRepository : IMensalidadeRepository
{
    private readonly DataContext _context;

    public MensalidadeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Mensalidade> Atualizar(Mensalidade Mensalidade)
    {
        var MensalidadeExistente = await ObterPorId(Mensalidade.Id);
        _context.Entry(MensalidadeExistente!).CurrentValues.SetValues(Mensalidade);
        await _context.SaveChangesAsync();
        return Mensalidade;
    }

    public async Task Excluir(Guid id)
    {
        var Mensalidade = await ObterPorId(id);
        _context.Mensalidades.Remove(Mensalidade!);
        await _context.SaveChangesAsync();
    }

    public async Task<Mensalidade> Inserir(Mensalidade Mensalidade)
    {
        await _context.Mensalidades.AddAsync(Mensalidade);
        await _context.SaveChangesAsync();
        return Mensalidade;
    }

    public async Task<IEnumerable<Mensalidade>> Listar()
    {
        return await _context.Mensalidades
            .AsNoTracking()
            .Include(Mensalidade => Mensalidade.PlanoAssociado!.Associado)
            .Include(Mensalidade => Mensalidade.PlanoAssociado!.Plano)
            .ToListAsync();
    }

    public async Task<Mensalidade?> ObterPorId(Guid id)
    {
        return await _context.Mensalidades
            .AsNoTracking()
            .Include(Mensalidade => Mensalidade.PlanoAssociado!.Associado)
            .Include(Mensalidade => Mensalidade.PlanoAssociado!.Plano)
            .FirstOrDefaultAsync(Mensalidade => Mensalidade.Id.Equals(id));
    }
}
