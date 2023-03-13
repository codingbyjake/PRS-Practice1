using Microsoft.EntityFrameworkCore;

namespace PRS_Practice1.Models {
    public class PRSPrac1DbContext : DbContext {
        public PRSPrac1DbContext(DbContextOptions<PRSPrac1DbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<RequestLine> RequestLines { get; set; } = null!;

    }
}
