using Microsoft.EntityFrameworkCore;    //Enable entity
using ChessWithCohorts.Models;


namespace ChessWithCohorts.Contexts
{
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        
        // public DbSet<Something> Somethings { get; set; }
        public DbSet<User> Users {get; set;}
    }
}