﻿using ClickAndCollect.DAL;
using ClickAndCollect.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickAndCollect.Models
{
    public class Product
    {
        public int NumProduct { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Prix { get; set; }
        private List<Order> Orders { get; set; }

        public Product()
        {

        }

        public Product(string n, string c)
        {
            name = n;
            category = c;
            orders = new List<Order>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static List<Product> GetProducts(IProductDAL productDAL, Product produit)
        {
            return productDAL.GetProducts(produit);
        }
        
        public static List<Product> GetCategorys(IProductDAL productDAL)
        {
            return productDAL.GetCategorys();
        }

        public Product GetInfoProduct(IProductDAL productDAL)
        {
            return productDAL.GetInfoProduct(this);
        }
    }
}
