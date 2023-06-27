using Microsoft.EntityFrameworkCore;
using POC.SIGA.InformacoesCadastrais.Application;
using POC.SIGA.InformacoesCadastrais.Application.Services.Associados;
using POC.SIGA.InformacoesCadastrais.Application.Services.Mensalidades;
using POC.SIGA.InformacoesCadastrais.Application.Services.Planos;
using POC.SIGA.InformacoesCadastrais.Application.Services.PlanosAssociados;
using POC.SIGA.InformacoesCadastrais.Data.Contexts;
using POC.SIGA.InformacoesCadastrais.Data.Repositories;
using POC.SIGA.InformacoesCadastrais.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("informacoes_cadastrais_db"),
    ServiceLifetime.Singleton
);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IInformacoesCadastraisService, InformacoesCadastraisService>();
builder.Services.AddTransient<IAssociadoService, AssociadoService>();
builder.Services.AddTransient<IAssociadoRepository, AssociadoRepository>();
builder.Services.AddTransient<IPlanoService, PlanoService>();
builder.Services.AddTransient<IPlanoRepository, PlanoRepository>();
builder.Services.AddTransient<IPlanoAssociadoService, PlanoAssociadoService>();
builder.Services.AddTransient<IPlanoAssociadoRepository, PlanoAssociadoRepository>();
builder.Services.AddTransient<IMensalidadeService, MensalidadeService>();
builder.Services.AddTransient<IMensalidadeRepository, MensalidadeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
