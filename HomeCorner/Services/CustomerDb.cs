﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeCorner.Models;

namespace HomeCorner.Services
{
    public class CustomerDb
    {
        public static IEnumerable<Customer> GetAll()
        {
            using (var context = new HomeCornerContext())
            {
                return context.Customers.Include("Customer").ToList();
            }
        }
        public static Customer GetById(int Id)
        {
            using (var context = new HomeCornerContext())
            {
                return context.Customers.Include("Customer").SingleOrDefault(m => m.Id == Id);
            }
        }

        public static void Add(Customer customer)
        {
            using (var context = new HomeCornerContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public static void Update(Customer customer)
        {
            using (var context = new HomeCornerContext())
            {
                Customer customerToUpdate = context.Customers.Find(customer.Id);
                customer.Id = customer.Id;
                customerToUpdate.Name = customer.Name;
                customerToUpdate.Address = customer.Address;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new HomeCornerContext())
            {
                Customer customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}