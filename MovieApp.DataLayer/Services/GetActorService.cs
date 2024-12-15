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
    public class GetActorService
    {
        private readonly MovieContext _dbContext;

        public GetActorService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Actor> GetActorAsync(string actorId)
        {
            var query = @"
                SELECT nconst, primaryname, birthyear, deathyear, primaryprofession
                FROM name_basics
                WHERE nconst = @actorId";
            return await _dbContext.Set<Actor>()
                .FromSqlRaw(query, new NpgsqlParameter("@actorId", actorId))
                .FirstOrDefaultAsync();
        }
    }

}
