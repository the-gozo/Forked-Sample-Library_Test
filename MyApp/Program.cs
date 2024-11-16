using Library.Components.StateMachines;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*** ONLY ADDED THIS CONFIGURATION ***  
builder.Services.AddMassTransit(x =>
{
    x.AddSagaStateMachine(typeof(ReservationStateMachine));
    x.AddPublishMessageScheduler();

    x.UsingInMemory((context, cfg) =>
    {
        cfg.UsePublishMessageScheduler();

        cfg.ConfigureEndpoints(context);
    });
});
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { };