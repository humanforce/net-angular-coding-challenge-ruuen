using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Setup repository injection
builder.Services.AddScoped<ISprintRepository, MockSprintRepository>();
builder.Services.AddScoped<ITicketRepository, MockTicketRepository>();

// Configure CORS for dev (or prod in future)
string devOriginPolicy = "AllowClientDevServerOrigin";
string devClientOrigin = "http://localhost:4200";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devOriginPolicy, policy =>
    {
        policy.WithOrigins(devClientOrigin);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(devOriginPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
