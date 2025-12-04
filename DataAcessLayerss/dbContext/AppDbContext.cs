using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAcessLayerss.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connString =
                "server=89.252.187.226;port=3306;database=pekovaco_mtguards;user=pekovaco_mtguards;password=0#2ENljW6dwm!qpz;";

            var serverVersion = ServerVersion.AutoDetect(connString);

            optionsBuilder.UseMySql(connString, serverVersion);
        }


        public DbSet<license> Licenses { get; set; }
    }
}
