using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rocky_Models;

namespace Rocky_DataAccess
{
    public class ApplicationDbContext : IdentityDbContext // Этот класс можно назвать как угодно, но в конце дописать DbContext. Чтобы сделать класс действительно DbContext, его нужно унаследовать от класса DbContext через :
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // ctor + Tab + Tab = Constructor
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<InquiryHeader> InquiryHeader { get; set; }
        public DbSet<InquiryDetail> InquiryDetail { get; set; }
    }
}
