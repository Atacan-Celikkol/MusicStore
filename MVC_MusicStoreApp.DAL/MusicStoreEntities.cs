using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVC_MusicStoreApp.DAL
{
   public class MusicStoreEntities:DbContext
    {

        public MusicStoreEntities():base("server=.;database=MusicStoreDb;Integrated Security=True;")
        {
           
        }
        //public MusicStoreEntities() : base("MusicStoreCon") 
        //{
        //    //çalıştığın projenin config dosyasına git orada MusicStoreCon isimli connection stringi ara
        //}

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MusicStoreEntities>(new MyStrategy());
            //Album
            modelBuilder.Entity<Album>().Property(x => x.Price).HasColumnType("money");
            modelBuilder.Entity<Album>().Property(x => x.Title).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Album>().Property(x => x.AlbumArtUrl).HasMaxLength(256);
            //Genre
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(75).IsRequired();
            modelBuilder.Entity<Genre>().Property(x => x.Description).HasMaxLength(300);
            //Artist
            modelBuilder.Entity<Artist>().Property(x => x.Name).HasMaxLength(250).IsRequired();
            //UserDetail
            modelBuilder.Entity<UserDetail>().Property(x => x.FirstName).HasMaxLength(75);
            modelBuilder.Entity<UserDetail>().Property(x => x.LastName).HasMaxLength(75);
            modelBuilder.Entity<UserDetail>().Property(x => x.Address).HasMaxLength(300);
            modelBuilder.Entity<UserDetail>().Property(x => x.Email).HasMaxLength(150);
            modelBuilder.Entity<UserDetail>().Property(x => x.Notes).HasMaxLength(500);
            modelBuilder.Entity<UserDetail>().Property(x => x.Phone).HasMaxLength(18);
            modelBuilder.Entity<UserDetail>().Property(x => x.UserName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<UserDetail>().Ignore(x => x.ConfirmPassword);
            //Order
            modelBuilder.Entity<Order>().Property(x => x.ShipAddress).HasMaxLength(350);
            modelBuilder.Entity<Order>().Property(x => x.Email).HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(x => x.Phone).HasMaxLength(18);
            //OrderDetail
            modelBuilder.Entity<OrderDetail>().Property(x => x.Price).HasColumnType("money");
            
        }
    }
}
