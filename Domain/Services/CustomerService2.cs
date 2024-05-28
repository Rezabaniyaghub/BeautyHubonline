using DataAccess.Entity;
using DataAccess.Repositorys;
using Domain.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService2 : ICustomerSevice2
    {
        private readonly ICustomerServiceRepository _customerServiceRepository;

        public CustomerService2(ICustomerServiceRepository customerServiceRepository)
        {
            _customerServiceRepository = customerServiceRepository;
        }

        public List<CustomerServiceModel> GetAll()
        {
            var entityList = _customerServiceRepository.GetAll();
            return entityList.Select(x => new CustomerServiceModel
            {
                Id = x.Id,
                ShortnessOfHair = x.ShortnessOfHair,
                HairShaping = x.HairShaping,
                ShavingBeard = x.ShavingBeard,
                GroomMakeUp = x.GroomMakeUp
            }).ToList();
        }

        public CustomerServiceModel GetById(int id)
        {
            var entity = _customerServiceRepository.GetById(id);
            var modell = new CustomerServiceModel
            {
                Id = entity.Id,
                ShortnessOfHair = entity.ShortnessOfHair,
                HairShaping = entity.HairShaping,
                ShavingBeard = entity.ShavingBeard,
                GroomMakeUp = entity.GroomMakeUp
            };
            return modell;
        }

        public (string Message, bool IsSuccess) Insert(CustomerServiceModel model)
        {
            var EntityList = new CustomerServiceEntity
            {
                ShortnessOfHair = model.ShortnessOfHair,
                HairShaping = model.HairShaping,
                ShavingBeard = model.ShavingBeard,
                GroomMakeUp = model.GroomMakeUp
            };
            var result = _customerServiceRepository.Insert(EntityList);
            return result;
        }

        public (string Message, bool IsSuccess) Update(CustomerServiceModel model)
        {
            var EntityList = new CustomerServiceEntity
            {
                ShortnessOfHair = model.ShortnessOfHair,
                HairShaping = model.HairShaping,
                ShavingBeard = model.ShavingBeard,
                GroomMakeUp = model.GroomMakeUp
            };
            var result = _customerServiceRepository.Update(EntityList);
            return result;
        }

        public (string Message, bool IsSuccess) Delete(int Id)
            => _customerServiceRepository.Delete(Id);

    }
}
