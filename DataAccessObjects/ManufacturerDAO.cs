using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ManufacturerDAO
    {
        private readonly FUCarRentingManagementContext _context;

        public ManufacturerDAO()
        {
            _context = new FUCarRentingManagementContext();
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _context.Manufacturers.ToList();
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
        }
        public void AddManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
        }

        public void UpdateFacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteManufacturer(int manuId)
        {
            var manufacturer  = _context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == manuId);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                _context.SaveChanges();
            }
        }
    }
}
