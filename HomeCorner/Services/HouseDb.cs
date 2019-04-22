using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeCorner.Models;

namespace HomeCorner.Services
{
    public class HouseDb
    {
        public static IEnumerable<House> GetAll()
        {
            using (var context = new HomeCornerContext())
            {
                return context.Houses.Include("House").ToList();
            }
        }
        public static House GetById(int Id)
        {
            using (var context = new HomeCornerContext())
            {
                return context.Houses.Include("House").SingleOrDefault(m => m.Id == Id);
            }
        }

        public static void Add(House house)
        {
            using (var context = new HomeCornerContext())
            {
                context.Houses.Add(house);
                context.SaveChanges();
            }
        }

        public static void Update(House house)
        {
            using (var context = new HomeCornerContext())
            {
                House houseToUpdate = context.Houses.Find(house.Id);
                house.Id = house.Id;
                houseToUpdate.Description = house.Description;
                houseToUpdate.ReleaseDate = house.ReleaseDate;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new HomeCornerContext())
            {
                House house = context.Houses.Find(id);
                context.Houses.Remove(house);
                context.SaveChanges();
            }
        }
    }
}