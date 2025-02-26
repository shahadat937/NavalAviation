using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SchoolManagement.Api.Extensions;
using SchoolManagement.Api.Middleware;
using SchoolManagement.Application;
using SchoolManagement.Identity;
using SchoolManagement.Persistence;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// add service to container

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(o =>
{
  o.AddPolicy("CorsPolicy",
      builder => builder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());
});

// configure the http request pipeline
var app = builder.Build();
//if (env.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.Use(async (context, next) =>
//{
//  context.Response.Headers.Add("Content-Security-Policy",
//      "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self'; font-src 'self';");
//  await next();
//});

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseSwaggerDocumention();


app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//                 Path.Combine(Directory.GetCurrentDirectory(), "Content")
//             ),
//    RequestPath = "/content"
//});
//app.MapFallbackToController("Index", "Fallback");
app.UseAuthorization();

app.Use(async (context, next) =>
{
  context.Response.Headers.Add("Content-Security-Policy",
      "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; frame-src 'self' ; object-src 'none';");
  await next();
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();



