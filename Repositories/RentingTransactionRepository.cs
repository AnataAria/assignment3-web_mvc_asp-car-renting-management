using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RentingTransactionRepository
    {
        private readonly RentingTransactionDAO _dao;

        public RentingTransactionRepository(RentingTransactionDAO dao)
        {
            _dao = dao;
        }

        public List<RentingTransaction> GetAllRentingTransactions()
        {
            return _dao.GetAllRentingTransactions();
        }

        public RentingTransaction GetRentingTransactionById(int rentingTransactionId)
        {
            return _dao.GetRentingTransactionById(rentingTransactionId);
        }

        public void AddRentingTransaction(RentingTransaction rentingTransaction)
        {
            _dao.AddRentingTransaction(rentingTransaction);
        }

        public void UpdateRentingTransaction(RentingTransaction rentingTransaction)
        {
            _dao.UpdateRentingTransaction(rentingTransaction);
        }

        public void DeleteRentingTransaction(int rentingTransactionId)
        {
            _dao.DeleteRentingTransaction(rentingTransactionId);
        }
    }
}
