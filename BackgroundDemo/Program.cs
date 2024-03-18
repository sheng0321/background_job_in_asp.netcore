using BackgroundDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add data.
builder.Services.AddSingleton<SampleData>();
//add background service.
builder.Services.AddHostedService<BackgroundRefresh>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//endpoint
app.MapGet("/message", (SampleData data) => data.Data.Order());

app.Run();


