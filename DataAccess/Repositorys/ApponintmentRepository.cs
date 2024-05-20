using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface IApponintmentRepository
    {
        (string Message, bool IsSuccess) Insert(AppointmentEntity model);
        (string Message, bool IsSuccess) Update(AppointmentEntity model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<AppointmentEntity> GetAll();

    }

    public class AppointmentRepository : IApponintmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<AppointmentEntity> GetAll()
        {
            return _appDbContext.Appointments.ToList();
        }

        public (string Message, bool IsSuccess) Insert(AppointmentEntity model)
        {
            try
            {
                _appDbContext.Appointments.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("Success done!", true);
            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

        public (string Message, bool IsSuccess) Update(AppointmentEntity model)
        {
            try
            {
                var old = _appDbContext.Appointments.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.Id = model.Id;
                    old.ServiceType = model.ServiceType;
                    old.DateAndTimeOfAppointment = model.DateAndTimeOfAppointment;
                    old.TurnStatus = model.TurnStatus;
                    old.Price = model.Price;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Success done!", true);
                }
                else
                {
                    return ("Entity Not Found!", false);
                }

            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.Appointments.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.Appointments.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Success done!", true);
                }
                else
                {
                    return ("Entity Not Found!", false);
                }

            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

    }
}
