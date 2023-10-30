using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RentingDetailDAO
    {
        private readonly FUCarRentingManagementContext _context;

        public RentingDetailDAO()
        {
            _context = new FUCarRentingManagementContext();
        }

        public List<RentingDetail> GetAllRentingDetails()
        {
            return _context.RentingDetails.ToList();
        }

        public RentingDetail GetRentingDetailById(int rentingTransactionId, int carId, DateTime startDate, DateTime endDate)
        {
            return _context.RentingDetails.FirstOrDefault(rd =>
                rd.RentingTransactionId == rentingTransactionId &&
                rd.CarId == carId &&
                rd.StartDate == startDate &&
                rd.EndDate == endDate);
        }

        public void AddRentingDetail(RentingDetail rentingDetail)
        {
            _context.RentingDetails.Add(rentingDetail);
            _context.SaveChanges();
        }

        public void UpdateRentingDetail(RentingDetail rentingDetail)
        {
            _context.Entry(rentingDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRentingDetail(int rentingTransactionId, int carId, DateTime startDate, DateTime endDate)
        {
            var rentingDetail = GetRentingDetailById(rentingTransactionId, carId, startDate, endDate);
            if (rentingDetail != null)
            {
                _context.RentingDetails.Remove(rentingDetail);
                _context.SaveChanges();
            }
        }
    }
}
