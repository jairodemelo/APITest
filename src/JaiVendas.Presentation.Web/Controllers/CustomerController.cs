using JaiVendas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaiVendas.Presentation.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> Index(string search = default)
        {
            ViewBag.Search = search;

            var customerList = await _customerAppService.GetAll(search);
            return View(customerList);
        }
    }
}
