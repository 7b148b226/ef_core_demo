using ef_core_7_with_.net_7.BLL;
using ef_core_7_with_.net_7.DAL;
using ef_core_7_with_.net_7.Extensions;
using ef_core_7_with_.net_7.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

builder.RegisterSerilog();

services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));
services.AddTransient<InfoService>();
services.AddTransient<TestInfoService>();
services.AddTransient<RootService>();
services.AddTransient<TestRootService>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var count = 1000;

app.MapPost("/api/tests/single-insert", async (TestInfoService x) => await x.SingleInsert());
app.MapPost("/api/tests/multiple-insert", async (TestInfoService x) => await x.MultipleInsert(count));
app.MapPost("/api/tests/bulk-insert", async (TestInfoService x) => await x.BulkInsert(count));


app.MapPut("/api/tests/single-update/{id:guid}", async (TestInfoService x, Guid id) => await x.SingleUpdate(id));
app.MapPut("/api/tests/single-execute-update/{id:guid}", async (TestInfoService x, Guid id) => await x.SingleExecuteUpdate(id));

app.MapPut("/api/tests/multiple-update", async (TestInfoService x) => await x.MultipleUpdate(count));
app.MapPut("/api/tests/multiple-execute-update", async (TestInfoService x) => await x.MultipleExecuteUpdate(count));


app.MapDelete("/api/tests/single-delete/{id:guid}", async (TestInfoService x, Guid id) => await x.SingleDelete(id));
app.MapDelete("/api/tests/single-execute-delete/{id:guid}", async (TestInfoService x, Guid id) => await x.SingleExecuteDelete(id));

app.MapDelete("/api/tests/multiple-delete", async (TestInfoService x) => await x.MultipleDelete(count));
app.MapDelete("/api/tests/multiple-execute-delete", async (TestInfoService x) => await x.MultipleExecuteDelete(count));


app.MapGet("/api/tests/single-query/{id:guid}", async (TestInfoService x, Guid id) => await x.SingleQuery(id));
app.MapGet("/api/tests/multiple-query", async (TestInfoService x) => await x.MultipleQuery(count));


app.MapPost("/api/tests/full-json-insert", async (TestRootService x) => await x.FullJsonInsert());
app.MapPost("/api/tests/full-conversion-insert", async (TestRootService x) => await x.FullConversionInsert());
app.MapPost("/api/tests/full-nvarchar-insert", async (TestRootService x) => await x.FullNvarcharInsert());

app.MapPut("/api/tests/full-json-update/{id:guid}", async (TestRootService x, Guid id) => await x.FullJsonUpdate(id));
app.MapPut("/api/tests/full-conversion-update/{id:guid}", async (TestRootService x, Guid id) => await x.FullConversionUpdate(id));
app.MapPut("/api/tests/full-nvarchar-update/{id:guid}", async (TestRootService x, Guid id) => await x.FullNvarcharUpdate(id));

app.MapGet("/api/tests/full-json-query/{id:guid}", async (TestRootService x, Guid id) => await x.FullJsonQuery(id));
app.MapGet("/api/tests/full-conversion-query/{id:guid}", async (TestRootService x, Guid id) => await x.FullConversionQuery(id));
app.MapGet("/api/tests/full-nvarchar-query/{id:guid}", async (TestRootService x, Guid id) => await x.FullNvarcharQuery(id));


app.MapPut("/api/tests/partial-json-update/{id:guid}", async (TestRootService x, Guid id) => await x.PartialJsonUpdate(id));
app.MapPut("/api/tests/partial-conversion-update/{id:guid}", async (TestRootService x, Guid id) => await x.PartialConversionUpdate(id));
app.MapPut("/api/tests/partial-nvarchar-update/{id:guid}", async (TestRootService x, Guid id) => await x.PartialNvarcharUpdate(id));

app.MapGet("/api/tests/partial-json-query/{id:guid}", async (TestRootService x, Guid id) => await x.PartialJsonQuery(id));
app.MapGet("/api/tests/partial-conversion-query/{id:guid}", async (TestRootService x, Guid id) => await x.PartialConversionQuery(id));
app.MapGet("/api/tests/partial-nvarchar-query/{id:guid}", async (TestRootService x, Guid id) => await x.PartialNvarcharQuery(id));

app.Run();
