using Microsoft.EntityFrameworkCore;

namespace QuarterlySalesApp11.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : 
            base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    DOB = new DateTime(1956, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerID = 0
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Katherine",
                    LastName = "Johnson",
                    DOB = new DateTime(1966, 8, 26),
                    DateOfHire = new DateTime(1999, 1, 1),
                    ManagerID = 1
                },
                new Employee
                {
                    EmployeeID = 3,
                    FirstName = "Grace",
                    LastName = "Hopper",
                    DOB = new DateTime(1975, 12, 9),
                    DateOfHire = new DateTime(1999, 1, 1),
                    ManagerID = 1
                }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    SaleID = 1,
                    Quarter = 4,
                    Year = 2019,
                    Amount = 23456,
                    EmployeeID = 2
                },
                new Sale
                {
                    SaleID = 2,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 34567,
                    EmployeeID = 2
                },
                new Sale
                {
                    SaleID = 3,
                    Quarter = 4,
                    Year = 2019,
                    Amount = 19876,
                    EmployeeID = 3
                },
                new Sale
                {
                    SaleID = 4,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 31009,
                    EmployeeID = 3
                }
            );
        }

    }
}
