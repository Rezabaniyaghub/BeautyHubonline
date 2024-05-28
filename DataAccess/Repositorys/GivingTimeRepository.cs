using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface IGivingTimeRepository
    {
        (string Message, bool Issuccess) Insert(GivingTimeEntity model);
        (string Message, bool Issuccess) Update(GivingTimeEntity model);
        (string Message, bool Issuccess) Delete(int Id);
        List<GivingTimeEntity> GetAll();
        GivingTimeEntity GetById(int id);
    }


    public class GivingTimeRepository : IGivingTimeRepository
    {
        private readonly AppDbContext _appDbContext;
        public GivingTimeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<GivingTimeEntity> GetAll()
        {
            return _appDbContext.GivingTimeEntities.ToList();
        }

        public GivingTimeEntity GetById(int id)
        {
            return _appDbContext.GivingTimeEntities.FirstOrDefault(x => x.GivingTimeId == id);
        }

        public (string Message, bool Issuccess) Insert(GivingTimeEntity model)
        {
            try
            {
                _appDbContext.GivingTimeEntities.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("ثبت نوبت با موفقیت انجام شد.", true);
            }
            catch (Exception ex)
            {
                return ($"ثبت نوبت ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("ثبت نوبت ناموفق بود.", false);
        }

        public (string Message, bool Issuccess) Update(GivingTimeEntity model)
        {
            try
            {
                var old = _appDbContext.GivingTimeEntities.FirstOrDefault(x => x.GivingTimeId == model.GivingTimeId);
                if (old != null)
                {
                    old.CustomerId = model.CustomerId;
                    old.HairstylistEntity = model.HairstylistEntity;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("به‌روزرسانی نوبت با موفقیت انجام شد.", true);
                    else
                    {
                        return ("موجودیت یافت نشد!", false);
                    }
                }
            }
            catch (Exception ex)
            {
                return ($"به‌روزرسانی نوبت ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("به‌روزرسانی نوبت ناموفق بود.", false);
        }

        public (string Message, bool Issuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.GivingTimeEntities.FirstOrDefault(x => x.GivingTimeId == Id);
                if (old != null)
                {
                    _appDbContext.GivingTimeEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("حذف نوبت با موفقیت انجام شد.", true);
                    else
                    {
                        return ("موجودیت یافت نشد!", false);
                    }
                }
            }
            catch (Exception ex)
            {
                return ($"حذف نوبت ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("حذف نوبت ناموفق بود.", false);
        }

    }

}
