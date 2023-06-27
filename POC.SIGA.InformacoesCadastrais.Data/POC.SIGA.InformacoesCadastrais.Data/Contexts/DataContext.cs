using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Domain.Entities;

namespace POC.SIGA.InformacoesCadastrais.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Associado> Associados { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<PlanoAssociado> PlanosAssociados { get; set; }
    public DbSet<Mensalidade> Mensalidades { get; set; }
}
