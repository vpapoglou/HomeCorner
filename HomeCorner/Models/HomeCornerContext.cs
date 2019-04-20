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
		const string connectionString = @"Data Source=TAMARA-PC\SQLEXPRESS;Initial Catalog=HomeCorner;Integrated Security=True";

		public HomeCornerContext() : base(connectionString) { }

		/// <summary>
		/// Collection managing housies
		/// </summary>
		public DbSet<House> Houses { get; set; }

		/// <summary>
		/// Collection managing customers
		/// </summary>
		public DbSet<Customer> Customers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// configures one-to-many relationship
			modelBuilder.Entity<House>()
				.HasRequired<Customer>(s => s.Owner)
				.WithMany(g => g.Houses)
				.HasForeignKey<int>(s => s.OwnerId)
				.WillCascadeOnDelete();
		}
	}
}
