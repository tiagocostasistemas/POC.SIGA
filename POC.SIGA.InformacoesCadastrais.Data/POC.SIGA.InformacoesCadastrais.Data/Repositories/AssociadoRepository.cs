using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Data.Contexts;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

namespace POC.SIGA.InformacoesCadastrais.Data.Repositories;

public class AssociadoRepository : IAssociadoRepository
{
    private readonly DataContext _context;

    public AssociadoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Associado> Atualizar(Associado associado)
    {
        var associadoExistente = await ObterPorId(associado.Id);
        _context.Entry(associadoExistente!).CurrentValues.SetValues(associado);
        await _context.SaveChangesAsync();
        return associado;
    }

    public async Task Excluir(Guid id)
    {
        var associado = await ObterPorId(id);
        _context.Associados.Remove(associado!);
        await _context.SaveChangesAsync();
    }

    public async Task<Associado> Inserir(Associado associado)
    {
        associado.Id = Guid.NewGuid();
        await _context.Associados.AddAsync(associado);
        await _context.SaveChangesAsync();
        return associado;
    }

    public async Task<IEnumerable<Associado>> Listar()
    {
        var associados = await _context.Associados.ToListAsync();
        associados.ForEach(associado => associado.FaixaEtaria = ObterFaixaEtaria(associado.Idade));
        return associados;
    }

    public async Task<Associado?> ObterPorId(Guid id)
    {
        var associado = await _context.Associados.FindAsync(id);
        associado!.FaixaEtaria = ObterFaixaEtaria(associado.Idade);
        return associado;
    }

    private FaixaEtaria ObterFaixaEtaria(int idade)
    {
        var faixas = ListarFaixasEtarias();
        var faixa = faixas.Where(faixa => (idade >= faixa.IdadeInicial && idade <= faixa.IdadeFinal)).FirstOrDefault();
        return faixa!;

    }
    private IEnumerable<FaixaEtaria> ListarFaixasEtarias()
    {
        var faixas = new List<FaixaEtaria> 
        {
            new FaixaEtaria 
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 0,
                IdadeFinal = 8,
                PercentualAcrescimo = 1,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 9,
                IdadeFinal = 15,
                PercentualAcrescimo = 3,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 16,
                IdadeFinal = 25,
                PercentualAcrescimo = 5,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 26,
                IdadeFinal = 40,
                PercentualAcrescimo = 7,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 41,
                IdadeFinal = 60,
                PercentualAcrescimo = 10,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 61,
                IdadeFinal = 80,
                PercentualAcrescimo = 12,
            },
            new FaixaEtaria
            {
                Id = Guid.NewGuid(),
                IdadeInicial = 81,
                IdadeFinal = 100,
                PercentualAcrescimo = 15,
            },
        };
        return faixas;
    }
}
