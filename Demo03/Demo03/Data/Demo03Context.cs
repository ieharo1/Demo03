using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo03.Models;

namespace Demo03.Data
{
    public class Demo03Context : DbContext
    {
        public Demo03Context (DbContextOptions<Demo03Context> options)
            : base(options)
        {
        }

        public DbSet<Demo03.Models.producto> producto { get; set; }

        public DbSet<Demo03.Models.categoria> categoria { get; set; }
    }
}
