using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using WebAppRestaurantDemoApp.Models;
using WebAppRestaurantDemoApp.Repositories;
using WebAppRestaurantDemoApp.ViewModel;

namespace WebAppRestaurantDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantDBEntities restaurantDBEntities;
        public HomeController()
        {
            restaurantDBEntities = new RestaurantDBEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            var objCustomerRepository = new CustomerRepository();
            var objItemRepository = new ItemRepository();
            var objPaymentRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
                    objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }

        [HttpGet]

        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = restaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrdersRepository = new OrderRepository();
            objOrdersRepository.AddOrder(objOrderViewModel);
            return Json(data:"Your Order Has Been Successfully Placed",JsonRequestBehavior.AllowGet);


        }

    }
}