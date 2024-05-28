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
    public class GivingTimeServise : IGivingTimeService
    {
        private readonly IGivingTimeRepository _givingTimeRepository;

        public GivingTimeServise(IGivingTimeRepository givingTimeRepository)
        {
            _givingTimeRepository = givingTimeRepository;
        }

        public List<GivingTimeModel> GetAll()
        {
            var entityList = _givingTimeRepository.GetAll();
            return entityList.Select(x => new GivingTimeModel
            {
                GivingTimeId = x.GivingTimeId,
                CustomerId = x.CustomerId
            }).ToList();
        }

        public GivingTimeModel GetById(int id)
        {
            var entity = _givingTimeRepository.GetById(id);
            var modell = new GivingTimeModel
            {
                GivingTimeId = entity.GivingTimeId,
                CustomerId = entity.CustomerId
            };
            return modell;
        }

        public (string Message, bool Issuccess) Insert(GivingTimeModel model)
        {
            var entity = new GivingTimeEntity
            {
                GivingTimeId = model.GivingTimeId,
                CustomerId = model.CustomerId
            };
            var result = _givingTimeRepository.Insert(entity);
            return result;
        }

        public (string Message, bool Issuccess) Update(GivingTimeModel model)
        {
            if (model.CustomerId <= 0)
                return ("Id Is Nout Valid", false);
            var entity = new GivingTimeEntity
            {
                GivingTimeId = model.GivingTimeId,
            };
            var result = _givingTimeRepository.Update(entity);
            return result;
        }

        public (string Message, bool Issuccess) Delete(int Id)
           => _givingTimeRepository.Delete(Id);

    }
}
