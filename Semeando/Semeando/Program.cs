using Microsoft.EntityFrameworkCore;
using Semeando.Application.Interfaces;
using Semeando.Application.Services;
using Semeando.Domain.Interfaces;
using Semeando.Infrastructure.Data.AppData;
using Semeando.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllersWithViews();

// Configuração do DbContext com o Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = @"
        Data Source=(DESCRIPTION=
            (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))
            (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL))
        );
        User Id=rm553640;
        Password=280298;";
    options.UseOracle(connectionString);
});

// Registrar repositórios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IPerguntaRepository, PerguntaRepository>();
builder.Services.AddScoped<IOpcaoRepository, OpcaoRepository>();
builder.Services.AddScoped<IRespostaRepository, RespostaRepository>();

// Registrar serviços de aplicação
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
builder.Services.AddScoped<ILevelApplicationService, LevelApplicationService>();
builder.Services.AddScoped<IPerguntaApplicationService, PerguntaApplicationService>();
builder.Services.AddScoped<IOpcaoApplicationService, OpcaoApplicationService>();
builder.Services.AddScoped<IRespostaApplicationService, RespostaApplicationService>();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuração das rotas
app.UseEndpoints(endpoints =>
{
    // Rota para o controller de Usuário
    endpoints.MapControllerRoute(
        name: "usuario",
        pattern: "usuario/{action=CadastroUsuario}/{id?}",
        defaults: new { controller = "Usuario" });

    // Rota para o controller de Level
    endpoints.MapControllerRoute(
        name: "level",
        pattern: "level/{action=CadastroLevel}/{id?}",
        defaults: new { controller = "Level" });

    // Rota para o controller de Pergunta
    endpoints.MapControllerRoute(
        name: "pergunta",
        pattern: "pergunta/{action=CadastroPergunta}/{id?}",
        defaults: new { controller = "Pergunta" });

    // Rota para o controller de Opção
    endpoints.MapControllerRoute(
        name: "opcao",
        pattern: "opcao/{action=CadastroOpcao}/{id?}",
        defaults: new { controller = "Opcao" });

    // Rota para o controller de Resposta
    endpoints.MapControllerRoute(
        name: "resposta",
        pattern: "resposta/{action=CadastroResposta}/{id?}",
        defaults: new { controller = "Resposta" });

    // Rota padrão (HomeController)
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Adiciona mapeamento de controllers padrão
    endpoints.MapControllers();
});

app.Run();