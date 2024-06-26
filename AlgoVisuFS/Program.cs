using AlgoVisuFSLogic.BudgetCalculatorService;
using AlgoVisuFSLogic.MazeSolver;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AlgoVisuFSSwagger",
        Version = "v1"
    });
});
builder.Services.AddTransient<IBudgetCalculatorService, BudgetCalculatorService>();
builder.Services.AddTransient<IDFSSolver, DFSSolver>();
builder.Services.AddTransient<IGreedyDFSSolver, GreedyDFSSolver>();


builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = builder.Configuration.GetValue<int>("HttpsRedirectionOptions:RedirectStatusCode", 307);
    options.HttpsPort = builder.Configuration.GetValue<int?>("HttpsRedirectionOptions:HttpsPort");
});

var app = builder.Build();


app.UseCors("AllowSpecificOrigin");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlgoVisuFS V1");
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
