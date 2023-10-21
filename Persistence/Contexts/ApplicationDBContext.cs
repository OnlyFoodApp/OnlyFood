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
using Microsoft.Identity.Client;

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
            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();
            var accountId3 = Guid.NewGuid();
            var accountId4 = Guid.NewGuid();
            var accountId5 = Guid.NewGuid();

            var accountId6 = Guid.NewGuid();
            var accountId7 = Guid.NewGuid();
            var accountId8 = Guid.NewGuid();
            var accountId9 = Guid.NewGuid();
            var accountId10 = Guid.NewGuid();

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

            modelBuilder.Entity<Chef>().HasData(
    new Chef
    {
        Id = Guid.NewGuid(),
        Experience = "Experienced Chef",
        Awards = "Best Chef 2022",
        AccountId = accountId1, // Reference the previously seeded AccountId
        CreatedDate = DateTime.Now,
        LastModifiedDate = DateTime.Now,
    },
    new Chef
    {
        Id = Guid.NewGuid(),
        Experience = "Experienced Chef",
        Awards = "Best Chef 2022",
        AccountId = accountId2, // Reference the newly generated accountId2
        CreatedDate = DateTime.Now,
        LastModifiedDate = DateTime.Now,
    },
    new Chef
    {
        Id = Guid.NewGuid(),
        Experience = "Master Chef",
        Awards = "Top Chef 2022",
        AccountId = accountId3, // Reference the newly generated accountId3
        CreatedDate = DateTime.Now,
        LastModifiedDate = DateTime.Now,
    },
    new Chef
    {
        Id = Guid.NewGuid(),
        Experience = "Gourmet Chef",
        Awards = "Culinary Excellence Award 2022",
        AccountId = accountId4, // Reference the newly generated accountId4
        CreatedDate = DateTime.Now,
        LastModifiedDate = DateTime.Now,
    },
    new Chef
    {
        Id = Guid.NewGuid(),
        Experience = "Executive Chef",
        Awards = "Michelin Star Chef 2022",
        AccountId = accountId5, // Reference the newly generated accountId5
        CreatedDate = DateTime.Now,
        LastModifiedDate = DateTime.Now,
    });

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = accountId1,
                    Username = "user1",
                    Password = "password1",
                    Email = "user1@user1.com",
                    PhoneNumber = "1234567890",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Parse("1990-05-15"),
                    Gender = (GenderEnum)0,
                    ProfilePicture = "/profile/profile1.jpg",
                    Bio = "Avid reader",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Id = accountId2,
                    Username = "user2",
                    Password = "password2",
                    Email = "user2@user2.com",
                    PhoneNumber = "2345678901",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    DateOfBirth = DateTime.Parse("1985-12-10"),
                    Gender = (GenderEnum)1,
                    ProfilePicture = "/profile/profile2.jpg",
                    Bio = "Nature lover",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Id = accountId3,
                    Username = "user3",
                    Password = "password3",
                    Email = "user3@user3.com",
                    PhoneNumber = "3456789012",
                    FirstName = "Michael",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Parse("1988-08-20"),
                    Gender = (GenderEnum)0,
                    ProfilePicture = "/profile/profile3.jpg",
                    Bio = "Tech enthusiast",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Id = accountId4,
                    Username = "user4",
                    Password = "password4",
                    Email = "user4@user4.com",
                    PhoneNumber = "4567890123",
                    FirstName = "Emily",
                    LastName = "Davis",
                    DateOfBirth = DateTime.Parse("1992-04-05"),
                    Gender = (GenderEnum)1,
                    ProfilePicture = "/profile/profile4.jpg",
                    Bio = "Traveler",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                },
                new Account
                {
                    Id = accountId5,
                    Username = "user5",
                    Password = "password5",
                    Email = "user5@user5.com",
                    PhoneNumber = "5678901234",
                    FirstName = "Daniel",
                    LastName = "Brown",
                    DateOfBirth = DateTime.Parse("1983-11-30"),
                    Gender = (GenderEnum)0,
                    ProfilePicture = "/profile/profile5.jpg",
                    Bio = "Fitness enthusiast",
                    ActiveStatus = 1,
                    Roles = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    LastModifiedDate = DateTime.Now
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "123 Main St",
                    RewardsPoints = 100,
                    AccountId = accountId6, // Reference to the previously seeded AccountId (user1)
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "456 Elm St",
                    RewardsPoints = 200,
                    AccountId = accountId7, // Reference to the newly generated accountId2 (user2)
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "789 Oak St",
                    RewardsPoints = 150,
                    AccountId = accountId8, // Reference to the newly generated accountId3 (user3)
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "101 Pine St",
                    RewardsPoints = 250,
                    AccountId = accountId9, // Reference to the newly generated accountId4 (user4)
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "202 Maple St",
                    RewardsPoints = 300,
                    AccountId = accountId10, // Reference to the newly generated accountId5 (user5)
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                }
            );
            modelBuilder.Entity<Account>().HasData(
    new Account
    {
        Id = accountId6,
        Username = "johncustomer",
        Password = "customer123",
        Email = "john.customer@example.com",
        PhoneNumber = "1234567890",
        FirstName = "John",
        LastName = "Smith",
        DateOfBirth = DateTime.Parse("1988-03-25"),
        Gender = (GenderEnum)0, // Male
        ProfilePicture = "/profile/john_smith.jpg",
        Bio = "I love exploring new cuisines and trying out different recipes. Excited to be a part of this culinary community!",
        ActiveStatus = 1, // Active
        Roles = 0, // Customer role
        CreatedDate = DateTime.Now,
        CreatedBy = null,
        ModifiedBy = null,
        LastModifiedDate = DateTime.Now
    },
    new Account
    {
        Id = accountId7,
        Username = "emily_foods",
        Password = "emily1234",
        Email = "emily.foodie@example.com",
        PhoneNumber = "2345678901",
        FirstName = "Emily",
        LastName = "Johnson",
        DateOfBirth = DateTime.Parse("1990-08-15"),
        Gender = (GenderEnum)0, // Female
        ProfilePicture = "/profile/emily_johnson.jpg",
        Bio = "Food enthusiast and home cook. I enjoy experimenting with flavors and creating delightful dishes for my family and friends.",
        ActiveStatus = 1, // Active
        Roles = 0, // Customer role
        CreatedDate = DateTime.Now,
        CreatedBy = null,
        ModifiedBy = null,
        LastModifiedDate = DateTime.Now
    },
    new Account
    {
        Id = accountId8,
        Username = "healthy_eater",
        Password = "healthyeats",
        Email = "healthymeals@example.com",
        PhoneNumber = "3456789012",
        FirstName = "Alice",
        LastName = "Green",
        DateOfBirth = DateTime.Parse("1985-05-10"),
        Gender = (GenderEnum)1, // Female
        ProfilePicture = "/profile/alice_green.jpg",
        Bio = "Passionate about healthy living and clean eating. Sharing my journey towards a healthier lifestyle through nutritious meals.",
        ActiveStatus = 1, // Active
        Roles = 0, // Customer role
        CreatedDate = DateTime.Now,
        CreatedBy = null,
        ModifiedBy = null,
        LastModifiedDate = DateTime.Now
    },
    new Account
    {
        Id = accountId9,
        Username = "traveling_foodie",
        Password = "foodlover",
        Email = "foodexplorer@example.com",
        PhoneNumber = "4567890123",
        FirstName = "Daniel",
        LastName = "Baker",
        DateOfBirth = DateTime.Parse("1982-12-18"),
        Gender = (GenderEnum)0, // Male
        ProfilePicture = "/profile/daniel_baker.jpg",
        Bio = "A food lover who enjoys exploring different cuisines and local delicacies during my travels. Food brings people together!",
        ActiveStatus = 1, // Active
        Roles = 0, // Customer role
        CreatedDate = DateTime.Now,
        CreatedBy = null,
        ModifiedBy = null,
        LastModifiedDate = DateTime.Now
    },
    new Account
    {
        Id = accountId10,
        Username = "baking_enthusiast",
        Password = "bakeitup",
        Email = "baker@example.com",
        PhoneNumber = "5678901234",
        FirstName = "Olivia",
        LastName = "Miller",
        DateOfBirth = DateTime.Parse("1989-06-22"),
        Gender = (GenderEnum)1, // Female
        ProfilePicture = "/profile/olivia_miller.jpg",
        Bio = "Passionate about baking and pastry creations. Join me on my baking adventures as I explore the art of sweets and treats!",
        ActiveStatus = 1, // Active
        Roles = 0, // Customer role
        CreatedDate = DateTime.Now,
        CreatedBy = null,
        ModifiedBy = null,
        LastModifiedDate = DateTime.Now
    }
);

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Momo",
                    Description = "Thanh toan qua vi dien tu momo",
                    IsActived = 1,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });

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
