using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DataLayer.Models;
namespace Project.DataLayer.Configurations
{

    public class StudentConfiguration : IEntityTypeConfiguration<StudentModel>
    {
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Username)
                   .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Surname) 
                .IsRequired();
            
            builder.Property (b=>b.Email)
                .IsRequired();

            builder.Property(b=> b.Phone)
                .IsRequired();

                
        }
    }
}
