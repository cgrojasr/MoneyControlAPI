using System.Text;
using CR.MoneyControl.BusinessLogic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Esto es para leer los controladores desde la carpeta Controllers
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Clase de UPC 21/09/2024 **LECTURA DE LA CADENA DE CONEXIÓN**
// Agregar el acceso a las configuraciones y la cadena de conexión
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Configurar dependencias del repositorio
builder.Services.AddScoped<MetaBL>();
builder.Services.AddScoped<MedioFinancieroBL>();

//JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options => {
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]??string.Empty)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS para que la web pueda consumir los servicios
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}); 

//CORS
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); //Mapear los controlares dentro de la carpeta Controllers

app.Run();
