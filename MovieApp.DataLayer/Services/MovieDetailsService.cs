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
    public class MovieDetailsService
    {
        private readonly MovieContext _dbContext;

        public MovieDetailsService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieDetails> MovieDetailsAsync(string movieId)
        {
            var query = @"
                SELECT tconst, primarytitle, originaltitle, isadult, startyear, endyear, runtimeminutes, genres
                FROM title_basics
                WHERE tconst = @movieId";
            return await _dbContext.Set<MovieDetails>()
                .FromSqlRaw(query, new NpgsqlParameter("@movieId", movieId))
                .FirstOrDefaultAsync();
        }
    }

}
