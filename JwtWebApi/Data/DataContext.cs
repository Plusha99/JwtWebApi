using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JwtWebApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tip> Tips { get; set; }
    }
}
