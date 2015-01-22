using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OX.Models
{
    public class OXDataContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<News> NewsAll { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}