using ElmahCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddElmah();


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
    //app.UseDeveloperExceptionPage();
    //app.UseStatusCodePages(async context =>
    //{
    //    context.HttpContext.Response.ContentType = "text/plain";

    //    await context.HttpContext.Response.WriteAsync(
    //        "Error, status code: " +
    //        context.HttpContext.Response.StatusCode);
    //});

    //app.UseStatusCodePagesWithRedirects("/ErrorCode?code={0}");
    //app.UseStatusCodePagesWithReExecute("/ErrorCode", "?code={0}");

    //app.UseExceptionHandler("/error");

    app.UseElmah();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
