﻿using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface ICustomerRepository
    {
        (string Message, bool IsSuccess) Insert(CustomerEntity model);
        (string Message, bool IsSuccess) Update(CustomerEntity model);
        (string Message, bool IsSuccess) Delete(int Id);
        CustomerEntity GetById(int id);
        List<CustomerEntity> GetAll();
    }


    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<CustomerEntity> GetAll()
        {
            return _appDbContext.CustomerEntities.ToList();
        }

        public CustomerEntity GetById(int id)
        {
            return _appDbContext.CustomerEntities.FirstOrDefault(x => x.CustomerId == id);
        }

        public (string Message, bool IsSuccess) Insert(CustomerEntity model)
        {
            try
            {
                _appDbContext.CustomerEntities.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                {
                    return ("ثبت نام با موفقیت انجام شد.", true);
                }
            }
            catch (Exception ex)
            {
                return ($"ثبت نام ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("ثبت نام ناموفق بود.", false);
        }

        public (string Message, bool IsSuccess) Update(CustomerEntity model)
        {
            try
            {
                var old = _appDbContext.CustomerEntities.FirstOrDefault(x => x.CustomerId == model.CustomerId);
                if (old != null)
                {
                    old.FullName = model.FullName;
                    old.Email = model.Email;
                    old.PhoneNumber = model.PhoneNumber;
                    old.AvailableTime = model.AvailableTime;
                    old.BookedAppointment = model.BookedAppointment;
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                    {
                        return ("بروزرسانی با موفقیت انجام شد.", true);
                    }
                    else
                    {
                        return ("موجودیت یافت نشد!", false);
                    }
                }
            }
            catch (Exception ex)
            {
                return ($"بروزرسانی ناموفق بود. خطا: {ex.Message}", false);
            }
            return ("بروزرسانی ناموفق بود.", false);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.CustomerEntities.FirstOrDefault(x => x.CustomerId == Id);
                if (old != null)
                {
                    _appDbContext.CustomerEntities.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                    {
                        return ("حذف با موفقیت انجام شد.", true);
                    }
                    else
                    {
                        return ("موجودیت یافت نشد!", false);
                    }
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
