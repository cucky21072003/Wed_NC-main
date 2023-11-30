﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using IVYmodaONLINE.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IVYmodaONLINE.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string fullName { get; set; }
        public string Phone { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Adv> Advs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public  DbSet<New> News { get; set; }
        public  DbSet<SystemSetting> SystemSettings { get; set; }
        public  DbSet<Productcategory> Productcategories { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<OrderDetail> OrderDetails { get; set; }
        public  DbSet<Subscrice> Subscrices { get; set; }
        public  DbSet<ProductImage> ProductImages { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        internal object Entry<T>()
        {
            throw new NotImplementedException();
        }
    }
}