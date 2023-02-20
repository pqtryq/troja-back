using Microsoft.EntityFrameworkCore;
using Npgsql;
using troja.Models;

namespace troja.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost; Database=trojadbv2; Username=postgres; Password=admin");
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Travel> Travels { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Idcountry).HasName("pk_country");

            entity.ToTable("country");

            entity.Property(e => e.Idcountry)
                .ValueGeneratedNever()
                .HasColumnName("idcountry");
            entity.Property(e => e.Countryname).HasColumnName("countryname");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("pk_reservation");

            entity.ToTable("reservation");

            entity.Property(e => e.Idreservation)
                .ValueGeneratedNever()
                .HasColumnName("idreservation");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Lastname).HasColumnName("lastname");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Idtravel).HasColumnName("idtravel");
            entity.Property(e => e.Nop).HasColumnName("nop");
            entity.Property(e => e.PhoneNumber).HasColumnName("phonenumber");
            entity.Property(e => e.Orderdatetime).HasColumnName("orderdatetime");
            
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.Idtravel).HasName("pk_travel");

            entity.ToTable("travel");
            

            entity.Property(e => e.Idtravel)
                .ValueGeneratedNever()
                .HasColumnName("idtravel");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Hotel).HasColumnName("hotel");
            entity.Property(e => e.Idcountry).HasColumnName("idcountry");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Remslots).HasColumnName("remslots");
            entity.Property(e => e.Slots).HasColumnName("slots");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Xcord).HasColumnName("xcord");
            entity.Property(e => e.Ycord).HasColumnName("ycord");
            
        });
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
}