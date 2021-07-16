using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarDataApi.Service.Models;

namespace CarDataApi.Service
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<CarDataModel> CarDatatbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDataModel>()
                .HasKey(c=>new {c.CarId,c.FacilityId,c.TimeStamp});
        }
    }
}
