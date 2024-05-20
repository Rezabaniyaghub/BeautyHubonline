using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ICustomerServicee
    {
        (string Message, bool Issuccess) Insert(CustomerModel model);
        (string Message, bool Issuccess) Update(CustomerModel model);
        (string Message, bool Issuccess) Delete(int Id);
        List<CustomerModel> GetAll();
    }
}
