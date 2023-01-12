using Microsoft.EntityFrameworkCore;
using projekt.Models;


namespace projekt.Models
{
    public class prkontekt : DbContext
    {


        public prkontekt(DbContextOptions<prkontekt> options) : base(options) { }


        public DbSet<projekt.Models.Fish> Ryby { get; set; } = default!;


        public DbSet<projekt.Models.Fishery> Zbiornik { get; set; } = default!;


        public DbSet<projekt.Models.District> Okreg { get; set; } = default!;


        public DbSet<projekt.Models.Specie> Gatunek { get; set; } = default!;

    }
}

