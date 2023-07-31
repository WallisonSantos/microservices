using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext( DbContextOptions<MySqlContext> options )
        :   base( options:options )
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}