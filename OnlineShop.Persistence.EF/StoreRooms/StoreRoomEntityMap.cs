using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.StoreRooms
{
    class StoreRoomEntityMap : IEntityTypeConfiguration<StoreRoom>
    {
        public void Configure(EntityTypeBuilder<StoreRoom> _)
        {
            _.ToTable("StoreRooms");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired()
            .ValueGeneratedOnAdd();

            _.Property(_ => _.ProductId);

            _.Property(_ => _.Stock);
        }
    }
}
