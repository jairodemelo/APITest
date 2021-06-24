using JaiVendas.Application.Interfaces;
using JaiVendas.CrossCutting.Infra.Environment.Validation;
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

        public async Task<IActionResult> Index(string search = default, string errorMessage = default)
        {
            ViewBag.Search = search;
            ViewBag.ErrorMessage = errorMessage;

            var customerList = await _customerAppService.GetAll(search);
            return View(customerList);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _customerAppService.Delete(id);
            return result.IsValid 
                ? RedirectToAction("Index")
                : RedirectToAction("Index", new { errorMessage = result.GetErrorMessage() });
        }
    }
}
