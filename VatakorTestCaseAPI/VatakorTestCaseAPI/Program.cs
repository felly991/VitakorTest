using MassTransit;
using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Service.Connection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//����������� � ��
builder.Services.AddDbContext<DataContext>(op =>
{
    // ����� ��������� ����������� � ��
    op.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
ConnectionService.ConnectService(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//����������� ������
app.UseCors(op => op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
