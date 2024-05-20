﻿using DataAccess.Entity;
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
    public class AppointmentService : IAppointmentService
    {
        private readonly IApponintmentRepository _apponintmentRepository;
        public AppointmentService(IApponintmentRepository apponintmentRepository)
        {
            _apponintmentRepository = apponintmentRepository;
        }
        public List<AppointmentModell> GetAll()
        {
            var entityList = _apponintmentRepository.GetAll();
            return entityList.Select(x => new AppointmentModell
            {
                Id = x.Id,
                ServiceType = x.ServiceType,
                DateAndTimeOfAppointment = x.DateAndTimeOfAppointment,
                Price = x.Price
            }).ToList();
        }

        public (string Message, bool IsSuccess) Insert(AppointmentModell model)
        {
            var enitity = new AppointmentEntity
            {
                ServiceType = model.ServiceType,
                DateAndTimeOfAppointment = model.DateAndTimeOfAppointment,
                Price = model.Price
            };
            var result = _apponintmentRepository.Insert(enitity);
            return result;
        }

        public (string Message, bool IsSuccess) Update(AppointmentModell model)
        {
            if (model.Id <= 0)
                return ("Is Is Not Valid!", false);
            var enitity = new AppointmentEntity
            {

                Id = model.Id,
                ServiceType = model.ServiceType,
                DateAndTimeOfAppointment = model.DateAndTimeOfAppointment,
                Price = model.Price
            };
            var result = _apponintmentRepository.Insert(enitity);
            return result;
        }

        public (string Message, bool IsSuccess) Delete(int Id) =>
            _apponintmentRepository.Delete(Id);

    }
}
