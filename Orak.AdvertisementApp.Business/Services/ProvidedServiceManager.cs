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
    public class ProvidedServiceManager : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceManager(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator,uow)
        {

        }
    }
}
