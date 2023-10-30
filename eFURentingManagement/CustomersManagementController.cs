using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Repositories;

namespace eFURentingManagement
{
    public class CustomersManagementController : Controller
    {
        private readonly FUCarRentingManagementContext _context;
        private readonly CustomerRepository _customerRepository;

        public CustomersManagementController()
        {
            _customerRepository = new CustomerRepository();
        }

        // GET: CustomersManagement
        public IActionResult Index()
        {
            return _customerRepository != null ?
                        View(_customerRepository.GetAllCustomers()) :
                        Problem("Entity set 'FUCarRentingManagementContext.Customers'  is null.");
        }

        // GET: CustomersManagement/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomersManagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Telephone,Email,CustomerBirthday,CustomerStatus,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
               _customerRepository.AddCustomer(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersManagement/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomersManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,Telephone,Email,CustomerBirthday,CustomerStatus,Password")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersManagement/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomersManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_customerRepository == null)
            {
                return Problem("Entity set 'FUCarRentingManagementContext.Customers'  is null.");
            }
            var customer = _customerRepository.GetCustomerById(id);
            if (customer != null)
            {
                _customerRepository.DeleteCustomer(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _customerRepository.GetCustomerById(id) != null ? true : false;
        }
    }
}
