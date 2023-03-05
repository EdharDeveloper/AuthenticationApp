using Authorization.EntityFramework.Models.AuthorizationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PasswordHasher;

namespace Authorization.EntityFramework.Data
{
    public class DbBuilderContext : DbContext
    {

        public DbBuilderContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(config =>
            {
                config.ToTable("Users");
                config.HasKey(x => x.Id);
                config.HasMany(x => x.UserRoles).WithOne(x => x.User);

            });
            modelBuilder.Entity<Role>(config =>
            {
                config.ToTable("Roles");
                config.HasKey(x => x.Id);
                config.HasMany(x => x.UserRoles).WithOne(x => x.Role);
            });
            string password = "Qwerty";
            User admin = new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                PasswordHash = PasswordHasherProvider.GetHash(password)

            };
            User manager = new User
            {
                Id = Guid.NewGuid(),
                UserName = "EdharBalian",
                PasswordHash = PasswordHasherProvider.GetHash(password)
            };

            List<User> users = new List<User>()
            {
                manager,admin
            };
            modelBuilder.Entity<User>().HasData(users);
            Role adminRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "admin",
            };
            Role managerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "manager",
            };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, managerRole });
            UserRole fistConnection = new UserRole
            {
                Id = Guid.NewGuid(),
                RoleId = adminRole.Id,
                UserId = admin.Id
            };
            UserRole secondConnection = new UserRole
            {
                Id = Guid.NewGuid(),
                RoleId = managerRole.Id,
                UserId = manager.Id
            };
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { fistConnection, secondConnection });

        }
    }
}
