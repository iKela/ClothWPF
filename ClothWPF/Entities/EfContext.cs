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
    public class EfContext : DbContext
    {
        public EfContext() : base(GetConnectionString())
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Arrival> Arrivals { get; set; }
        public DbSet<ArrivalProduct> ArrivalProducts { get; set; }


        public static string GetConnectionString()
        {
            string dbname = "WPFCloth";
            string username = "nazar1997";
            string password = "6621Nazar";
            string hostname = "clothes.cjnqprfoj451.eu-central-1.rds.amazonaws.com";
            string port = "1433";

            return "Data Source=" + hostname + ";Initial Catalog = " + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
    
}
