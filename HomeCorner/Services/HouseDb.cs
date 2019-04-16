using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeCorner.Models;

namespace HomeCorner.Services
{
    public class HouseDb
    {
        private static IList<House> _db = new List<House>()
        {
            new House() { Id = 1, Name = "White House" },
            new House() { Id = 2, Name = "Black House" },
            new House() { Id = 3, Name = "Island House" },
            new House() { Id = 4, Name = "Mountain House" },

        };
        public static IList<House> GetAll()
        {
            return _db;
        }
        public static void Add(House customer)
        {
            var rnd = new Random();
            customer.Id = rnd.Next(1, 1000);
            _db.Add(customer);
        }

        public static void Update(House movie)
        {

        }

        public static void Delete(House movie)
        {
            _db.Remove(movie);
        }

        public static House GetById(int Id)
        {
            return _db.FirstOrDefault(c => c.Id == Id);
        }
    }
}