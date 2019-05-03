using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeCorner.Models
{
	/// <summary>
	/// Used to access and persist data to the database
	/// </summary>
	public class HomeCornerContext : DbContext
	{
		// We need to replace this value with the appropriate value that points to the local database
		const string connectionString = @"Data Source=DESKTOP-M08V3JF\SQLEXPRESS;Initial Catalog=HomeCorner;Integrated Security=True";

		public HomeCornerContext() : base(connectionString) { }

		/// <summary>
		/// Collection managing housies
		/// </summary>
		public DbSet<House> Houses { get; set; }

		/// <summary>
		/// Collection managing customers
		/// </summary>
		public DbSet<Customer> Customers { get; set; }

		public DbSet<Features> Features { get; set; }

		public DbSet<Region> Regions { get; set; }
		public object Images { get; internal set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// configures one-to-many relationship
			modelBuilder.Entity<House>()
				.HasRequired<Customer>(s => s.Owner)
				.WithMany(g => g.Houses)
				.HasForeignKey<int>(s => s.OwnerId)
				.WillCascadeOnDelete();

			modelBuilder.Entity<House>()
				.HasRequired<Region>(s => s.Region)
				.WithMany(g => g.Houses)
				.HasForeignKey<byte>(s => s.RegionId)
				.WillCascadeOnDelete();

			modelBuilder.Entity<Images>()
				.HasRequired<House>(s => s.House)
				.WithMany(g => g.Images)
				.HasForeignKey<int>(s => s.HouseId)
				.WillCascadeOnDelete();
		}
	}
}
