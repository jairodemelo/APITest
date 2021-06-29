using JaiVendas.Application.Interfaces;
using JaiVendas.CrossCutting.Infra.Environment.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaiVendas.Application.ViewModel.Customers;

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
            ViewBag.ErrorMessage = ViewData["ErrorMessage"];

            var customerList = await _customerAppService.GetAll(search);
            return View(customerList);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _customerAppService.Delete(id);
            if (!result.IsValid)
                ViewData["ErrorMessage"] = result.GetErrorMessage();

            return RedirectToAction("Index");
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddViewModel customerAddViewModel)
        {
            var result = await _customerAppService.Add(customerAddViewModel);

            //Success
            if (result.ValidationResult.IsValid)
                return RedirectToAction("Index");

            ViewBag.ErrorMessage = result.ValidationResult.GetErrorMessage();
            return View(customerAddViewModel);
        }

    }
}
