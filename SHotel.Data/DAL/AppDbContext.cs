using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHotel.Core.Models;
using SHotel.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<GuestReview> GuestReviews { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Eat> Eats { get; set; }
        public DbSet<EatCategory> EatCategories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<AdventureCategory> AdventureCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }            



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly); 
            base.OnModelCreating(modelBuilder);
        }

    }
}
