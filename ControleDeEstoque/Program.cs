using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Application.Services;
using ControleDeEstoque.Domain.Data;
using ControleDeEstoque.Domain.Repository;
using ControleDeEstoque.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<IMotivosRepository, MotivosRepository>();
builder.Services.AddScoped<IMotivosServices, MotivosServices>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}")
    .WithStaticAssets();
app.UseStaticFiles();

app.Run();
