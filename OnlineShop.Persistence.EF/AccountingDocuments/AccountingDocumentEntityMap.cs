using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    class AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> _)
        {
            _.ToTable("AccuntingDocuments");
            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired()
            .ValueGeneratedOnAdd();

            _.Property(_ => _.Number).IsRequired().HasMaxLength(20);

            _.Property(_ => _.SaleInvoiceNumber);

            _.Property(_ => _.SaleInvoiceId);

            _.Property(_ => _.DateRegistration);

            _.Property(_ => _.TotalAmount);

            _.HasOne(_ => _.SaleInvoice).WithMany(_ => _.AccountingDocuments)
                .HasForeignKey(_ => _.SaleInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
