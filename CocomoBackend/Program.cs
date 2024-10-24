using Prospection.Services.Handlers;
using ProspectionConfig;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.Data;
using CocomoBackend.Mappings;
using CocomoBackend.Services;
using CocomoBackend.Services.interfaces;
using CocomoBackend.Services.implementation;

var builder = WebApplication.CreateBuilder(args);
var serviceProvider = builder.Services.BuildServiceProvider();

//ProspectionData.ConnStr = builder.Configuration.GetConnectionString("dbConnection");
//Config.ConfigureInjection(builder, ProspectionData.ConnStr);

// Configurar CORS
//builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
//{
//    builder.AllowAnyOrigin();
//    builder.AllowAnyMethod();
//    builder.AllowAnyHeader();
//}));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Permite cualquier URL/origen
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("x-pagination"); // Expone el encabezado x-pagination
    });
    options.AddDefaultPolicy(builder =>
    {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("x-pagination"); // Expone el encabezado x-pagination
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add DbContext and configure services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Mappings - Instancia para Automaping
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Mapeo por Servicio
builder.Services.AddScoped<ICocomoHeadService, CocomoHeadService>();
builder.Services.AddScoped<ICocomoVersionServices, CocomoVersionService>();
builder.Services.AddScoped<ICocomoDetailService, CocomoDetailService>();

builder.Services.AddScoped<ICocomoService, CocomoService>();


builder.Services.AddScoped<ICocomoStateService, CocomoStateService>();
builder.Services.AddScoped<ICocomoStateVersionService, CocomoStateVersionService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPlatformObjectTimeService, PlatformObjectTimeService>();
builder.Services.AddScoped<IVerticalService, VerticalService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<ITypeComplexityService, TypeComplexityService>();
builder.Services.AddScoped<ITypeRequerimentService, TypeRequerimentService>();
builder.Services.AddScoped<ITypeProyectService, TypeProyectService>();
builder.Services.AddScoped<ITypeFactorService, TypeFactorService>();
builder.Services.AddScoped<ITypeFactorDetailService, TypeFactorDetailService>();



var app = builder.Build();
//Config.ConfigureRoutes(app);

//// Call SeedData method to seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        //context.Database.Migrate(); // Ensure the database is created and migrations are applied
        context.SeedData(); // Call the seed data method
    }
    catch (Exception ex)
    {
        // Handle exceptions
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "prospection.api");
        c.RoutePrefix = string.Empty;
    });
}


//app.UseCors();
app.UseCors("AllowAllOrigins"); 
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();