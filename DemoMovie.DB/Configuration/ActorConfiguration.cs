using DemoHttp.Models.Cinema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.DB.Configuration;

public class ActorConfiguration: IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.Property("Name").HasMaxLength(50);
        builder.Property("Surname").HasMaxLength(50);
    }
}