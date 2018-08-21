using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Models;

namespace testdbfirst.Repository.ImplRepository
{
    public interface ICustomerOrders
    {
        IEnumerable<CustomerOrders> getAllCustomerOrders();
        CustomerOrders getFindIDCustomerOrders(string id);
        bool CreateCustomerOrders(CustomerOrders RPC);
        bool EditCustomerOrders(string id, CustomerOrders RPC);
        bool deleteCustomerOrders(string id);

    }
}
