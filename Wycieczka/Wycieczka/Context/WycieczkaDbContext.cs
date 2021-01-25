using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wycieczka.Models;

namespace Wycieczka.Context
{
	public class WycieczkaDbContext : DbContext
	{
		public DbSet<WycieczkaInfo> WycieczkaInfos { get; set; }
		public DbSet<zdjecia> Zdjecias { get; set; }

		public WycieczkaDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
