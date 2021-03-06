using ClickAndCollect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickAndCollect.DAL.IDAL
{
    public interface IShopDAL
    {
        public List<Shop> GetShops();
        public Shop GetInfoShop(int id);
        public List<TimeSlot> GetTimeSlots(Shop shop);
        
    }
}
