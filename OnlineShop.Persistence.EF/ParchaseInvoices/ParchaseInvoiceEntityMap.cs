using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Persistence.EF.ParchaseInvoices
{
    class ParchaseInvoiceEntityMap : IEntityTypeConfiguration<ParchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<ParchaseInvoice> _)
        {
            _.ToTable("ParchaseInvoices");

            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Number);

            _.Property(_ => _.ProductId);

            _.Property(_ => _.ProductCount).IsRequired();

            _.Property(_ => _.DateRegistration);

            _.HasOne(_ => _.Product)
            .WithMany(_ => _.ParchaseInvoices)
            .HasForeignKey(_ => _.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
