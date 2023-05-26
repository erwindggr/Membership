using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Membership.Models;

namespace Membership.Data
{
    public class MembershipContext : DbContext
    {
        public MembershipContext (DbContextOptions<MembershipContext> options)
            : base(options)
        {
        }

        public DbSet<Membership.Models.Movie> Movie { get; set; } = default!;

        public DbSet<Membership.Models.Member>? Member { get; set; }

        public DbSet<Membership.Models.MemberType>? MemberType { get; set; }
    }
}
