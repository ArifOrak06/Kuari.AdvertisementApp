using AutoMapper;
using FluentValidation;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.Business.ValidationRules;
using Orak.AdvertisementApp.Common;
using Orak.AdvertisementApp.Common.Enums;
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
    public class AdvertisementServiceManager : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementServiceManager(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper,createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
        {
             var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x=> x.Status, x=> x.CreatedDate,OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);

        }
    }
}
