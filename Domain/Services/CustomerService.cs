using DataAccess.Entity;
using DataAccess.Repositorys;
using Domain.Abstract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ICustomerServicee
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerModel> GetAll()
        {
            var EntityList = _customerRepository.GetAll();
            return EntityList.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                FullName = x.FullName,
                AvailableTime = x.AvailableTime,
                BookedAppointment = x.BookedAppointment,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            }).ToList();
        }

        public CustomerModel GetById(int id)
        {
            var entity = _customerRepository.GetById(id);
            var modell = new CustomerModel
            {
                CustomerId = entity.CustomerId,
                FullName = entity.FullName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                BookedAppointment = entity.BookedAppointment
            };
            return modell;
        }

        public (string Message, bool Issuccess) Insert(CustomerModel model)
        {
            var Entity = new CustomerEntity
            {
                FullName = model.FullName,
                AvailableTime = model.AvailableTime,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BookedAppointment = model.BookedAppointment,
            };
            var result = _customerRepository.Insert(Entity);
            return result;
        }

        public (string Message, bool Issuccess) Update(CustomerModel model)
        {
            var Entity = new CustomerEntity
            {
                FullName = model.FullName,
                AvailableTime = model.AvailableTime,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BookedAppointment = model.BookedAppointment,
            };
            var result = _customerRepository.Update(Entity);
            return result;
        }

        public (string Message, bool Issuccess) Delete(int Id)
            => _customerRepository.Delete(Id);

    }
}
