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

        builder.Services.AddCors();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
                                                //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
            .AllowCredentials()); // allow credentials

        app.Run();
    }
}