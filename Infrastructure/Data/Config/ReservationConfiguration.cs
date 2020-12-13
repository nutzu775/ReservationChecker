using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(p => p.TotalPrice).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired().HasColumnType("decimal(10,2)");
        }
    }
}