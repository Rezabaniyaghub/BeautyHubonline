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
    public class HirstylService : IHirstylService
    {
        private readonly IHirstylRepository _hirstylRepository;

        public HirstylService(IHirstylRepository hirstylRepository)
        {
            _hirstylRepository = hirstylRepository;
        }

        public List<HairstylistModel> GetAll()
        {
            var entityList = _hirstylRepository.GetAll();
            return entityList.Select(x => new HairstylistModel
            {
                Id = x.Id,
                FullName = x.FullName,
                HallName = x.HallName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                ImageName = x.ImageName
            }).ToList();
        }

        public HairstylistModel GetById(int id)
        {
            var entity = _hirstylRepository.GetById(id);
            var modell = new HairstylistModel
            {
                Id = entity.Id,
                FullName = entity.FullName,
                HallName = entity.HallName,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                ImageName = entity.ImageName
            };
            return modell;
        }

        public (string Message, bool Issuccess) Insert(HairstylistModel model)
        {
            var entity = new HairstylistEntity
            {
                FullName = model.FullName,
                Address = model.Address,
                HallName = model.HallName,
                PhoneNumber = model.PhoneNumber
            };
            var result = _hirstylRepository.Insert(entity);
            return result;
        }

        public (string Message, bool Issuccess) Update(HairstylistModel model)
        {
            if (model.Id <= 0)
                return ("Id Is Nout Valid", false);
            var entity = new HairstylistEntity
            {
                Id = model.Id,
                FullName = model.FullName,
                Address = model.Address,
                HallName = model.HallName,
                PhoneNumber = model.PhoneNumber
            };
            var result = _hirstylRepository.Insert(entity);
            return result;
        }

        public (string Message, bool Issuccess) Delete(int Id)
            => _hirstylRepository.Delete(Id);

    }
}
