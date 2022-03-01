using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;

namespace WebAppRestaurantDemoApp.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objRestaurantDbEntities;
        public PaymentTypeRepository()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {

           var objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestaurantDbEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objselectListItems;

        }
    }
}