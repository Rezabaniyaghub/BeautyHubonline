using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ICustomerSevice2
    {

        (string Message, bool IsSuccess) Insert(CustomerServiceModel model);
        (string Message, bool IsSuccess) Update(CustomerServiceModel model);
        (string Message, bool IsSuccess) Delete(int Id);
        CustomerServiceModel GetById(int id);
        List<CustomerServiceModel> GetAll();
    }
}
