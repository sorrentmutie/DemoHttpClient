using DemoHttp.Models.Cinema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.DB.Configuration;

public class MovieConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property("Title").HasMaxLength(50);
    }
}