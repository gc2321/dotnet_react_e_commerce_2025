using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole {Id = "0470cafd-120f-46b1-a1f9-ae1d020bfd6a", Name = "Member", NormalizedName = "MEMBER"},
                new IdentityRole {Id = "0106b113-f71d-4ac2-baa0-938af2a24f2c", Name = "Admin", NormalizedName = "ADMIN"}
            );
    }
}