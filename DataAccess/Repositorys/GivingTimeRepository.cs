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

        public (string Message, bool Issuccess) Insert(GivingTimeEntity model)
        {
            try
            {
                 _appDbContext.GivingTimeEntities.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("Succes Don!", true);
            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

        public (string Message, bool Issuccess) Update(GivingTimeEntity model)
        {
            try
            {
                var old = _appDbContext.GivingTimeEntities.FirstOrDefault(x => x.CustomerId == model.CustomerId);
                if(old != null)
                {
                    old.GivingTimeId = model.GivingTimeId;
                    old.CustomerId = model.CustomerId;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Succes Don!", true);
                    else
                    {
                        return ("Entity Not Found!", false);
                    }
                }
              
            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

        public (string Message, bool Issuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.GivingTimeEntities.FirstOrDefault(x => x.CustomerId == Id);
                if (old != null)
                {
                    _appDbContext.GivingTimeEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Succes Don!", true);
                    else
                    {
                        return ("Entity Not Found!", false);
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return ("Faild!", false);
        }

    }
}
