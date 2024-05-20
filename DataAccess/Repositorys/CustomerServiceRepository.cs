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
        (string Message, bool IssSuccess) Insert(CustomerServiceEntity model);
        (string Message, bool IssSuccess) Update(CustomerServiceEntity model);
        (string Message, bool IssSuccess) Delete(int Id);
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

        public (string Message, bool IssSuccess) Insert(CustomerServiceEntity model)
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
            }
            return ("ثبت نام شما ناموفق بود.", false);
        }

        public (string Message, bool IssSuccess) Update(CustomerServiceEntity model)
        {
            try
            {
                var old = _appDbContext.CustomerServiceEntities.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    old.Id = model.Id;
                    old.ShortnessOfHair = model.ShortnessOfHair;
                    old.CustomerEntity = model.CustomerEntity;
                    old.ShavingBeard = model.ShavingBeard;
                    old.GroomMakeUp = model.GroomMakeUp;
                    var saveResult = _appDbContext.SaveChanges();

                    if (saveResult > 0)
                        return ("تغییرات شما با موفقیت انجام شد.", true);
                }
            }
            catch (Exception ex)
            {
            }
            return ("تغییرات شما نا موفق بود.", false);
        }

        public (string Message, bool IssSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.CustomerServiceEntities.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.CustomerServiceEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();

                    if (saveResult > 0)
                        return ("تغییرات شما با موفقیت انجام شد.", true);
                }
            }
            catch (Exception ex)
            {
            }
            return ("تغییرات شما نا موفق بود.", false);
        }

    }
}
