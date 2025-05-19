using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Family" },
				new Category { CategoryID = 2, Name = "Friend" },
                new Category { CategoryID = 3, Name = "Work" },
                new Category { CategoryID = 4, Name = "Business" },
				new Category { CategoryID = 5, Name = "Other" }
			);
            //contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactID = 1,
                    FirstName = "Delores",
                    LastName = "Del Rio",
                    Phone = 5559876543,
                    Email = "delores@hotmail.com",
                    Datetime = DateTime.Now,
                    CategoryID = 2
                },
                new Contact
                {
                    ContactID = 3,
                    FirstName = "Efren",
                    LastName = "Herrera",
                    Phone = 5554567890,
                    Email = "efren@aol.com",
					Datetime = DateTime.Now,
                    CategoryID = 1
				},
                new Contact
                {
                    ContactID = 2,
                    FirstName = "Mary Ellen",
                    LastName = "Walton",
                    Phone = 5551234567,
                    Email = "MaryEllen@yahoo.com",
					Datetime = DateTime.Now,
                    CategoryID = 3
				}
            );
        }
    }
}
