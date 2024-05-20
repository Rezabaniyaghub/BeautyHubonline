using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IHirstylService
    {

        (string Message, bool Issuccess) Insert(HairstylistModel model);
        (string Message, bool Issuccess) Update(HairstylistModel model);
        (string Message, bool Issuccess) Delete(int Id);
        List<HairstylistModel> GetAll();
    }
}
