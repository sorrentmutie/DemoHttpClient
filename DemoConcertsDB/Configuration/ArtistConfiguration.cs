using DemoHttp.Models.Music;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoConcertsDB.Configuration;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property("Name").HasMaxLength(50);
        builder.Property("Surname").HasMaxLength(50);
    }
}