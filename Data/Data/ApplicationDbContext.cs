using Data.Data.CMS;
using Data.Data.Portal;
using Data.Data.Shop;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Distance> Distance { get; set; }
        public DbSet<EntryFeePaid> EntryFeePaid { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Cattegory> Cattegory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<SpecialOffer> SpecialOffer { get; set; }
    }
}