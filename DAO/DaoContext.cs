namespace DAO;
using Microsoft.EntityFrameworkCore;

public class DaoContext : DbContext
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<Stocks> Stocks { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<WishList> WishList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = JVLPC0571;" + "Initial Catalog = marketPlace; Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.street).IsRequired();
            entity.Property(e=>e.city).IsRequired();
            entity.Property(e=>e.state).IsRequired();
            entity.Property(e=>e.country).IsRequired();
            entity.Property(e=>e.postalCode).IsRequired();
        });
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.dateOfBirth).IsRequired();
            entity.Property(e=>e.document).IsRequired();
            entity.Property(e=>e.email).IsRequired();
            entity.Property(e=>e.phone).IsRequired();
            entity.Property(e=>e.login).IsRequired();
            entity.HasOne(d=>d.address);

        });
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.dateOfBirth).IsRequired();
            entity.Property(e=>e.document).IsRequired();
            entity.Property(e=>e.email).IsRequired();
            entity.Property(e=>e.phone).IsRequired();
            entity.Property(e=>e.login).IsRequired();
            entity.HasOne(d=>d.address);

        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.unitPrice).IsRequired();
            entity.Property(e=>e.barCode).IsRequired();
        });
        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.CNPJ).IsRequired();
            entity.HasOne(d=>d.owner);

        });
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.dataPurchase).IsRequired();
            entity.Property(e=>e.paymentType).IsRequired();
            entity.Property(e=>e.purchaseStatus).IsRequired();
            entity.Property(e=>e.purchaseValues).IsRequired();
            entity.Property(e=>e.numberConfirmation).IsRequired();
            entity.Property(e=>e.numberNf).IsRequired();
            entity.HasOne(d=>d.client);
            entity.HasOne(d=>d.store);
            entity.HasOne(d=>d.products);
        });
        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.quantity).IsRequired();
            entity.HasOne(d=>d.store);
            entity.HasOne(d=>d.product);
            
        });
        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.HasOne(d=>d.products);
            entity.HasOne(d=>d.client);

        });


    }
}