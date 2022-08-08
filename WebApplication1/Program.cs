var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EducationalMaterialContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MaterialsConnectionString")));
builder.Services.AddScoped<MaterialSeeder>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    MaterialSeeder seeder = scope.ServiceProvider.GetRequiredService<MaterialSeeder>();
    seeder.Seed();
}


app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.Run();
