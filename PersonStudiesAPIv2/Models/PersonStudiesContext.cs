using Microsoft.EntityFrameworkCore;

namespace PersonStudiesAPIv2.Models
{
    public class PersonStudiesContext : DbContext
    {
        public PersonStudiesContext(DbContextOptions<PersonStudiesContext> options)
            : base(options)
        {
        }

        //public DbSet<MvcDemo.Models.Person> Person { get; set; }  
        public DbSet<Person> Person { get; set; }
        public DbSet<Studie> Studie { get; set; }
    }
}