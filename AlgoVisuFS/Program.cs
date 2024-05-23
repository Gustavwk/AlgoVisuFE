using HvorFuckedErJeg2Logic.BudgetCalculatorService;
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
        Title = "HvorFuckedErJegSwagger",
        Version = "v1"
    });
});
builder.Services.AddTransient<IBudgetCalculatorService, BudgetCalculatorService>();


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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HvorFuckedErJeg V1");
    });

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
