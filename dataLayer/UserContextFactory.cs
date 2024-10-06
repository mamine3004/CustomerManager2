using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public class UserContextFactory:IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();

            // Use your connection string or configure it accordingly
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TOLSAEC\\SQLEXPRESS;Initial Catalog=estore24;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new UserContext(optionsBuilder.Options);
        }
    }
}
