using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BmiBeregner.Models;

namespace BmiBeregner.Data
{
    public class BmiBeregnerContext : DbContext
    {
        public BmiBeregnerContext (DbContextOptions<BmiBeregnerContext> options)
            : base(options)
        {
        }

        public DbSet<BmiBeregner.Models.BmiCalculation> BmiCalculation { get; set; }
    }
}
