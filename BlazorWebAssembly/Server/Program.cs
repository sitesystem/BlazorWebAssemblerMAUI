using BlazorWebAssembly.Server.CapaDataAccess.DBContext;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Habilitar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "serverWS", Version = "v1" });
});

// Inyecci�n de Dependencia
builder.Services.AddDbContext<DbBlazorMauiContext>();

// Servicios CORS
string? cors = "_cors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        builder =>
        {
            builder.WithHeaders("*"); // POST
            builder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); // GET
            builder.WithMethods("*"); // PUT DELETE
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "serverWS v1"));

app.MapGet("/people", () =>
{
    using (var context = new DbBlazorMauiContext())
    {
        return context.TbPersonas.ToList();
    }
});

app.MapGet("/peopleInject", async (DbBlazorMauiContext context) =>
    await context.TbPersonas.ToListAsync()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(cors);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
