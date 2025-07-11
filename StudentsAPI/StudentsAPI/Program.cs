using StudentsAPI.Data.Extensions;
using StudentsAPI.Application.Extensions;

internal class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.ResolveDataDependencies();
        builder.Services.ResolveApplicationDependencies();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}