using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.SaleInvoices
{
    class SaleInvoiceEntityMap : IEntityTypeConfiguration<SaleInvoice>
    {
        public void Configure(EntityTypeBuilder<SaleInvoice> _)
        {
            _.ToTable("SaleInvoices");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired()
            .ValueGeneratedOnAdd();

            _.Property(_ => _.Number).IsRequired()
            .HasMaxLength(20);

            _.Property(_ => _.CustomerName)
            .IsRequired().HasMaxLength(100);

            _.Property(_ => _.DateRegistration);

            _.HasMany(_ => _.saleInvoiceItems)
            .WithOne(_ => _.SaleInvoice)
            .HasForeignKey(_ => _.SaleInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
