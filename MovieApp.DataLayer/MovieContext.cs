using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using MovieApp.DataLayer.Services;
using System.Linq;

using static MovieApp.DataLayer.Services.WordToWordService;

namespace MovieApp.DataLayer
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Bookmark> Bookmarks { get; set; } // DbSet til bookmarks
        public DbSet<User> users { get; set; } // DbSet til users
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; } // Renamed DbSet for consistency
        public DbSet<BestMatchResult> BestMatchResults { get; set; }
        public DbSet<RatingsForMovieResult> RatingsForMovieResults { get; set; }
        public DbSet<ExactMatchResult> ExactmatchResults { get; set; }
        public DbSet<StringSearchResult> StringSearchResults { get; set; }
        public DbSet<StructuredStringSearchResult> StructuredStringSearchResult { get; set; }
        public DbSet<WordToWordResult> WordToWordResults { get; set; }
        public DbSet<MovieActorResult> MovieActorResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)


        {
            // Bookmark mapping
            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.ToTable("bookmarks"); // Tabelnavn med små bogstaver
                entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.ItemType).HasColumnName("item_type");
                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.Annotation).HasColumnName("annotation");
            });

            // User mapping
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // Tabelnavn med små bogstaver
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Username).HasColumnName("username");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Role).HasColumnName("role");
                entity.Property(e => e.Salt).HasColumnName("salt");
            });

            // SearchHistory mapping
            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.ToTable("search_history"); // Table name
                entity.HasKey(e => e.SearchId); // Define primary key
                entity.Property(e => e.SearchId).HasColumnName("search_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.SearchTerm).HasColumnName("search_term");
                entity.Property(e => e.SearchDate).HasColumnName("search_date");
            });

            modelBuilder.Entity<BestMatchResult>().HasNoKey();
            modelBuilder.Entity<RatingsForMovieResult>().HasNoKey();
            modelBuilder.Entity<ExactMatchResult>().HasNoKey();
            modelBuilder.Entity<CoplayerResult>().HasNoKey();
            modelBuilder.Entity<BookmarkResult>().HasNoKey();
            modelBuilder.Entity<SearchHistoryResult>().HasNoKey();
            modelBuilder.Entity<PersonWordsResult>().HasNoKey();
            modelBuilder.Entity<SimilarMoviesResult>().HasNoKey();
            modelBuilder.Entity<StructuredStringSearchResult>().HasNoKey();
            modelBuilder.Entity<WordToWordResult>().HasNoKey();
            modelBuilder.Entity<MovieActorResult>().HasNoKey();
            
        }
    }
}
