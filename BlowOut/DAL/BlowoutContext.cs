using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut.DAL
{
    public class BlowoutContext : DbContext
    {
        public BlowoutContext() : base("BlowoutContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}