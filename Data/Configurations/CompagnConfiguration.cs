using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class CompagnConfiguration : IEntityTypeConfiguration<Compagn>
    {
        public void Configure(EntityTypeBuilder<Compagn> builder)
        {
            builder.OwnsOne(p => p.Product);
        }
    }
}
