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
    public class ActorService
    {
        private readonly MovieContext _dbContext;

        public ActorService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Actor> ActorAsync(string actorId)
        {
            var query = @"
                SELECT nconst, primaryname, birthyear, deathyear, primaryprofession
                FROM name_basics
                WHERE nconst = @actorId";
            return await _dbContext.Set<Actor>()
                .FromSqlRaw(query, new NpgsqlParameter("@actorId", actorId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Actor>> MovieActorsAsync(string movieId)
        {
            var query = @"
                SELECT nb.nconst, nb.primaryname, nb.birthyear, nb.deathyear, nb.primaryprofession
                FROM title_principals tp
                JOIN name_basics nb ON tp.nconst = nb.nconst
                WHERE tp.tconst = @movieId";
            return await _dbContext.Set<Actor>()
                .FromSqlRaw(query, new NpgsqlParameter("@movieId", movieId))
                .ToListAsync();
        }
    }

}
