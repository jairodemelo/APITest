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

        #region :: Construtor

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        #endregion

        #region :: Index

        public async Task<IActionResult> Index(string search = default, string errorMessage = default)
        {
            ViewBag.Search = search;
            ViewBag.ErrorMessage = ViewData["ErrorMessage"];

            var customerList = await _customerAppService.GetAll(search);
            return View(customerList);
        }

        #endregion

        #region :: Delete

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _customerAppService.Delete(id);
            if (!result.IsValid)
                ViewData["ErrorMessage"] = result.GetErrorMessage();

            return RedirectToAction("Index");
        }

        #endregion

        #region :: Add

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

        #endregion

        #region :: Update

        public async Task<IActionResult> Update(Guid id)
        {
            var customer = await _customerAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel customer)
        {
            var customerUpdateViewModel = new CustomerUpdateViewModel
            {
                Id = customer.Id,
                Name = customer.Name
            };
            var result = await _customerAppService.Update(customerUpdateViewModel);

            //Success
            if (result.IsValid)
                return RedirectToAction("Index");

            ViewBag.ErrorMessage = result.GetErrorMessage();
            return View(customer);
        }

        #endregion
    }
}
