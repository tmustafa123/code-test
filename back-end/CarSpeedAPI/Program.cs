using CarSpeedAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Ensure a file path is provided as a command-line argument
if (args.Length == 0)
{
    Console.WriteLine("Please provide the path to the input JSON file as a command-line argument.");
    return;
}

string filePath = args[0];

// Register the CarSpeedService with the file path
builder.Services.AddSingleton<ICarSpeedService>(_ => new CarSpeedService(filePath));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
