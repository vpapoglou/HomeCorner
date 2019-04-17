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
		const string connectionString = @"Data Source=DESKTOP-G20562D\SQLEXPRESS;Initial Catalog=HomeCorner;Integrated Security=True";

		public HomeCornerContext() : base(connectionString) { }

		/// <summary>
		/// Collection managing housies
		/// </summary>
		public DbSet<House> Houses { get; set; }

		/// <summary>
		/// Collection managing customers
		/// </summary>
		public DbSet<Customer> Customers { get; set; }
	}
}