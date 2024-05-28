using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IGivingTimeService
    {
        (string Message, bool Issuccess) Insert(GivingTimeModel model);
        (string Message, bool Issuccess) Update(GivingTimeModel model);
        (string Message, bool Issuccess) Delete(int Id);
        List<GivingTimeModel> GetAll();
        GivingTimeModel GetById(int id);
    }
}
