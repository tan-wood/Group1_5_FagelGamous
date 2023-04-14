using Group1_5_FagelGamous.Data;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Group1_5_FagelGamous.Data.UnitOfWork;
using System.Text;
using System.Security.Principal;
using Group1_5_FagelGamous.Infrastructure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = Environment.GetEnvironmentVariable("DB_CONN");
 

builder.Services.AddDbContext<MummyContext>(x => x.UseNpgsql(connectionString!));

builder.Services.AddAuthorization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

//region Repositories
builder.Services.AddScoped<IRepository<Analysis>, AnalysisRepository>();
builder.Services.AddScoped<IRepository<Burialmain>, BurialMainRepository>();
builder.Services.AddScoped<IRepository<Photoform>, PhotoFormRepository>();
builder.Services.AddScoped<IRepository<Structure>, StructureRepository>();
builder.Services.AddScoped<IRepository<Teammember>, TeamMemberRepository>();
builder.Services.AddScoped<IRepository<Textile>, TextileRepository>();
builder.Services.AddScoped<IRepository<Textilefunction>, TextileFunctionRepository>();
builder.Services.AddScoped<IRepository<Yarnmanipulation>, YarnManipulationRepository>();
builder.Services.AddScoped<IRepository<Color>, ColorRepository>();
builder.Services.AddScoped<IRepository<Decoration>, DecorationRepository>();
builder.Services.AddScoped<IRepository<Dimension>, DimensionRepository>();

//end region


//add the unit of work

builder.Services.AddCors();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
//if its development, accept requests from local host
if(app.Environment.IsDevelopment())
{
    //app.UseCors(x => x.WithOrigins("http://localhost:3000"));
    app.UseCors(x => x.WithOrigins("*"));
}
//else, accept them from the real website
else
{
    //app.UseCors(x => x.WithOrigins("https://group1-5intexfrontendreactforreal.is404.net"));
    app.UseCors(x => x.WithOrigins("*"));
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
