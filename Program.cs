using Group1_5_FagelGamous.Data;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using PureTruthApi.Data.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("PureTruthDbConn");
builder.Services.AddDbContext<MummyContext>(x => x.UseNpgsql(connectionString));

builder.Services.AddAuthorization();

//region Repositories
builder.Services.AddScoped<IRepository<Analysis>, AnalysisRepository>();
builder.Services.AddScoped<IRepository<AnalysisTextile>, AnalysisTextileRepository>();
builder.Services.AddScoped<IRepository<Artifactfagelgamousregister>, ArtifactFagelgamousRegisterRepository>();
builder.Services.AddScoped<IRepository<ArtifactfagelgamousregisterBurialmain>, ArtifactFagelgamousRegisterBurialMainRepository>();
builder.Services.AddScoped<IRepository<Artifactkomaushimregister>, ArtifactKomaushimRegisterRepository>();
builder.Services.AddScoped<IRepository<ArtifactkomaushimregisterBurialmain>, ArtifactKomaushimRegisterBurialMainRepository>();
builder.Services.AddScoped<IRepository<Biological>, BiologicalRepository>();
builder.Services.AddScoped<IRepository<BiologicalC14>, BiologicalC14Repository>();
builder.Services.AddScoped<IRepository<Bodyanalysischart>, BodyAnalysisChartRepository>();
builder.Services.AddScoped<IRepository<Book>, BooksRepository>();
builder.Services.AddScoped<IRepository<Burialmain>, BurialMainRepository>();
builder.Services.AddScoped<IRepository<PhotodataTextile>, PhotoDataTextileRepository>();
builder.Services.AddScoped<IRepository<Photoform>, PhotoFormRepository>();
builder.Services.AddScoped<IRepository<Structure>, StructureRepository>();
builder.Services.AddScoped<IRepository<StructureTextile>, StructureTextileRepository>();
builder.Services.AddScoped<IRepository<Teammember>, TeamMemberRepository>();
builder.Services.AddScoped<IRepository<Textile>, TextileRepository>();
builder.Services.AddScoped<IRepository<Textilefunction>, TextileFunctionRepository>();
builder.Services.AddScoped<IRepository<TextilefunctionTextile>, TextileFunctionTextileRepository>();
builder.Services.AddScoped<IRepository<Yarnmanipulation>, YarnManipulationRepository>();
builder.Services.AddScoped<IRepository<YarnmanipulationTextile>, YarnManipulationTextileRepository>();
builder.Services.AddScoped<IRepository<BurialmainBiological>, BurialMainBiologicalRepository>();
builder.Services.AddScoped<IRepository<BurialmainBodyanalysischart>, BurialMainBodyAnalysisChartRepository>();
builder.Services.AddScoped<IRepository<BurialmainCranium>, BurialMainCraniumRepository>();
builder.Services.AddScoped<IRepository<BurialmainTextile>, BurialMainTextileRepository>();
builder.Services.AddScoped<IRepository<C14>, C14Repository>();
builder.Services.AddScoped<IRepository<Color>, ColorRepository>();
builder.Services.AddScoped<IRepository<ColorTextile>, ColorTextileRepository>();
builder.Services.AddScoped<IRepository<Cranium>, CraniumRepository>();
builder.Services.AddScoped<IRepository<Decoration>, DecorationRepository>();
builder.Services.AddScoped<IRepository<DecorationTextile>, DecorationTextileRepository>();
builder.Services.AddScoped<IRepository<Dimension>, DimensionRepository>();
builder.Services.AddScoped<IRepository<DimensionTextile>, DimensionTextileRepository>();
builder.Services.AddScoped<IRepository<Newsarticle>, NewsArticleRepository>();

//end region


//add the unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
