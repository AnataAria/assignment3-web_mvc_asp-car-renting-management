using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RentingTransactionDAO
    {
        private readonly FUCarRentingManagementContext _context;

        public RentingTransactionDAO()
        {
            _context = new FUCarRentingManagementContext();
        }

        public List<RentingTransaction> GetAllRentingTransactions()
        {
            return _context.RentingTransactions.ToList();
        }

        public RentingTransaction GetRentingTransactionById(int rentingTransactionId)
        {
            return _context.RentingTransactions.FirstOrDefault(rt => rt.RentingTransationId == rentingTransactionId);
        }

        public void AddRentingTransaction(RentingTransaction rentingTransaction)
        {
            _context.RentingTransactions.Add(rentingTransaction);
            _context.SaveChanges();
        }

        public void UpdateRentingTransaction(RentingTransaction rentingTransaction)
        {
            _context.Entry(rentingTransaction).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRentingTransaction(int rentingTransactionId)
        {
            var rentingTransaction = GetRentingTransactionById(rentingTransactionId);
            if (rentingTransaction != null)
            {
                _context.RentingTransactions.Remove(rentingTransaction);
                _context.SaveChanges();
            }
        }
    }
}
