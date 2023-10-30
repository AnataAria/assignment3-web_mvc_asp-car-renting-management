using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierRepository
    {
        private readonly SupplierDAO _dao;

        public SupplierRepository()
        {
            _dao = new SupplierDAO ();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _dao.GetAllSuppliers();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return _dao.GetSupplierById(supplierId);
        }

        public void AddSupplier(Supplier supplier)
        {
            _dao.AddSupplier(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _dao.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(int supplierId)
        {
            _dao.DeleteSupplier(supplierId);
        }
    }
}
