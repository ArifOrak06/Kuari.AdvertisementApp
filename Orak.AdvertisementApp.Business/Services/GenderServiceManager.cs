using AutoMapper;
using FluentValidation;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.DataAccess.UnitOfWork;
using Orak.AdvertisementApp.Dtos;
using Orak.AdvertisementApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Business.Services
{
    public class GenderServiceManager : Service<GenderCreateDto,GenderUpdateDto, GenderListDto,Gender>, IGenderService
    {
        public GenderServiceManager(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}
