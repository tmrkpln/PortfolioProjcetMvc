using CoreMvc_Project_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc_Project_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=TAMER\\SQLEXPRESS;database=CoreProjectDB2;integrated security=true");
            //Bağlantı adresini tanımlayan metot
        }

        public DbSet<Category> Categories { get; set; }
    }
}
