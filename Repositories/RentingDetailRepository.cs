using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RentingDetailRepository
    {
        private readonly RentingDetailDAO _dao;

        public RentingDetailRepository(RentingDetailDAO dao)
        {
            _dao = dao;
        }

        public List<RentingDetail> GetAllRentingDetails()
        {
            return _dao.GetAllRentingDetails();
        }

        public RentingDetail GetRentingDetailById(int rentingTransactionId, int carId, DateTime startDate, DateTime endDate)
        {
            return _dao.GetRentingDetailById(rentingTransactionId, carId, startDate, endDate);
        }

        public void AddRentingDetail(RentingDetail rentingDetail)
        {
            _dao.AddRentingDetail(rentingDetail);
        }

        public void UpdateRentingDetail(RentingDetail rentingDetail)
        {
            _dao.UpdateRentingDetail(rentingDetail);
        }

        public void DeleteRentingDetail(int rentingTransactionId, int carId, DateTime startDate, DateTime endDate)
        {
            _dao.DeleteRentingDetail(rentingTransactionId, carId, startDate, endDate);
        }
    }
}
