namespace DAO;
using Microsoft.EntityFrameworkCore;

public class DaoContext : DbContext
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<Stocks> Stocks { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<WishList> WishList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //bancoluis
        optionsBuilder.UseSqlServer("Data Source = JVLPC0571;" + "Initial Catalog = marketPlace; Integrated Security=True");
        //bancojao
        //optionsBuilder.UseSqlServer("Data Source = JVLPC0581;" + "Initial Catalog = marketPlace; Integrated Security=True");
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
            entity.Property(e=>e.postal_code).IsRequired();
        });
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.date_of_birth).IsRequired();
            entity.Property(e=>e.document).IsRequired();
            entity.Property(e=>e.email).IsRequired();
            entity.Property(e=>e.phone).IsRequired();
            entity.Property(e=>e.login).IsRequired();
            entity.Property(e=>e.passwd).IsRequired();
            entity.HasOne(d=>d.address);
        });
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.date_of_birth).IsRequired();
            entity.Property(e=>e.document).IsRequired();
            entity.Property(e=>e.email).IsRequired();
            entity.Property(e=>e.phone).IsRequired();
            entity.Property(e=>e.login).IsRequired();
            entity.Property(e=>e.passwd).IsRequired();
            entity.HasOne(d=>d.address);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.name).IsRequired();
            entity.Property(e=>e.bar_code).IsRequired();
            entity.Property(e=>e.image).IsRequired();
            entity.Property(e=>e.description).IsRequired();
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
            entity.Property(e=>e.data_purchase).IsRequired();
            entity.Property(e=>e.payment_type).IsRequired();
            entity.Property(e=>e.purchase_status).IsRequired();
            entity.Property(e=>e.purchase_values).IsRequired();
            entity.Property(e=>e.number_confirmation).IsRequired();
            entity.Property(e=>e.number_nf).IsRequired();
            entity.HasOne(d=>d.client);
            entity.HasOne(d=>d.store);
            entity.HasOne(d=>d.products);
        });
        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e=>e.id);
            entity.Property(e=>e.quantity).IsRequired();
            entity.Property(e=>e.unit_price).IsRequired();
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