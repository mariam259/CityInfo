using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}
).AddNewtonsoftJson().
AddXmlDataContractSerializerFormatters();

//add new attribute for http error response body called additionalInfo
/*builder.Services.AddProblemDetails(options =>
 options.CustomizeProblemDetails = ctx =>
 {
     ctx.ProblemDetails.Extensions.Add("additionalInfo", "Additional Info Example");
     //add new attribute for http error response body called server which return server name
     ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName);
 }

);
*/

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
