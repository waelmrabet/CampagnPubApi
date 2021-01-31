using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class CompagnBusinessConfiguration : IEntityTypeConfiguration<CompagnBusiness>
    {
        public void Configure(EntityTypeBuilder<CompagnBusiness> builder)
        {            

            builder.HasKey(cb => new { cb.BusinessId, cb.CompagnId });
            builder.HasOne(cb => cb.BusinessType).WithMany(b => b.CompagnBusinesses);
            builder.HasOne(cb => cb.Compagn).WithMany(c => c.CompagnBusinesses);
        }
    }
}
