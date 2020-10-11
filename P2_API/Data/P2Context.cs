using Microsoft.EntityFrameworkCore;
using P2_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_API.Data
{
    public class P2Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Preferences> Preferences { get; set; }

        public P2Context(DbContextOptions<P2Context> options) : base(options)
        {
        }
    }
}
