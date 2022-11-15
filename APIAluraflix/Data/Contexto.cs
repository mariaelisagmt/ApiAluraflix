using Microsoft.EntityFrameworkCore;
using APIAluraflix.Models;

namespace APIAluraflix.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Video> Videos {get;set;}
    }
}
