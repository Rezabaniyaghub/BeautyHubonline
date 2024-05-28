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
        AppointmentEntity GetById(int id);
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
                    return ("ثبت با موفقیت انجام شد.", true);
            }
            catch (Exception ex)
            {
                return ($"ثبت ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("ثبت ناموفق بود.", false);
        }

        public AppointmentEntity GetById(int id)
        {
            return _appDbContext.Appointments.FirstOrDefault(x => x.Id == id);
        }

        public (string Message, bool IsSuccess) Update(AppointmentEntity model)
        {
            try
            {
                var old = _appDbContext.Appointments.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.CustomerId = model.CustomerId;
                    old.ServiceType = model.ServiceType;
                    old.DateAndTimeOfAppointment = model.DateAndTimeOfAppointment;
                    old.TurnStatus = model.TurnStatus;
                    old.Price = model.Price;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("ویرایش با موفقیت انجام شد.", true);
                    else
                        return ("موجودیت یافت نشد!", false);
                }
            }
            catch (Exception ex)
            {
                return ($"ویرایش ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("ویرایش ناموفق بود.", false);
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
                        return ("حذف با موفقیت انجام شد.", true);
                    else
                        return ("موجودیت یافت نشد!", false);
                }
            }
            catch (Exception ex)
            {
                return ($"حذف ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("حذف ناموفق بود.", false);
        }
    }

}
