using Orak.AdvertisementApp.Dtos;
using Orak.AdvertisementApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Business.İnterfaces
{
    public interface IGenderService : IService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {

    }
}
