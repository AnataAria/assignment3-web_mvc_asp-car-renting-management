using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ManufacturerRepository
    {
        private readonly ManufacturerDAO _dao;

        public ManufacturerRepository()
        {
            _dao = new ManufacturerDAO();
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _dao.GetAllManufacturers();
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _dao.GetManufacturerById(manufacturerId);
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            _dao.AddManufacturer(manufacturer);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _dao.UpdateFacturer(manufacturer);
        }

        public void DeleteManufacturer(int manufacturerId)
        {
            _dao.DeleteManufacturer(manufacturerId);
        }
    }
}
