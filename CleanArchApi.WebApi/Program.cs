using System.Text.Json.Serialization;
using CleanArchApi.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddService();
    builder.Services.AddAutoMapper();
    builder.Services.AddMediatR();
    builder.Services.AddAuth(builder.Configuration);

    builder.Services.AddMvc().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwagger();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseDataBaseConfiguration();

    app.UseHttpsRedirection();

    app.UseAuth();

    app.MapControllers();

    app.Run();
}