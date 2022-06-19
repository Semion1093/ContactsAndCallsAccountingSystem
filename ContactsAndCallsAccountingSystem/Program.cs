using ContactsAndCallsAccountingSystem.API;
using ContactsAndCallsAccountingSystem.AutoMapperConfiguration;
using ContactsAndCallsAccountingSystem.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactsAndCallsAccountingSystemContext>(op
    => op.UseSqlServer("Server=SIMO\\SQLEXPRESS;Database=ContactsAndCalls.DB;Trusted_Connection=True")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(APIMapper).Assembly, typeof(DALMapper).Assembly);
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSwaggerGen(s => s.EnableAnnotations());
builder.Services.AddSingleton<IContextFactory, ContextFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ContactsAndCallsAccountingSystemMiddleware>();

app.Run();
