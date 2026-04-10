using BackendAPI.Data;
using BackendAPI.Services; 
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI (keep this)
builder.Services.AddOpenApi();

// Swagger configuration (keep this)
builder.Services.AddSwaggerGen(c =>
{
    var xmlPath = Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
    else
    {
        Console.WriteLine($"Warning: XML documentation file not found at {xmlPath}");
    }
});

// Database (keep this)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Existing service (keep this)
builder.Services.AddScoped<IEmailService, EmailService>();

// 🔥 ADD YOUR YOUTUBE SERVICE HERE
builder.Services.AddScoped<IYouTubeService, YoutubeService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();