using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JaiVendas.Application.Services;
using JaiVendas.Application.Interfaces;

namespace JaiVendas.API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("v1/[controller]/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerAppService.GetById(id);
            return customer != null 
                ? Ok(customer)
                : NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerAppService.GetAll();
            return result.Any() 
                ? Ok(result)
                : NoContent();
        }
    }
}
