using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DadBot.Models.LOLModels;

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
                optionsBuilder.UseSqlServer(@"Server=(local);Database=DBLol;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        public virtual DbSet<Champion> Champions { get; set; }
        public virtual DbSet<Summoner> Summoners { get; set; }
    }
}

//
