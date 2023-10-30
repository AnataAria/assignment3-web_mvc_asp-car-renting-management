using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CarInformationDAO
    {
        private readonly FUCarRentingManagementContext _context;

        public CarInformationDAO()
        {
            _context = new FUCarRentingManagementContext();
        }

        public List<CarInformation> GetAllCars()
        {
            return _context.CarInformations.Include(c => c.Manufacturer).Include(c => c.Supplier).ToList();
        }

        public CarInformation GetCarById(int carId)
        {
            return _context.CarInformations.Include(c => c.Manufacturer).Include(c => c.Supplier).FirstOrDefault(c => c.CarId == carId);
        }

        public void AddCar(CarInformation car)
        {
            _context.CarInformations.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(CarInformation car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            var car = _context.CarInformations.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                _context.CarInformations.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
