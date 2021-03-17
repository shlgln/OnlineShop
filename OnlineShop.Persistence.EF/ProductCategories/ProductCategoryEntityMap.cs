using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Persistence.EF.ProductCategorIes
{
    class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> _)
        {
            _.ToTable("ProductCategories");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(100);

            _.HasMany(_ => _.Products).WithOne(_ => _.ProductCategory)
            .HasForeignKey(_ => _.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
