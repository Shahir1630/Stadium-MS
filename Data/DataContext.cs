using Microsoft.EntityFrameworkCore;
using StadiumManagementSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<GameSchedule> GameSchedule { get; set; }
        public DbSet<Cost>Cost  { get; set; }


    }
}
