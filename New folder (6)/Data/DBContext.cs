using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HorasExtra.Models;
using Microsoft.EntityFrameworkCore;

namespace HorasExtra.Data
{
    public class HorasExtraDBContext : DbContext
    {
        public HorasExtraDBContext(DbContextOptions<HorasExtraDBContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Request> Request { get; set; }

    }

}
