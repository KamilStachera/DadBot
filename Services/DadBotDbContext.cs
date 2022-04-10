
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DadBot.Services
{
    public class DadBotDbContext : DbContext
    {
        public DadBotDbContext() : base()
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(local);Database=DBLol;Integrated Security=True;");
            }
        }

        public virtual DbSet<Champion> Champions { get; set; }
    }
}

//
