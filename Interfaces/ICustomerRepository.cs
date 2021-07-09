using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Interfaces
{
    public interface ICustomerRepository
    {

        List<Customer> GetCustomers();

        Customer GetCustomer(int Cid);

        Customer AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        Customer EditCustomer(Customer customer);

    }
}
