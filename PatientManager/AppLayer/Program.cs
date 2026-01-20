using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PMContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});


builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<DiagnosisService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<MedicationService>();
builder.Services.AddScoped<PrescriptionService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<PaymentService>();


builder.Services.AddScoped(typeof(DAL.Interfaces.IRepository<>), typeof(DAL.Repos.Repository<>));

builder.Services.AddScoped<DataAccessFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
