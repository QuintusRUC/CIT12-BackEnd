using Microsoft.EntityFrameworkCore;
using MovieApp.BusinessLayer;
using MovieApp.BusinessLayer.Services;
using MovieApp.DataLayer;
using MovieApp.DataLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Allow this specific origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting();


// Register MovieContext
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDatabase")));

// Register BookmarkService
builder.Services.AddScoped<BookmarkService>();

// Register UserService
builder.Services.AddTransient<UserService>();

// Bookmark
builder.Services.AddScoped<BookmarkBusinessService>();
builder.Services.AddScoped<UserBusinessService>();

//User
builder.Services.AddScoped<UserRatingBusinessService>();
builder.Services.AddScoped<UserRatingService>();

//SearchHistory
builder.Services.AddScoped<SearchHistoryBusinessService>();
builder.Services.AddScoped<SearchHistoryService>();

// BestMatch
builder.Services.AddScoped<BestMatchService>();
builder.Services.AddScoped<BestMatchBusinessService>();

//NameRating
builder.Services.AddScoped<NameRatingService>();
builder.Services.AddScoped<NameRatingBusinessService>();

//RatingsForMovie
builder.Services.AddScoped<RatingsForMovieService>();
builder.Services.AddScoped<RatingsForMovieBusinessService>();

//ExactMatch
builder.Services.AddScoped<ExactMatchService>();
builder.Services.AddScoped<ExactMatchBusinessService>();

//FindCoPlayers
builder.Services.AddScoped<FindCoplayersService>();
builder.Services.AddScoped<FindCoplayersBusinessService>();
//GetBookmarkDB
builder.Services.AddScoped<GetBookmarksDbService>();
builder.Services.AddScoped<GetBookmarksDbBusinessService>();
//GetSearchHistory
builder.Services.AddScoped<GetSearchHistoryDbService>();
builder.Services.AddScoped<GetSearchHistoryDbBusinessService>();

//PersonWords
builder.Services.AddScoped<PersonWordsDbService>();
builder.Services.AddScoped<PersonWordsDbBusinessService>();

//Rate
builder.Services.AddScoped<RateDbService>();
builder.Services.AddScoped<RateDbBusinessService>();

//SimilarMoviesDbService
builder.Services.AddScoped<SimilarMoviesDbService>();
builder.Services.AddScoped<SimilarMoviesDbBusinessService>();

//StringSearch
builder.Services.AddScoped<StringSearchDbService>();
builder.Services.AddScoped<StringSearchDbBusinessService>();

//StructuredStringSearch
builder.Services.AddScoped<StructuredStringSearchService>();
builder.Services.AddScoped<StructuredStringSearchBusinessService>();

//WordToWord
builder.Services.AddScoped<WordToWordService>();
builder.Services.AddScoped<WordToWordBusinessService>();

//GetMovieActor
builder.Services.AddScoped<GetMovieActorService>();
builder.Services.AddScoped<GetMovieActorBusinessService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost3000");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
