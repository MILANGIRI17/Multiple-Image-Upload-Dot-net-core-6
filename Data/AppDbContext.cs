using Microsoft.EntityFrameworkCore;
using MultipleImageUpload.Models;

namespace MultipleImageUpload.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }

    }
}
