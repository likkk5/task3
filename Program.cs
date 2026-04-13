using System.Numerics;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/lishykksu_gmail_com", (HttpRequest request) =>
{
    string xStr = request.Query["x"];
    string yStr = request.Query["y"];

    if (!BigInteger.TryParse(xStr, out BigInteger x) || !BigInteger.TryParse(yStr, out BigInteger y))
        return Results.Text("NaN", "text/plain");

    if (x < 0 || y < 0)
        return Results.Text("NaN", "text/plain");

    if (x == 0 || y == 0)
        return Results.Text("0", "text/plain");

    BigInteger gcd = Gcd(x, y);
    BigInteger lcm = (x / gcd) * y;

    return Results.Text(lcm.ToString(), "text/plain");
});

BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        BigInteger t = b;
        b = a % b;
        a = t;
    }
    return a;
}
app.Run();