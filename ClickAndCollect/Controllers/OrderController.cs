using ClickAndCollect.DAL;
using ClickAndCollect.DAL.IDAL;
using ClickAndCollect.Models;
using ClickAndCollect.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickAndCollect.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDAL _orderDAL;
       
        


        public OrderController(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }
        
       
        public IActionResult Details(int id)
        {
            Order order = Order.GetDetails(id, _orderDAL);
            if (order == null)
            {
                ViewData["Error"] = "Commande introuvable!";
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderReady(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.ModifyReady(_orderDAL))
                {
                    if (order.Ready)
                    {
                        TempData["OrderValid"] = "Commande prête!";
                    }
                    else
                    {
                        TempData["OrderValid"] = "Attention! La commande n'est pas prête, veuillez indiquer que c'est prêt";
                    }
                    
                }else
                {
                    TempData["OrderValid"] = "L'insertion s'est mal déroulé veuillez réessayer!";
                }
            }
            return Redirect($"details/{order.OrderId}");
        }
        public IActionResult Validate()
        {
            try
            {
                var obj = HttpContext.Session.GetString("CurrentOrder");
                OrderDicoViewModels orderDicoViewModels = JsonConvert.DeserializeObject<OrderDicoViewModels>(obj);
                OrderDicoViewModels orderDicoViewModels2 = orderDicoViewModels;
                bool result = orderDicoViewModels.Order.MakeOrder(_orderDAL, orderDicoViewModels2);
                if (result == true)
                {
                    HttpContext.Session.SetString("CurrentOrder", "False");

                    TempData["SuccessOrder"] = "Felicitation ta commande a été validé !";
                    return Redirect("/Product/Index");
                }

                TempData["ErrorOrder"] = "La commande n'a pas abouti !!";
                return Redirect("/Product/Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur session";
                return Redirect("/Product/Index");
            }

        }

        public IActionResult History()
        {
            try
            {
                int Id = (int)HttpContext.Session.GetInt32("Id");
                Customer customer = new Customer();
                customer.Id = Id;

                List<OrderTimeSlotOrderProductViewModel> orders = Order.GetOrders(_orderDAL, customer);

                return View(orders);
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur session";
                return Redirect("/Product/Index");
            }
        }
        
        
        
    }
}