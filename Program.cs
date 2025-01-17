using LorenzoApplication;
using LorenzoApplication.Modelos;
using LorenzoApplication.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ArticulosContexto>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Lorenzo")));
builder.Services.AddDbContext<ClientesContexto>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Lorenzo")));
builder.Services.AddDbContext<ProveedoresContexto>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Lorenzo")));


builder.Services.AddScoped<IArticulosServicio, ArticulosServicio>();
builder.Services.AddScoped<IClientesServicio, ClientesServicio>();
builder.Services.AddScoped<IProveedoresServicio, ProveedoresServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
