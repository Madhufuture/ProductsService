using ProductsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


app.MapGet("/Products", () =>
{
    var products = Enumerable.Range(1, 5).Select(x => new Products
    {
        Price = new Random().NextDouble().ToString(),
        Product = string.Concat("Product", new Random().Next(2, 20)),
        ProductId = Guid.NewGuid().ToString()
    }).ToArray();
    return products;

}).WithName("GetProducts");


app.Run();
