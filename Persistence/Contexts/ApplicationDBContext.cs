using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Common.Interface;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
            
        }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Campaign> Campaigns => Set<Campaign>();
        public DbSet<Certification> Certifications => Set<Certification>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Chef> Chefs => Set<Chef>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<DishCategory> DishCategories => Set<DishCategory>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Post> Posts => Set<Post>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Username = "john_doe",
                    Password = "securepassword1",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Parse("1985-05-15"),
                    Gender = 0,
                    ProfilePicture = "/profile/john_doe.jpg",
                    Bio = "Bio information for John Doe.",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "jane_smith",
                    Password = "p@ssw0rd",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "9876543210",
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Parse("1990-03-20"),
                    Gender = (GenderEnum)1,
                    ProfilePicture = "/profile/jane_smith.jpg",
                    Bio = "Bio information for Jane Smith.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "bob_jones",
                    Password = "strongpass123",
                    Email = "bob.jones@example.com",
                    PhoneNumber = "5556667777",
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = DateTime.Parse("1988-11-10"),
                    Gender = 0,
                    ProfilePicture = "/profile/bob_jones.jpg",
                    Bio = "Bio information for Bob Jones.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "sara_wilson",
                    Password = "sara123",
                    Email = "sara.wilson@example.com",
                    PhoneNumber = "1112223333",
                    FirstName = "Sara",
                    LastName = "Wilson",
                    DateOfBirth = DateTime.Parse("1992-07-18"),
                    Gender = (GenderEnum)1,
                    ProfilePicture = "/profile/sara_wilson.jpg",
                    Bio = "Bio information for Sara Wilson.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "mike_jackson",
                    Password = "mikepass",
                    Email = "mike.jackson@example.com",
                    PhoneNumber = "3334445555",
                    FirstName = "Mike",
                    LastName = "Jackson",
                    DateOfBirth = DateTime.Parse("1980-12-05"),
                    Gender = 0,
                    ProfilePicture = "/profile/mike_jackson.jpg",
                    Bio = "Bio information for Mike Jackson.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "fatnofat",
                    Password = "Phat@2711",
                    Email = "nguyenphat2711@gmail.com",
                    PhoneNumber = "0812400096",
                    FirstName = "Nguyen",
                    LastName = "Phat",
                    DateOfBirth = DateTime.Parse("2002-11-27"),
                    Gender = 0,
                    ProfilePicture = "/profile/phatnt.jpg",
                    Bio = "Bio information for Nguyen Phat.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "khoatruong",
                    Password = "Khoa2k17",
                    Email = "khoatruong@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Truong",
                    LastName = "Khoa",
                    DateOfBirth = DateTime.Parse("2002-11-27"),
                    Gender = 0,
                    ProfilePicture = "/profile/phatnt.jpg",
                    Bio = "Bio information for Nguyen Phat.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "vandung",
                    Password = "Dunghocgioivcl",
                    Email = "Dungkinaysinhviengioi@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Nguyen",
                    LastName = "Van Dung",
                    DateOfBirth = DateTime.Parse("2002-9-30"),
                    Gender = 0,
                    ProfilePicture = "/profile/dungnv.jpg",
                    Bio = "Bio information for Nguyen Van Dung.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "truongletuankiet",
                    Password = "Kiethocgioihayhat",
                    Email = "kiethathayvai@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Truong",
                    LastName = "Le Tuan Kiet",
                    DateOfBirth = DateTime.Parse("2002-10-30"),
                    Gender = 0,
                    ProfilePicture = "/profile/kiettlt.jpg",
                    Bio = "Bio information for Truong Le Tuan Kiet.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "trangxinhgai",
                    Password = "trangxinhxinhhihi",
                    Email = "trangxinhgai@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Le",
                    LastName = "Thi Thu Trang",
                    DateOfBirth = DateTime.Parse("2002-11-11"),
                    Gender = (GenderEnum)1,
                    ProfilePicture = "/profile/trangltt.jpg",
                    Bio = "Bio information for Le Thi Thu Trang.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Username = "ducbinhnguyen",
                    Password = "binhleader",
                    Email = "ducbinhnguyen@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Nguyen",
                    LastName = "Duc Binh",
                    DateOfBirth = DateTime.Parse("2002-12-11"),
                    Gender = 0,
                    ProfilePicture = "/profile/binhnd.jpg",
                    Bio = "Bio information for Nguyen Duc Binh.",
                    ActiveStatus = 1,
                    Roles = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                }
            // Add other sample Account objects here using the same pattern
            );
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChanges();
        }
    }
}
