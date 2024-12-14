using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace MovieApp.DataLayer.Services
{
    public class GetMovieActorService
    {
        private readonly MovieContext _dbContext;

        public GetMovieActorService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MovieActorResult>> GetMovieActorsAsync(string movieId)
        {
            var query = @"
                SELECT nb.nconst, nb.primaryname, nb.birthyear, nb.deathyear, nb.primaryprofession
                FROM title_principals tp
                JOIN name_basics nb ON tp.nconst = nb.nconst
                WHERE tp.tconst = @movieId";
            return await _dbContext.Set<MovieActorResult>()
                .FromSqlRaw(query, new NpgsqlParameter("@movieId", movieId))
                .ToListAsync();
        }
    }

    public class MovieActorResult
    {
        public string nconst { get; set; }
        public string primaryname { get; set; }
        public string birthyear { get; set; }
        public string deathyear { get; set; }
        public string primaryprofession { get; set; }
    }
}