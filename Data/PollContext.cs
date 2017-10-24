using System;
using Microsoft.EntityFrameworkCore;

namespace lunchPollNet.Models
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options) {}

        public DbSet<lunchPollNet.Models.Poll> Poll { get; set; }
        public DbSet<lunchPollNet.Models.PollItem> PollItem { get; set; }
        public DbSet<lunchPollNet.Models.Restaurant> Restaurant { get; set; }
    }
}