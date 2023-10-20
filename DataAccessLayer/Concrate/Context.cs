using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context: IdentityDbContext<AppUser, AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=CDNProjectDb;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<Folder> Folders { get; set; } 
    }
}
