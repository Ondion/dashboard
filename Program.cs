using FullApp.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://gray-sky-087fbdc0f.5.azurestaticapps.net/")
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


app.Run();
