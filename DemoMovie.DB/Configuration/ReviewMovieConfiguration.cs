using DemoHttp.Models.Cinema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.DB.Configuration;

public class ReviewMovieConfiguration: IEntityTypeConfiguration<ReviewMovie>
{
    public void Configure(EntityTypeBuilder<ReviewMovie> builder)
    {
        builder.Property("ReviewerName").HasMaxLength(50);
    }
}