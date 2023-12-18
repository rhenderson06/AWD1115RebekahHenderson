using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models.DataAccess.Configuration;

internal class RegistrationnConfig : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> entity)
    {
        //composite primary key
        entity.HasKey(r => new { r.CustomerID, r.ProductID });

        //one to many relationship btwn customer/product
        entity.HasOne(r => r.Customer).WithMany(c => c.Registrations).HasForeignKey(r => r.CustomerID);

        //one to many relationship btwn product/registrations
        entity.HasOne(r => r.Product).WithMany(p => p.Registrations).HasForeignKey(r => r.ProductID);
    }
}
