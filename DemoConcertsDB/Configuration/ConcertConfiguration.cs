using DemoHttp.Models.Music;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoConcertsDB.Configuration;

public class ConcertConfiguration: IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.Property("Location").HasMaxLength(50);    
    }
}