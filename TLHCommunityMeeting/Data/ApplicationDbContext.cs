using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TLHCommunityMeeting.Models;

namespace TLHCommunityMeeting.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<StrawPoll> StrawPolls { get; set; } = null!;
}