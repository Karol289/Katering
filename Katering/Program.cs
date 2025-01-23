using Katering;
using Katering.Components;
using Katering.Entities;
using Katering.Data.Service;
using Microsoft.EntityFrameworkCore;
using Katering.Data.SessionState;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<KateringDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<Katering.Data.SessionState.SessionState>();

builder.Services.AddScoped<SessionState>();

// Rejestrowanie UserService
builder.Services.AddScoped<Katering.Data.Service.UserService>();  


// Rejestracja RegistrationService
builder.Services.AddSingleton<RegistrationService>();

builder.Services.AddScoped<RaportService>();

// Klient HTTP do API raportow
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



app.Run();
