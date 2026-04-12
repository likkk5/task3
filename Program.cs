var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


app.MapGet("/lishykksu_gmail_com", (HttpRequest request) => 
{
    string xStr = request.Query["x"];
    string yStr = request.Query["y"];

    if (!long.TryParse(xStr, out long x) || !long.TryParse(yStr, out long y))
        return Results.Text("NaN", "text/plain");

    if (x < 0 || y < 0)
        return Results.Text("NaN", "text/plain");

    long result;

    if (x == 0 || y == 0)
        result = 0;
    else
        result = (x / Gcd(x, y)) * y;

    return Results.Text(result.ToString(), "text/plain");
});

long Gcd(long a, long b)
{
    while (b != 0)
    {
        long t = b;
        b = a % b;
        a = t;
    }
    return a;
}

app.Run();