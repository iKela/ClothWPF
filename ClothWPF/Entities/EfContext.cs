using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF
{
    public class SampleInitializer : DropCreateDatabaseIfModelChanges<EfContext>
    {
        //protected override void Seed(EfContext context)
        //{
        //    List<City> cities = new List<City>
        //    {
        //        new City { Name = "Москва" },
        //        new City { Name = "Санкт-Петербург" },
        //        new City { Name = "Казань" }
        //        // ...
        //    };

        //    foreach (City city in cities)
        //        context.Cities.Add(city);

        //    context.SaveChanges();
        //    base.Seed(context);
        //}
    }

    public class EfContext : DbContext
    {
        static EfContext()
        {
           // Database.SetInitializer<EfContext>(new SampleInitializer());
        }
        public EfContext() : base(GetConnectionString())
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Arrivals> Arrivals { get; set; }
        public DbSet<ArrivalProduct> ArrivalProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Entities.Enterprise> Enterprises { get; set; }
        public DbSet<Realization> Realizations { get; set; }
        public DbSet<RealizationProduct> RealizationProducts { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }
       

       private static string GetConnectionString() //TestVersion
        {
            string dbname = "ClothWPF";
            string username = "nazar1997";
            string password = "6621Nazar";
            string hostname = "clothes.cjnqprfoj451.eu-central-1.rds.amazonaws.com";
            //string port = "1433";
            return "Data Source=" + hostname + ";Initial Catalog = " + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
        //public static string GetConnectionString() //WorkVersion
        //{
        //    string dbname = "WPFCloth";
        //    string username = "nazar1997";
        //    string password = "6621Nazar";
        //    string hostname = "clothes.cjnqprfoj451.eu-central-1.rds.amazonaws.com";
        //    //string port = "1433";
        //    return "Data Source=" + hostname + ";Initial Catalog = " + dbname + ";User ID=" + username + ";Password=" + password + ";";
        //}
    }

}
