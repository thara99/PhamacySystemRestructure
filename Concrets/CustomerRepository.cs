using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Interfaces;
using PhamacySystemRestructure.Model;
using PhamacySystemRestructure.Context;

namespace PhamacySystemRestructure.Concrets
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext context)
        {
            _customerContext = context;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customerContext.customer.Add(customer);
            _customerContext.SaveChanges();
            return customer;

        }

        public void DeleteCustomer(Customer customer)
        {
            _customerContext.customer.Remove(customer);
            _customerContext.SaveChanges();
        }

        public Customer EditCustomer(Customer customer)
        {
            var exixtingCustomer = _customerContext.customer.Find(customer.CId);
            if (exixtingCustomer != null)
            {

                exixtingCustomer.CName = customer.CName;
                exixtingCustomer.PNum = customer.PNum;
                exixtingCustomer.Address = customer.Address;
                exixtingCustomer.NIC = customer.NIC;
                exixtingCustomer.AllergyMedicines = customer.AllergyMedicines;
                exixtingCustomer.Age = customer.Age;
                _customerContext.customer.Update(exixtingCustomer);
                _customerContext.SaveChanges();

            }
            return customer;
        }

        public Customer GetCustomer(int Cid)
        {
            var customer = _customerContext.customer.Find(Cid);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _customerContext.customer.ToList();
        }
    }
}
