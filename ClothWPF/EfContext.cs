using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF
{
    public class EfContext:DbContext
    {
        public EfContext() : base("name = EFContext")
        { }
        public DbSet<Product> Products { get; set; }
    }
}
