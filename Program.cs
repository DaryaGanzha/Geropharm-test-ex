using Geopharm_testttt.Data;
using Geopharm_testttt.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});
var app = builder.Build();


// заполнение таблицы тестовыми данными
using (var context = new ApplicationContext())
{
    context.Database.EnsureCreated();
    if (!context.Boxes.Any())
    {
        var boxes = new Box[100];
        for (int i = 0; i < 100; i++)
        {
            string charsBig = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            int length = random.Next(3, 6);
            string firstLetter = new string(Enumerable.Repeat(charsBig, 1)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
            string str = firstLetter + new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
            var box = new Box { title = str };
            boxes.SetValue(box, i);
        }
        context.Boxes.AddRange(boxes);
        context.SaveChanges();
    };
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();




