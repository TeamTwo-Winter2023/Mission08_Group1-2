using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Group1_2.Models
{
    public class TaskAdditionsContext : DbContext
    {

        public TaskAdditionsContext (DbContextOptions<TaskAdditionsContext> options) : base (options)
        {

        }

        public DbSet<TaskAddition> Additions { get; set; } 

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
                ); 

            mb.Entity<TaskAddition>().HasData(
                new TaskAddition
                {
                    TaskId = 1,
                    Task = "Get up",
                    DueDate = "2023-10-10",
                    Quadrant = 1,
                    CategoryID = 1,
                    Completed = false
                },
                new TaskAddition
                {
                    TaskId= 2,
                    Task = "Show up",
                    DueDate = "2023-10-10",
                    Quadrant = 1,
                    CategoryID = 2,
                    Completed = false
                }


                );
        }
    }
}
