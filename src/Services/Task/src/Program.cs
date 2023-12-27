using Microsoft.AspNetCore.Mvc;
using WebApi.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTask(builder.Configuration);

builder.Services
	.AddApiVersioning(options =>
	{
		options.ReportApiVersions = true;
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.DefaultApiVersion = new ApiVersion(1, 0);
	})
	.AddVersionedApiExplorer(options =>
	{
		options.GroupNameFormat = "'v'VVV";
		options.SubstituteApiVersionInUrl = true;
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
