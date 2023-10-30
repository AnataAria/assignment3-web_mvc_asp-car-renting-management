using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CarInformationRepository
    {
        private readonly CarInformationDAO _dao;

        public CarInformationRepository()
        {
            _dao = new CarInformationDAO();
        }

        public List<CarInformation> GetAllCars()
        {
            return _dao.GetAllCars();
        }

        public CarInformation GetCarById(int carId)
        {
            return _dao.GetCarById(carId);
        }

        public void AddCar(CarInformation car)
        {
            _dao.AddCar(car);
        }

        public void UpdateCar(CarInformation car)
        {
            _dao.UpdateCar(car);
        }

        public void DeleteCar(int carId)
        {
            _dao.DeleteCar(carId);
        }
    }
}
