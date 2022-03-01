using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;

namespace WebAppRestaurantDemoApp.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities objRestaurantDbEntities;
        public CustomerRepository()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomers()
        {

            var objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestaurantDbEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objselectListItems;

        }

    }
}