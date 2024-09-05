using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Affiche_Theatre_0.Domain.Entities;

namespace Affiche_Theatre_0.Domain
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //получение таблиц
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Affiche> Affiches { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FileModel> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //роль админ
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "9997B3DD-8A2F-460B-99FD-F280115BAA78",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            //пользователь админ
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3F3D1162-B3B6-4934-A37C-C416E28BF618",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                //сразу подтв. email, чтобы пользв смог вход в панель администратора
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty
            });

            //прописываем, что к роли админ относится пользователь админ
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "9997B3DD-8A2F-460B-99FD-F280115BAA78",
                UserId = "3F3D1162-B3B6-4934-A37C-C416E28BF618"
            });

            //текстовые поля - для изменения содерж табл
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("7195309F-189E-4B60-914F-6E07B401120E"),
                CodeWord = "PageIndex",
                Title = "Афиша"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("90860496-CBF5-4FDB-A308-14F61F6AF28B"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ED1B025D-6C0B-4A5D-B230-7BABCCBE85FA"),
                CodeWord = "PageActors",
                Title = "Актёры"
            });
        }
    }
}
