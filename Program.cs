using bagit_api.Hubs;
var builder = WebApplication.CreateBuilder(args);
var AllowOrigins = "_allowOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigins,
                      builder => builder
                        .WithOrigins("http://127.0.0.1:5500")
                        .AllowAnyHeader()
                        .AllowAnyMethod() 
                        .AllowCredentials()
                      );
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(AllowOrigins);

app.UseAuthorization();

app.MapControllers();
app.MapHub<ListHub>("/listHub");

app.Run();
