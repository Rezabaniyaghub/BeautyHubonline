using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface ICustomerServiceRepository
    {
        (string Message, bool IsSuccess) Insert(CustomerServiceEntity model);
        (string Message, bool IsSuccess) Update(CustomerServiceEntity model);
        (string Message, bool IsSuccess) Delete(int Id);
        CustomerServiceEntity GetById(int id);
        List<CustomerServiceEntity> GetAll();
    }

    public class CustomerServiceRepository : ICustomerServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<CustomerServiceEntity> GetAll()
        {
            return _appDbContext.CustomerServiceEntities.ToList();
        }

        public CustomerServiceEntity GetById(int id)
        {
            return _appDbContext.CustomerServiceEntities.FirstOrDefault(x => x.Id == id);
        }

        public (string Message, bool IsSuccess) Insert(CustomerServiceEntity model)
        {
            try
            {
                _appDbContext.CustomerServiceEntities.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("ثبت نام شما با موفقیت انجام شد.", true);
            }
            catch (Exception ex)
            {
                return ($"ثبت نام شما ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("ثبت نام شما ناموفق بود.", false);
        }

        public (string Message, bool IsSuccess) Update(CustomerServiceEntity model)
        {
            try
            {
                var old = _appDbContext.CustomerServiceEntities.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.ShortnessOfHair = model.ShortnessOfHair;
                    old.CustomerEntity = model.CustomerEntity;
                    old.ShavingBeard = model.ShavingBeard;
                    old.GroomMakeUp = model.GroomMakeUp;
                    var saveResult = _appDbContext.SaveChanges();

                    if (saveResult > 0)
                        return ("تغییرات شما با موفقیت انجام شد.", true);
                    else
                        return ("Entity Not Found!", false);
                }
            }
            catch (Exception ex)
            {
                return ($"تغییرات شما نا موفق بود. خطا: {ex.Message}", false);
            }
            return ("تغییرات شما نا موفق بود.", false);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.CustomerServiceEntities.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.CustomerServiceEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();

                    if (saveResult > 0)
                        return ("حذف با موفقیت انجام شد.", true);
                    else
                        return ("Entity Not Found!", false);
                }
            }
            catch (Exception ex)
            {
                return ($"حذف شما نا موفق بود. خطا: {ex.Message}", false);
            }
            return ("حذف شما نا موفق بود.", false);
        }

       
    }

}
