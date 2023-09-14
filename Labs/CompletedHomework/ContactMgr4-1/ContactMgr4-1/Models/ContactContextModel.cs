using Microsoft.EntityFrameworkCore;

namespace ContactMgr4_1.Models
{
    public class ContactContextModel : DbContext
    {
        //constructor 
        public ContactContextModel(DbContextOptions<ContactContextModel> options) : base(options) { }

        //create DbSets
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        //add seed data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data for categories table
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 1, Name = "Family" },
                new CategoryModel { CategoryId = 2, Name = "Friend" },
                new CategoryModel { CategoryId = 3, Name = "Work" },
                new CategoryModel { CategoryId = 4, Name = "Other" }
            );

            //seed data for contacts table
            modelBuilder.Entity<CategoryModel>().HasData(
                new ContactModel
                {
                    ContactId = 1,
                    FirstName = "Mary Ellen",
                    LastName = "Walton",
                    Phone = "555-123-4567",
                    Email = "maryellen@yahoo.com",
                    CategoryId = 1,
                    DateAdded = DateTime.Now
                },
                new ContactModel
                {
                    ContactId = 2,
                    FirstName = "Delores",
                    LastName = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "delores@hotmail.com",
                    CategoryId = 2,
                    DateAdded = DateTime.Now
                },
                new ContactModel
                {
                    ContactId = 3,
                    FirstName = "Efren",
                    LastName = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    CategoryId = 3,
                    DateAdded = DateTime.Now
                }
            );

        }
    }
}
