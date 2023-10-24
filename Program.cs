var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "The program is working");

//app.UseMiddleware<RandomNumberMiddleware>();

app.MapGet("/company-info", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    // Створення об'єкта компанії та ініціалізація даних
    Company company = new Company
    (
        1,
        "Mercedes-Benz",
        "Automotive",
        12000,
        86540000000
    );

    var stringBuilder = new System.Text.StringBuilder("<h3>Інформація про компанію</h3><table>");

    stringBuilder.Append("<tr><td>Параметр</td><td>Значення</td></tr>");
    
    // Додавання рядків таблиці з даними про компанію
    stringBuilder.Append($"<tr><td>ID</td><td>{company.Id}</td></tr>");
    stringBuilder.Append($"<tr><td>Назва</td><td>{company.Name}</td></tr>");
    stringBuilder.Append($"<tr><td>Галузь</td><td>{company.Industry}</td></tr>");
    stringBuilder.Append($"<tr><td>Кількість співробітників</td><td>{company.NumOfEmployees}</td></tr>");
    stringBuilder.Append($"<tr><td>Капіталізація</td><td>{company.GetCapitalization()}</td></tr>");

    stringBuilder.Append("</table>");

    await context.Response.WriteAsync(stringBuilder.ToString());
});

app.MapGet("/get-rand", () =>
{
    var random = new Random();
    var randNum = random.Next(101);

    return $"Random number: {randNum}";
});

app.Run();


// Клас який генерує випадкове число
public class RandomNumberMiddleware
{
    readonly RequestDelegate next;

    public RandomNumberMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var random = new Random();
        var randNum = random.Next(101);

        await context.Response.WriteAsync($"Random Number: {randNum}");
    }
}