using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineAPI.Models;
using ShopOnlineAPI.Services;
using ShopOnlineAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await supplierService.GetAll();

            List<SupplierViewModel> supplierViewModelListMapped = mapper.Map<List<SupplierViewModel>>(suppliers);

            return Ok(supplierViewModelListMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await supplierService.GetById(id);

            SupplierViewModel supplierViewModelMapped = mapper.Map<SupplierViewModel>(supplier);

            return Ok(supplierViewModelMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Supplier Info is invalid!"
                });
            }

            try
            {
                Supplier supplierMapped = mapper.Map<Supplier>(supplierViewModel);

                var supplier = await supplierService.Add(supplierMapped);

                SupplierViewModel supplierViewModelMapped = mapper.Map<SupplierViewModel>(supplier);

                return Ok(supplierViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Supplier Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Supplier Info is invalid!"
                });
            }

            try
            {
                Supplier supplierMapped = mapper.Map<Supplier>(supplierViewModel);

                var supplier = await supplierService.Update(supplierMapped);

                SupplierViewModel supplierViewModelMapped = mapper.Map<SupplierViewModel>(supplier);

                return Ok(supplierViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Supplier Info is invalid!"
                });
            }
        }
    }
}
