
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace erajhnqraej.Models
{
    public class LibrariAPIContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public LibrariAPIContext(DbContextOptions<LibrariAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       
    }
}
