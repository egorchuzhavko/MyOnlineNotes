using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.Application.Services;
using MyOnlineNotes.DataAccess;
using MyOnlineNotes.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyOnlineNotesDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MyOnlineNotesDbContext)));
});

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => {
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:5173");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
