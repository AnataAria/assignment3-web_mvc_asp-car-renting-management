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
    public class CarInformationsController : Controller
    {
        private readonly CarInformationRepository _carInformationRepository;
        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly SupplierRepository _supplierRepository;

        public CarInformationsController()
        {
            _carInformationRepository = new CarInformationRepository();
            _manufacturerRepository = new ManufacturerRepository();
            _supplierRepository = new SupplierRepository();
        }

        // GET: CarInformations
        public IActionResult Index()
        {
            return View(_carInformationRepository.GetAllCars());
        }

        // GET: CarInformations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInformation = _carInformationRepository.GetCarById(id.Value);
            if (carInformation == null)
            {
                return NotFound();
            }

            return View(carInformation);
        }

        // GET: CarInformations/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_manufacturerRepository.GetAllManufacturers(), "ManufacturerId", "ManufacturerId");
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "SupplierId");
            return View();
        }

        // POST: CarInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarName,CarDescription,NumberOfDoors,SeatingCapacity,FuelType,Year,ManufacturerId,SupplierId,CarStatus,CarRentingPricePerDay")] CarInformation carInformation)
        {
            if (ModelState.IsValid)
            {
                _carInformationRepository.AddCar(carInformation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_manufacturerRepository.GetAllManufacturers(), "ManufacturerId", "ManufacturerId", carInformation.ManufacturerId);
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "SupplierId", carInformation.SupplierId);
            return View(carInformation);
        }

        // GET: CarInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInformation = _carInformationRepository.GetCarById(id.Value);
            if (carInformation == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_manufacturerRepository.GetAllManufacturers(), "ManufacturerId", "ManufacturerId", carInformation.ManufacturerId);
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "SupplierId", carInformation.SupplierId);
            return View(carInformation);
        }

        // POST: CarInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,CarName,CarDescription,NumberOfDoors,SeatingCapacity,FuelType,Year,ManufacturerId,SupplierId,CarStatus,CarRentingPricePerDay")] CarInformation carInformation)
        {
            if (id != carInformation.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carInformationRepository.UpdateCar(carInformation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarInformationExists(carInformation.CarId))
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
            ViewData["ManufacturerId"] = new SelectList(_manufacturerRepository.GetAllManufacturers(), "ManufacturerId", "ManufacturerId", carInformation.ManufacturerId);
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetAllSuppliers(), "SupplierId", "SupplierId", carInformation.SupplierId);
            return View(carInformation);
        }

        // GET: CarInformations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInformation = _carInformationRepository.GetCarById(id.Value);
            if (carInformation == null)
            {
                return NotFound();
            }

            return View(carInformation);
        }

        // POST: CarInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_carInformationRepository == null)
            {
                return Problem("Entity set 'FUCarRentingManagementContext.CarInformations'  is null.");
            }
            var carInformation = _carInformationRepository.GetCarById(id);
            if (carInformation != null)
            {
                _carInformationRepository.DeleteCar(carInformation.CarId);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CarInformationExists(int id)
        {
            return _carInformationRepository.GetCarById(id) != null ? true : false;
        }
    }
}
