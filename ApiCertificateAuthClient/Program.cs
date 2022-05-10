using ApiCertificateAuthClient;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
  
var clientCertificate =  new X509Certificate2(Path.Combine(builder.Environment.ContentRootPath, "ApiCertificateAuthClient.pfx"), "Client123456");

builder.Services.AddHttpClient("namedClient", c => { }).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();
    handler.ClientCertificates.Add(clientCertificate);
    return handler;
});


// Add services to the container.
builder.Services.AddTransient<IClientHttpService, ClientHttpService>();

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
