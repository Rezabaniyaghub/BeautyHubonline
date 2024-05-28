using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface IHirstylRepository
    {
        (string Message, bool IsSuccess) Insert(HairstylistEntity model);
        (string Message, bool IsSuccess) Update(HairstylistEntity model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<HairstylistEntity> GetAll();
        HairstylistEntity GetById(int id);
    }

    public class HairstylistRepository : IHirstylRepository
    {
        private readonly AppDbContext _appDbContext;
        public HairstylistRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<HairstylistEntity> GetAll()
        {
            return _appDbContext.HairstylistEntities.ToList();
        }

        public HairstylistEntity GetById(int id)
        {
            return _appDbContext.HairstylistEntities.FirstOrDefault(x=>x.Id==id);
        }

        public (string Message, bool IsSuccess) Insert(HairstylistEntity model)
        {
            try
            {
                _appDbContext.HairstylistEntities.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("موفقیت‌آمیز بود!", true);
            }
            catch (Exception ex)
            {
            }
            return ("خطا رخ داده است!", false);
        }

        public (string Message, bool IsSuccess) Update(HairstylistEntity model)
        {
            try
            {
                var old = _appDbContext.HairstylistEntities.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.Id = model.Id;
                    old.FullName = model.FullName;
                    old.HallName = model.HallName;
                    old.Address = model.Address;
                    old.PhoneNumber = model.PhoneNumber;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("موفقیت‌آمیز بود!", true);
                    else
                        return ("موجودیت یافت نشد!", false);
                }
            }
            catch (Exception ex)
            {
            }
            return ("خطا رخ داده است!", false);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.HairstylistEntities.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.HairstylistEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("موفقیت‌آمیز بود!", true);
                    else
                        return ("موجودیت یافت نشد!", false);
                }
            }
            catch (Exception ex)
            {
            }
            return ("خطا رخ داده است!", false);
        }

    }


}

