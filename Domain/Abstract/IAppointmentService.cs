using DataAccess.Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAppointmentService
    {
        (string Message, bool IsSuccess) Insert(AppointmentModell model);
        (string Message, bool IsSuccess) Update(AppointmentModell model);
        (string Message, bool IsSuccess) Delete(int Id);
        AppointmentModell GetById(int id);
        List<AppointmentModell> GetAll();
    }
}
