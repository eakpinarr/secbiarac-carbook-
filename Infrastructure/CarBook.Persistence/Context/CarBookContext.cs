﻿using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Context
{
    public class CarBookContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LENOVO\\SQLEXPRESS;initial Catalog=CarBookDb; integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<About> Abouts {  get; set; }
        public DbSet<AppUser> AppUsers {  get; set; }
        public DbSet<AppRole> AppRoles{  get; set; }
        public DbSet<Banner> Banners  { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }    
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Review> Reviews{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpReservation)
                .HasForeignKey(z => z.PickUpLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
            .HasOne(x => x.DropOffLocation)
            .WithMany(y => y.DropOffReservation)
            .HasForeignKey(z => z.DropOffLocationID)
            .OnDelete(DeleteBehavior.ClientSetNull);

            // Araç rezervasyon işlemi yaparken Location Tablosu içindeki deki LocationID ile
            // Reservation tablosu içindeki Aracın alınacağı PickUpLocationID ve
            // Yine Reservation tablosu içerisinde bulunan aracın teslim edileceği DropOffLocationID değerlerini
            // Bu yöntemle birleştirdik.
            // Bunu yapabilmek için Location türünde PickUpLocation ve DropOffLocation türünde iki
            // Proporty oluşturduk. Aynı zamanda bu iki proporty ile Location tablosuna erişim sağlamış olacağız.


            // Burada amaç elimizdeki iki ID ile karşı tarafın Tek ID'sini birleştirmek.
            // .HasOne:Reservation Tablosu içerisindeki  PickUplocation'u al
            // .WithMany: Bunu PickUpReservation ile ilişkilendir.
            // .HasForeignKey: Bunu PickUpLocationID stunu ile ilişkilenecek.
            // .OnDelete: Silindiğinde hata vermemesi için Null'a eşitle. 
        }
    }
}
