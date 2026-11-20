using TaskFlow.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IGuidProvider, GuidProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TaskFlow API v1");
    });
}
app.Use(async (context, next) =>
{
    Console.WriteLine($"-> {context.Request.Method},{context.Request.Path}");
    await next();
    Console.WriteLine($"<-{context.Response.StatusCode}");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
