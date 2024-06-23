using FullApp.Repository; // importação das dependências para injeção
using FullApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<IOrderService, OrderService>(); //  Injeção de Dependências, tempo de vida scoped
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddEndpointsApiExplorer(); // Mapeamento dos endpoints e documentação automática no Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => // Politicas de CORS para liberar qualquer cliente
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run(); // Executa a aplicação
