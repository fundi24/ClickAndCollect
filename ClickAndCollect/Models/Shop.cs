using ClickAndCollect.DAL;
using ClickAndCollect.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickAndCollect.Models
{
    public class Shop
    {
        
        private int postCode;
        private int shopId;
        public int ShopId { get =>shopId; set =>shopId=value; }
        public int PostCode { get => postCode; set => postCode=value; }
        public List<Order> Orders { get; set; }
        
        public Shop()
        {
            
        }

        public static List<Shop> GetShops(IShopDAL shopDAL)
        {
            return shopDAL.GetShops();
        }

        public static Shop GetInfoShop(IShopDAL shopDAL, int id)
        {
            return shopDAL.GetInfoShop(id);
        }

        public static List<TimeSlot> GetTimeSlots(IShopDAL shopDAL, Shop shop)
        {
            return shopDAL.GetTimeSlots(shop);
        }

    }
}
