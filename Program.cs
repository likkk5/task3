var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/lishykksu_gmail_com", (HttpRequest request) =>
{
    string xStr = request.Query["x"];
    string yStr = request.Query["y"];

    if (!long.TryParse(xStr, out long x) || !long.TryParse(yStr, out long y))
        return Results.Text("NaN", "text/plain");

    if (x < 0 || y < 0)
        return Results.Text("NaN", "text/plain");

    long result = (x == 0 || y == 0) ? 0 : (x / Gcd(x, y)) * y;

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