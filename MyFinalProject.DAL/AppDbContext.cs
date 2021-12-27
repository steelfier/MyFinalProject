using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DbConnectionMy")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Tech> Techs { get; set; }
        public DbSet<UserTech> UsersTech { get; set; }
        public DbSet<Remote> Remotes { get; set; }
        public DbSet<RemoteButton> RemoteButtons { get; set; }
        


    }
}
