using Microsoft.EntityFrameworkCore;
using Sevdah.Models;

namespace Sevdah.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<RacunProizvod> RacunProizvodi { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<OdobreniRabat> OdobreniRabat { get; set; }
        public DbSet<Skladiste> Skladiste { get; set; }
        public DbSet<Otpremnica> Otpremnica { get; set; }
        public DbSet<OtpremnicaProizvod> OtpremnicaProizvod { get; set; }

        //

        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<VrstaProizvoda> VrsteProizvoda { get; set; }
        public DbSet<ProizvodDobavljac> ProizvodDobavljac { get; set; }
        public DbSet<RacunDobavljaca> RacuniDobavljaca { get; set; }
        public DbSet<RacunProizvodDobavljaca> RacunProizvodDobavljaca { get; set; }
        public DbSet<UplataDobavljacu> UplateDobavljacu { get; set; }

        //

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
    }
}
